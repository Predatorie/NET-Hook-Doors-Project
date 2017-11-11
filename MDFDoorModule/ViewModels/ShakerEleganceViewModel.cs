// <copyright file="ShakerEleganceViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module.ViewModels
{
    using System.Linq;
    using MahApps.Metro.Controls.Dialogs;
    using Shared.Localization;
    using Microsoft.Practices.Unity;
    using Prism.Events;
    using Prism.Mvvm;
    using Prism.Regions;
    using Shared;
    using Shared.Events;
    using Shared.Models;
    using Shared.Services;

    public class ShakerEleganceViewModel : BindableBase, INavigationAware
    {
        #region Fields

        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>The geometry creation.</summary>
        private readonly IGeometryCreationService geometryCreation;

        /// <summary>The dialog coordinator.</summary>
        private readonly IDialogCoordinator dialogCoordinator;

        /// <summary>The serialization service.</summary>
        private readonly ISerializationService serializationService;

        /// <summary>The door type label.</summary>
        private string doorTypeLabel;

        #endregion

        #region Construction

        /// <summary>Default constructor.</summary>
        ///
        /// <remarks>Mick George, 11/6/2017.</remarks>
        public ShakerEleganceViewModel() { }

        ///  <summary>
        ///  Initializes a new instance of the <see cref="ShakerEleganceViewModel"/> class.Constructor.</summary>
        /// 
        ///  <remarks>Mick George, 11/6/2017.</remarks>
        /// 
        ///  <param name="eventAggregator">The event aggregator singleton.</param>
        ///  <param name="container">      The container singleton.</param>
        /// <param name="geometryCreation">The Geometry Creation Service singletone </param>
        /// <param name="dialogCoordinator">The Dialog Coordinator singleton</param>
        /// <param name="serializationService">The Serialization Service singleton</param>
        public ShakerEleganceViewModel(
            IEventAggregator eventAggregator,
            IUnityContainer container,
            IGeometryCreationService geometryCreation,
            IDialogCoordinator dialogCoordinator,
            ISerializationService serializationService)
        {
            this.eventAggregator = eventAggregator;
            this.geometryCreation = geometryCreation;
            this.dialogCoordinator = dialogCoordinator;
            this.serializationService = serializationService;
            this.Model = container.Resolve<ShakerElegance>();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the type of the door.</summary>
        ///
        /// <value>The type of the door.</value>
        public string DoorTypeLabel
        {
            get => this.doorTypeLabel;
            set => this.SetProperty(ref this.doorTypeLabel, value);
        }

        /// <summary>The model.</summary>
        internal ShakerElegance Model { get; private set; }

        /// <summary>Gets or sets the height.</summary>
        ///
        /// <value>The height.</value>
        public double Height
        {
            get => this.Model.Height;
            set => this.Model.Height = value;
        }

        /// <summary>Gets or sets the width.</summary>
        ///
        /// <value>The width.</value>
        public double Width
        {
            get => this.Model.Width;
            set => this.Model.Width = value;
        }

        /// <summary>Gets or sets the width of the top rail.</summary>
        ///
        /// <value>The width of the top rail.</value>
        public double TopRailWidth
        {
            get => this.Model.TopRailWidth;
            set => this.Model.TopRailWidth = value;
        }

        /// <summary>Gets or sets the width of the bottom rail.</summary>
        ///
        /// <value>The width of the bottom rail.</value>
        public double BottomRailWidth
        {
            get => this.Model.BottomRailWidth;
            set => this.Model.BottomRailWidth = value;
        }

        /// <summary>Gets or sets the width of the left stile.</summary>
        ///
        /// <value>The width of the left stile.</value>
        public double LeftStileWidth
        {
            get => this.Model.LeftStileWidth;
            set => this.Model.LeftStileWidth = value;
        }

        /// <summary>Gets or sets the width of the right side.</summary>
        ///
        /// <value>The width of the right side.</value>
        public double RightSideWidth
        {
            get => this.Model.RightSideWidth;
            set => this.Model.RightSideWidth = value;
        }

        /// <summary>Gets or sets the groove level number.</summary>
        ///
        /// <value>The groove level number.</value>
        public int GrooveLevelNumber
        {
            get => this.Model.GrooveLevelNumber;
            set => this.Model.GrooveLevelNumber = value;
        }

        /// <summary>Gets or sets the name of the groove level.</summary>
        ///
        /// <value>The name of the groove level.</value>
        public string GrooveLevelName
        {
            get => this.Model.GrooveLevelName;
            set => this.Model.GrooveLevelName = value;
        }

        /// <summary>Gets or sets the outer level number.</summary>
        ///
        /// <value>The outer level number.</value>
        public int OuterLevelNumber
        {
            get => this.Model.OuterLevelNumber;
            set => this.Model.OuterLevelNumber = value;
        }

        /// <summary>Gets or sets the inner level number.</summary>
        ///
        /// <value>The inner level number.</value>
        public int InnerLevelNumber
        {
            get => this.Model.InnerLevelNumber;
            set => this.Model.InnerLevelNumber = value;
        }

        /// <summary>Gets or sets the name of the outer level.</summary>
        ///
        /// <value>The name of the outer level.</value>
        public string OuterLevelName
        {
            get => this.Model.OuterLevelName;
            set => this.Model.OuterLevelName = value;
        }

        /// <summary>Gets or sets the name of the inner level.</summary>
        ///
        /// <value>The name of the inner level.</value>
        public string InnerLevelName
        {
            get => this.Model.InnerLevelName;
            set => this.Model.InnerLevelName = value;
        }

        #endregion

        #region Public Methods

        /// <summary>   Executes the navigated to action. </summary>
        /// <param name="navigationContext">    Context for the navigation. </param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.Any())
            {
                // Group Header Label is all we are passing in
                this.DoorTypeLabel = navigationContext.Parameters[NavigationParamIndexer.Name].ToString();
            }

            // Subscribe to Model property change events
            this.Model.PropertyChanged += this.OnModelPropertyChanged;

            // Subscribe to our events
            this.eventAggregator.GetEvent<SaveDoorStyleEvent>().Subscribe(this.OnSaveDoorStyle);
            this.eventAggregator.GetEvent<LoadDoorStyleEvent>().Subscribe(this.OnLoadDoorStyle);
            this.eventAggregator.GetEvent<CreateDoorEvent>().Subscribe(this.OnCreateDoor);
        }

        /// <summary>   Query if 'navigationContext' is navigation target. </summary>
        /// <param name="navigationContext">    Context for the navigation. </param>
        /// <returns>   True if navigation target, false if not. </returns>
        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        /// <summary>   Executes the navigated from action. </summary>
        /// <param name="navigationContext">    Context for the navigation. </param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // UnSubscribe from Model property change events
            this.Model.PropertyChanged -= this.OnModelPropertyChanged;

            // Unsubscribe from our events
            this.eventAggregator.GetEvent<SaveDoorStyleEvent>().Unsubscribe(this.OnSaveDoorStyle);
            this.eventAggregator.GetEvent<LoadDoorStyleEvent>().Unsubscribe(this.OnLoadDoorStyle);
            this.eventAggregator.GetEvent<CreateDoorEvent>().Unsubscribe(this.OnCreateDoor);
        }

        #endregion

        #region Private Methods

        /// <summary>Executes the create door action.</summary>
        ///
        /// <remarks>Mick George, 11/6/2017.</remarks>
        private async void OnCreateDoor()
        {
            var result = this.geometryCreation.CreateShakerEleganceDoor(this.Model);
            if (result.IsFailure)
            {
                await this.dialogCoordinator.ShowMessageAsync(this, ApplicationStrings.Title, result.Error);
                return;
            }

            // TODO: Exit once complete..?
            this.eventAggregator.GetEvent<ExitAppEvent>().Publish();
        }

        /// <summary>Executes the load door style action.</summary>
        private async void OnLoadDoorStyle()
        {
            var result = this.serializationService.DeserializeDoorStyle<ShakerElegance>();
            if (result.IsFailure)
            {
                // string.empty means user cancelled prompt for file
                if (!string.IsNullOrEmpty(result.Error))
                {
                    await this.dialogCoordinator.ShowMessageAsync(this, ApplicationStrings.Title, result.Error);
                    return;
                }
            }

            this.Model = result.Value;
        }

        /// <summary>Executes the save door style action.</summary>
        private async void OnSaveDoorStyle()
        {
            var result = this.serializationService.SerializeDoorStyle<ShakerElegance>();
            if (result.IsFailure)
            {
                await this.dialogCoordinator.ShowMessageAsync(this, ApplicationStrings.Title, result.Error);
            }

            await this.dialogCoordinator.ShowMessageAsync(this, ApplicationStrings.Title, ApplicationStrings.DoorStyleSaved);
        }

        /// <summary>Raises the system. component model. property changed event.</summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Event information to send to registered event handlers.</param>
        private void OnModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            => this.RaisePropertyChanged(nameof(e.PropertyName));

        #endregion
    }
}
