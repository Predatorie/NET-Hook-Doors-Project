// <copyright file="ShakerBeadViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module.ViewModels
{
    using System;
    using System.Linq;
    using MahApps.Metro.Controls.Dialogs;
    using Mastercam.IO;
    using MDFDoors.Module.Models;
    using MDFDoors.Shared;
    using MDFDoors.Shared.Events;
    using MDFDoors.Shared.Localization;
    using MDFDoors.Shared.Services;
    using Microsoft.Practices.Unity;
    using Prism.Events;
    using Prism.Mvvm;
    using Prism.Regions;

    public class ShakerBeadViewModel : BindableBase, INavigationAware
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
        private ShakerBead model;

        /// <summary>
        /// Backing field for multipleCopies
        /// </summary>
        private bool multipleCopies;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ShakerBeadViewModel"/> class.</summary>
        public ShakerBeadViewModel()
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="ShakerBeadViewModel"/> class.Constructor.</summary>
        /// 
        /// <remarks>Mick George, 11/6/2017.</remarks>
        /// 
        /// <param name="eventAggregator">The event aggregator singleton.</param>
        /// <param name="container">      The container singleton.</param>
        /// <param name="geometryCreation">The Geometry Creation Service singleton </param>
        /// <param name="dialogCoordinator">The Dialog Coordinator singleton</param>
        /// <param name="serializationService">The Serialization Service singleton</param>
        /// <param name="settingsService">The ISettingsService singleton</param>
        public ShakerBeadViewModel(
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

            this.Model = container.Resolve<ShakerBead>();

            this.InitializeToDefaults();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the model.</summary>
        ///
        /// <value>The model.</value>
        public ShakerBead Model
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

        /// <summary>Called when the implementer has been navigated to.</summary>
        /// <param name="navigationContext">The navigation context.</param>
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

        /// <summary>
        /// Called to determine if this instance can handle the navigation request.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        /// <returns>
        /// <see langword="true" /> if this instance accepts the navigation request; otherwise, <see langword="false" />.
        /// </returns>
        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        /// <summary>
        /// Called when the implementer is being navigated away from.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
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
            this.model.BeadLevelName = "beads";
            this.Model.OuterLevelNumber = 1;
            this.Model.InnerLevelNumber = 2;
            this.Model.GrooveLevelNumber = 3;
            this.model.BeadLevelNumber = 4;

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
            var result = this.serializationService.DeserializeDoorStyle<ShakerBead>();
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
            var result = this.serializationService.SerializeDoorStyle<ShakerBead>(this.Model);
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
