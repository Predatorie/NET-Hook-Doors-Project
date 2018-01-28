// <copyright file="ShakerEleganceViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module.ViewModels
{
    using System;
    using System.Linq;
    using MahApps.Metro.Controls.Dialogs;
    using Mastercam.IO;
    using Microsoft.Practices.Unity;
    using Models;
    using Prism.Events;
    using Prism.Mvvm;
    using Prism.Regions;
    using Shared;
    using Shared.Events;
    using Shared.Localization;
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

        /// <summary>
        /// The ISettingsService service
        /// </summary>
        private readonly ISettingsService settingsService;

        /// <summary>The door type label.</summary>
        private string doorTypeLabel;

        /// <summary>The model.</summary>
        private ShakerElegance model;

        /// <summary>
        /// Backing field for multipleCopies
        /// </summary>
        private bool multipleCopies;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ShakerEleganceViewModel"/> class.Default constructor.</summary>
        ///
        /// <remarks>Mick George, 11/6/2017.</remarks>
        public ShakerEleganceViewModel()
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="ShakerEleganceViewModel"/> class.Constructor.</summary>
        /// 
        /// <remarks>Mick George, 11/6/2017.</remarks>
        /// 
        /// <param name="eventAggregator">The event aggregator singleton.</param>
        /// <param name="container">      The container singleton.</param>
        /// <param name="geometryCreation">The Geometry Creation Service singletone </param>
        /// <param name="dialogCoordinator">The Dialog Coordinator singleton</param>
        /// <param name="serializationService">The Serialization Service singleton</param>
        /// <param name="settingsService">The ISettingsService singleton</param>
        public ShakerEleganceViewModel(
            IEventAggregator eventAggregator,
            IUnityContainer container,
            IGeometryCreationService geometryCreation,
            IDialogCoordinator dialogCoordinator,
            ISerializationService serializationService,
            ISettingsService settingsService)
        {
            this.eventAggregator = eventAggregator;
            this.geometryCreation = geometryCreation;
            this.dialogCoordinator = dialogCoordinator;
            this.serializationService = serializationService;
            this.settingsService = settingsService;

            this.Model = container.Resolve<ShakerElegance>();

            this.InitializeToDefaults();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the model.</summary>
        ///
        /// <value>The model.</value>
        public ShakerElegance Model
        {
            get => this.model;
            set => this.SetProperty(ref this.model, value);
        }

        /// <summary>Gets or sets the type of the door.</summary>
        ///
        /// <value>The type of the door.</value>
        public string DoorTypeLabel
        {
            get => this.doorTypeLabel;
            set => this.SetProperty(ref this.doorTypeLabel, value);
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

            // Subscribe to our events
            this.eventAggregator.GetEvent<SaveDoorStyleEvent>().Subscribe(this.OnSaveDoorStyle);
            this.eventAggregator.GetEvent<LoadDoorStyleEvent>().Subscribe(this.OnLoadDoorStyle);
            this.eventAggregator.GetEvent<CreateDoorEvent>().Subscribe(this.OnCreateDoor);            
            this.eventAggregator.GetEvent<MultipleCopiesChangesEvent>().Subscribe(this.OnMultipleCopiesChangesEvent);
        }

        /// <summary>   Query if 'navigationContext' is navigation target. </summary>
        /// <param name="navigationContext">    Context for the navigation. </param>
        /// <returns>   True if navigation target, false if not. </returns>
        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        /// <summary>   Executes the navigated from action. </summary>
        /// <param name="navigationContext">    Context for the navigation. </param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Unsubscribe from our events
            this.eventAggregator.GetEvent<SaveDoorStyleEvent>().Unsubscribe(this.OnSaveDoorStyle);
            this.eventAggregator.GetEvent<LoadDoorStyleEvent>().Unsubscribe(this.OnLoadDoorStyle);
            this.eventAggregator.GetEvent<CreateDoorEvent>().Unsubscribe(this.OnCreateDoor);
            this.eventAggregator.GetEvent<MultipleCopiesChangesEvent>().Unsubscribe(this.OnMultipleCopiesChangesEvent);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the event
        /// </summary>
        /// <param name="copies">True if using multi copies false otherwise</param>
        private void OnMultipleCopiesChangesEvent(bool copies) => this.multipleCopies = copies;

        /// <summary>Initializes to defaults.</summary>
        private void InitializeToDefaults()
        {
            // TODO: Add to settings service
            this.Model.OuterLevelName = "outer";
            this.Model.InnerLevelName = "inner";
            this.Model.GrooveLevelName = "grooves";
            this.Model.OuterLevelNumber = 1;
            this.Model.InnerLevelNumber = 2;
            this.Model.GrooveLevelNumber = 3;

            this.model.MultipleCopies = this.settingsService.MultipleCopiesData();

            // TODO: Store this setting
            this.multipleCopies = false;

            var metric = SettingsManager.Metric;
            if (metric)
            {
                this.Model.Width = 406;
                this.Model.Height = 508;
                this.Model.TopRailWidth = 50;
                this.Model.BottomRailWidth = 50;
                this.Model.LeftStileWidth = 50;
                this.Model.RightSideWidth = 50;
                return;
            }

            this.Model.Width = 16;
            this.Model.Height = 20;
            this.Model.TopRailWidth = 2;
            this.Model.BottomRailWidth = 2;
            this.Model.LeftStileWidth = 2;
            this.Model.RightSideWidth = 2;
        }

        /// <summary>Executes the create door action.</summary>
        ///
        /// <remarks>Mick George, 11/6/2017.</remarks>
        private async void OnCreateDoor()
        {
            var result = this.geometryCreation.CreateDoor(this.Model, this.multipleCopies);
            if (result.IsFailure)
            {
                await this.dialogCoordinator.ShowMessageAsync(this, ApplicationStrings.Title, result.Error);
                return;
            }

            this.eventAggregator.GetEvent<ExitAppEvent>().Publish(true);
        }

        /// <summary>Executes the load door style action.</summary>
        private async void OnLoadDoorStyle()
        {
            var result = this.serializationService.DeserializeDoorStyle<ShakerElegance>();
            if (result.IsSuccess)
            {
                this.Model = result.Value;
                return;
            }

            if (!result.Error.Equals(Enum.GetName(typeof(ApplicationState), ApplicationState.UserCancelledDialog)))
            {
                await this.dialogCoordinator.ShowMessageAsync(this, ApplicationStrings.Title, result.Error);
            }
        }

        /// <summary>Executes the save door style action.</summary>
        private async void OnSaveDoorStyle()
        {
            var result = this.serializationService.SerializeDoorStyle<ShakerElegance>(this.Model);
            if (result.IsSuccess)
            {
                await this.dialogCoordinator.ShowMessageAsync(this, ApplicationStrings.Title, ApplicationStrings.DoorStyleSaved);
                return;
            }

            if (!result.Error.Equals(Enum.GetName(typeof(ApplicationState), ApplicationState.UserCancelledDialog)))
            {
                await this.dialogCoordinator.ShowMessageAsync(this, ApplicationStrings.Title, result.Error);
            }
        }

        #endregion
    }
}
