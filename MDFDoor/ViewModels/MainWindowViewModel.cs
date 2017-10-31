// <copyright file="MainWindowViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

using MahApps.Metro.Controls;

namespace MDFDoors.ViewModels
{
    using Factories;
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class MainWindowViewModel : BindableBase
    {
        #region Private Fields

        /// <summary>
        /// Backing field for the Region Manager
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// Backing field for the Navigation Parameters Factory
        /// </summary>
        private readonly INavigationParametersFactory navigationParamsFactory;

        /// <summary>
        /// Backing field for the Title
        /// </summary>
        private string title = "MDF Doors";

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// 
        /// </summary>
        /// <param name="regionManager">The IRegionManager singleton</param>
        /// <param name="navigationParametersFactory">The INavigationParametersFactory singleton</param>
        public MainWindowViewModel(
            IRegionManager regionManager,
            INavigationParametersFactory navigationParametersFactory)
        {
            this.regionManager = regionManager;
            this.navigationParamsFactory = navigationParametersFactory;

            this.NavigateCommand = new DelegateCommand<object>(this.Navigate);
            this.SettingsCommand = new DelegateCommand<Flyout>(this.FlyOut);
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// The Navigate Command
        /// </summary>
        public DelegateCommand<object> NavigateCommand { get; private set; }

        /// <summary>
        /// The Settings Command
        /// </summary>
        public DelegateCommand<Flyout> SettingsCommand { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the Title property
        /// </summary>
        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Toggles the Fly Out Panel
        /// </summary>
        private void FlyOut(Flyout flyout) => flyout.IsOpen = !flyout.IsOpen;

        /// <summary>
        /// Navigates to the applicable view
        /// </summary>
        /// <param name="door">The door style enum</param>
        private void Navigate(object door)
        {
            var style = (DoorStyles)door;
            var view = this.navigationParamsFactory.View(style);
            var navigationParams = this.navigationParamsFactory.Create(style);
            this.regionManager.RequestNavigate(Regions.ContentRegion, view, navigationParams);
        }

        #endregion
    }
}
