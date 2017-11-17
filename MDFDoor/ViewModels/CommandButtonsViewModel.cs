// <copyright file="CommandButtonsViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.ViewModels
{
    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;
    using Shared.Events;

    public class CommandButtonsViewModel : BindableBase
    {
        #region Private Fields

        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        #endregion

        #region Construction

        /// <summary>Constructor.</summary>
        ///
        /// <remarks>Mick George, 11/5/2017.</remarks>
        ///
        /// <param name="eventAggregator">The event aggregator.</param>
        public CommandButtonsViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.SaveCommand = new DelegateCommand(this.OnSaveCommand);
            this.LoadCommand = new DelegateCommand(this.OnLoadCommand);
            this.ExitCommand = new DelegateCommand(this.OnExitCommand);
            this.DrawCommand = new DelegateCommand(this.OnDrawCommand, this.CanDrawCommand);
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

        #endregion

        #region Private Methods


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