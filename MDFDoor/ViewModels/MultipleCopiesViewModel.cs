// <copyright file="MultipleCopiesViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.ViewModels
{
    using System.Windows.Input;
    using MahApps.Metro.Controls.Dialogs;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;
    using Shared.Events;
    using Shared.Models;

    public class MultipleCopiesViewModel : BindableBase
    {
        #region Private Fields

        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>The dialog coordinator.</summary>
        private readonly IDialogCoordinator dialogCoordinator;

        /// <summary>The steps.</summary>
        private int xSteps;

        /// <summary>The steps.</summary>
        private int ySteps;

        /// <summary>The distance between.</summary>
        private int xDistanceBetween;

        /// <summary>The distance between.</summary>
        private int yDistanceBetween;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleCopiesViewModel"/> class.Constructor.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="coordinator">    The coordinator.</param>
        public MultipleCopiesViewModel(IEventAggregator eventAggregator, IDialogCoordinator coordinator)
        {
            this.eventAggregator = eventAggregator;
            this.dialogCoordinator = coordinator;

            this.XSteps = 1;
            this.YSteps = 2;
            this.xDistanceBetween = 1;
            this.YDistanceBetween = 1;

            this.OKCommand = new DelegateCommand(
                    this.OnOKCommand,
                    () =>
                        this.XSteps > 0 &&
                        this.YSteps > 0 &&
                        this.XDistanceBetween > 0 &&
                        this.YDistanceBetween > 0)
                .ObservesProperty(() => this.XSteps)
                .ObservesProperty(() => this.YSteps)
                .ObservesProperty(() => this.XDistanceBetween)
                .ObservesProperty(() => this.YDistanceBetween);

            this.CancelCommand = new DelegateCommand(this.OnCancelCommand);
        }

        #endregion

        #region Public Commands

        /// <summary>Gets the ok command.</summary>
        ///
        /// <value>The ok command.</value>
        public ICommand OKCommand { get; private set; }

        /// <summary>Gets the cancel command.</summary>
        ///
        /// <value>The cancel command.</value>
        public ICommand CancelCommand { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>Gets or sets the steps.</summary>
        ///
        /// <value>The x coordinate steps.</value>
        public int XSteps
        {
            get => this.xSteps;
            set => this.SetProperty(ref this.xSteps, value);
        }

        /// <summary>Gets or sets the steps.</summary>
        ///
        /// <value>The y coordinate steps.</value>
        public int YSteps
        {
            get => this.ySteps;
            set => this.SetProperty(ref this.ySteps, value);
        }

        public int XDistanceBetween
        {
            get => this.xDistanceBetween;
            set => this.SetProperty(ref this.xDistanceBetween, value);
        }

        public int YDistanceBetween
        {
            get => this.yDistanceBetween;
            set => this.SetProperty(ref this.yDistanceBetween, value);
        }

        #endregion

        #region Private Methods

        /// <summary>Executes the cancel command action.</summary>
        private void OnCancelCommand() => this.eventAggregator.GetEvent<CloseMultipleCopiesViewEvent>().Publish();

        /// <summary>Executes the ok command action.</summary>
        private void OnOKCommand()
        {
            var data = new MultipleCopiesData
            {
                XSteps = this.XSteps,
                YSteps = this.YSteps,
                XDistanceBetween = this.XDistanceBetween,
                YDistanceBetween = this.YDistanceBetween
            };

            // Pass the data to the applicable vm
            this.eventAggregator.GetEvent<DrawMultipleCopiesEvent>().Publish(data);

            // Close the dialog
            this.eventAggregator.GetEvent<CloseMultipleCopiesViewEvent>().Publish();
        }

        #endregion
    }
}
