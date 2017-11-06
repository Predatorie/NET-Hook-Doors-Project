// <copyright file="DoorStylesMenuViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.ViewModels
{
    using Factories;
    using Shared.Factories;
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;
    using Shared;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A ViewModel for the door styles menu. </summary>
    ///
    /// <remarks>   Mick George, 11/3/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DoorStylesMenuViewModel : BindableBase
    {
        #region Private Fields

        /// <summary>
        /// Backing field for the Region Manager
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary> The view factory. </summary>
        private readonly IViewFactory viewFactory;

        /// <summary>
        /// Backing field for the Navigation Parameters Factory
        /// </summary>
        private readonly INavigationParametersFactory navigationParamsFactory;

        #endregion

        #region Construction

        /// <summary> Initializes a new instance of the MDFDoors.ViewModels.DoorStylesMenuViewModel class. </summary>
        ///
        /// <param name="navigationParametersFactory"> The navigation parameters factory. </param>
        /// <param name="regionManager">			   Backing field for the Region Manager. </param>
        /// <param name="viewFactory">				   The IViewFactory. </param>
        public DoorStylesMenuViewModel(
            INavigationParametersFactory navigationParametersFactory,
            IRegionManager regionManager,
            IViewFactory viewFactory)
        {
            this.navigationParamsFactory = navigationParametersFactory;
            this.regionManager = regionManager;
            this.viewFactory = viewFactory;
            this.NavigateCommand = new DelegateCommand<object>(this.Navigate);

            this.AddViewsToRegion();
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// The Navigate Command
        /// </summary>
        public DelegateCommand<object> NavigateCommand { get; private set; }

        #endregion

        #region Private Methods

        /// <summary> Navigates the given style. </summary>
        ///
        /// <param name="style"> The style. </param>
        private void Navigate(object style)
        {
            var door = (DoorStyles)style;
            var viewName = this.navigationParamsFactory.View(door);
            var navigationParams = this.navigationParamsFactory.Create(door);

            this.regionManager.Regions[Regions.ContentRegion].RequestNavigate(viewName, this.NavigationCompleted, navigationParams);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Navigation completed. </summary>
        ///
        /// <remarks>   Mick George, 11/3/2017. </remarks>
        ///
        /// <param name="result">   The result. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void NavigationCompleted(NavigationResult result)
        {
            if (result.Error != null)
            {
                // TODO: Error occured...
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds views to region. </summary>
        ///
        /// <remarks>   Mick George, 11/3/2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void AddViewsToRegion()
        {
            var contentRegion = this.regionManager.Regions[Regions.ContentRegion];
            contentRegion.Add(this.viewFactory.View(DoorStyles.ShakerCentury).Value, ViewNames.ShakerCentury, true);
            contentRegion.Add(this.viewFactory.View(DoorStyles.ShakerCountry).Value, ViewNames.ShakerCountry, true);
            contentRegion.Add(this.viewFactory.View(DoorStyles.ShakerElegance).Value, ViewNames.ShakerElegance, true);
            contentRegion.Add(this.viewFactory.View(DoorStyles.ShakerEuro05).Value, ViewNames.ShakerEuro05, true);
            contentRegion.Add(this.viewFactory.View(DoorStyles.ShakerExotic).Value, ViewNames.ShakerExotic, true);
            contentRegion.Add(this.viewFactory.View(DoorStyles.ShakerFinest).Value, ViewNames.ShakerFinest, true);
            contentRegion.Add(this.viewFactory.View(DoorStyles.Shaker).Value, ViewNames.Shaker, true);
        }

        #endregion
    }
}