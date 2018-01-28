// <copyright file="CommandButtonsViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.ViewModels
{
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    using Microsoft.Practices.Unity;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;
    using Shared.Events;
    using Views;

    public class CommandButtonsViewModel : BindableBase
    {
        #region Private Fields

        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>The dialog coordinator.</summary>
        private readonly IDialogCoordinator dialogCoordinator;

        /// <summary>The unity container.</summary>
        private readonly IUnityContainer unityContainer;

        /// <summary>The custom dialog.</summary>
        private CustomDialog customDialog;

        /// <summary>
        /// Backing field for the switch
        /// </summary>
        private bool switchOn;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandButtonsViewModel"/> class.Constructor.</summary>
        /// <param name="eventAggregator">  The event aggregator.</param>
        /// <param name="dialogCoordinator">The dialog coordinator.</param>
        /// <param name="unityContainer">   The unity container.</param>
        public CommandButtonsViewModel(IEventAggregator eventAggregator, IDialogCoordinator dialogCoordinator, IUnityContainer unityContainer)
        {
            this.eventAggregator = eventAggregator;
            this.dialogCoordinator = dialogCoordinator;
            this.unityContainer = unityContainer;

            this.eventAggregator.GetEvent<CloseMultipleCopiesViewEvent>().Subscribe(this.CloseMultipleCopiesView);

            this.SaveCommand = new DelegateCommand(this.OnSaveCommand);
            this.LoadCommand = new DelegateCommand(this.OnLoadCommand);
            this.ExitCommand = new DelegateCommand(this.OnExitCommand);
            this.DrawCommand = new DelegateCommand(this.OnDrawCommand, this.CanDrawCommand);
            this.MultipleCopiesCommand = new DelegateCommand(this.ShowMultipleCopiesView);
            this.CheckChangedCommand = new DelegateCommand(this.OnCheckChangedCommand);
        }

        #endregion

        #region Public Commands

        /// <summary>Gets the save command.</summary>
        ///
        /// <value>The save command.</value>
        public DelegateCommand SaveCommand { get; }

        /// <summary>Gets the load command.</summary>
        ///
        /// <value>The load command.</value>
        public DelegateCommand LoadCommand { get; }

        /// <summary>Gets the exite command.</summary>
        ///
        /// <value>The exite command.</value>
        public DelegateCommand ExitCommand { get; }

        /// <summary>Gets the draw command.</summary>
        ///
        /// <value>The draw command.</value>
        public DelegateCommand DrawCommand { get; }

        /// <summary>Gets the multiple copies command.</summary>
        ///
        /// <value>The multiple copies command.</value>
        public DelegateCommand MultipleCopiesCommand { get; }

        /// <summary>Gets the SpreadSheet command.</summary>
        ///
        /// <value>The SpreadSheet command.</value>
        public DelegateCommand CheckChangedCommand { get; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="MultiCopiesChecked"/>
        /// </summary>
        public bool MultiCopiesChecked
        {
            get => this.switchOn;
            set => this.SetProperty(ref this.switchOn, value);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Let subscribers now of a change
        /// </summary>
        private void OnCheckChangedCommand() => 
            this.eventAggregator.GetEvent<MultipleCopiesChangesEvent>().Publish(this.MultiCopiesChecked);

        /// <summary>Executes the multiple copies command action.</summary>
        private void ShowMultipleCopiesView()
        {
            var multiDialog = (MetroWindow)this.unityContainer.Resolve(typeof(MultipleCopiesView));
            multiDialog.ShowDialog();
        }

        /// <summary>Closes multiple copies dialog.</summary>
        private async void CloseMultipleCopiesView()
        {
            if (this.customDialog != null)
            {
                await this.dialogCoordinator.HideMetroDialogAsync(this, this.customDialog);
            }

            // Reset
            this.customDialog = null;
        }

        /// <summary>Determine if we can draw command.</summary>
        ///
        /// <remarks>Assume we can for now, look to implement some verification</remarks>
        ///
        /// <returns>True if we can draw command, false if not.</returns>
        private bool CanDrawCommand() => true;

        /// <summary>Executes the draw command action.</summary>
        ///
        /// <remarks>Mick George, 11/16/2017.</remarks>
        private void OnDrawCommand() => this.eventAggregator.GetEvent<CreateDoorEvent>().Publish();

        /// <summary>Executes the exit command action.</summary>
        ///
        /// <remarks>Mick George, 11/5/2017.</remarks>
        private void OnExitCommand() => this.eventAggregator.GetEvent<ExitAppEvent>().Publish(false);

        /// <summary>Executes the load command action.</summary>
        ///
        /// <remarks>Mick George, 11/5/2017.</remarks>
        private void OnLoadCommand() => this.eventAggregator.GetEvent<LoadDoorStyleEvent>().Publish();

        /// <summary>Executes the save command action.</summary>
        ///
        /// <remarks>Mick George, 11/5/2017.</remarks>
        private void OnSaveCommand() => this.eventAggregator.GetEvent<SaveDoorStyleEvent>().Publish();

        #endregion
    }
}