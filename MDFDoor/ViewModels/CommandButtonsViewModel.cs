// <copyright file="CommandButtonsViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.ViewModels
{
    using MahApps.Metro.Controls.Dialogs;
    using Views;
    using Microsoft.Practices.Unity;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;
    using Shared.Events;

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

        #endregion

        #region Construction

        /// <summary>Constructor.</summary>
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
        }

        #endregion

        #region Public Commands

        /// <summary>Gets or sets the save command.</summary>
        ///
        /// <value>The save command.</value>
        public DelegateCommand SaveCommand { get; private set; }

        /// <summary>Gets or sets the load command.</summary>
        ///
        /// <value>The load command.</value>
        public DelegateCommand LoadCommand { get; private set; }

        /// <summary>Gets or sets the exite command.</summary>
        ///
        /// <value>The exite command.</value>
        public DelegateCommand ExitCommand { get; private set; }

        /// <summary>Gets or sets the draw command.</summary>
        ///
        /// <value>The draw command.</value>
        public DelegateCommand DrawCommand { get; private set; }

        /// <summary>Gets or sets the multiple copies command.</summary>
        ///
        /// <value>The multiple copies command.</value>
        public DelegateCommand MultipleCopiesCommand { get; private set; }

        #endregion

        #region Private Methods

        /// <summary>Executes the multiple copies command action.</summary>
        private async void ShowMultipleCopiesView()
        {
            this.customDialog = new CustomDialog();
            var multiDialog = this.unityContainer.Resolve(typeof(MultipleCopiesView));

            this.customDialog.Content = multiDialog;
            await this.dialogCoordinator.ShowMetroDialogAsync(this, this.customDialog);
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