// <copyright file="ModuleDoorModule.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace ModuleDoors
{
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;
    using Views;

    public class ModuleDoorModule : IModule
    {
        #region Fields

        /// <summary>
        /// The region manager.
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The unity container
        /// </summary>
        private readonly IUnityContainer container;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleDoorModule"/> class.
        /// </summary>
        /// <param name="container">The IUnityContainer instance</param>
        /// <param name="regionManager">The IRegionManager instance</param>
        public ModuleDoorModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Register our types
        /// </summary>
        public void Initialize()
        {
            // Mastercam Styles
            this.container.RegisterTypeForNavigation<ArchView>();
            this.container.RegisterTypeForNavigation<CathedralView>();
            this.container.RegisterTypeForNavigation<LeftCathedralView>();
            this.container.RegisterTypeForNavigation<LeftRomanView>();
            this.container.RegisterTypeForNavigation<RightCathedralView>();
            this.container.RegisterTypeForNavigation<RightRomanView>();
            this.container.RegisterTypeForNavigation<RomanView>();
            this.container.RegisterTypeForNavigation<NotchView>();
            this.container.RegisterTypeForNavigation<RectangularView>();
            this.container.RegisterTypeForNavigation<SimpleRectangleView>();

            // Shaker Styles
            this.container.RegisterTypeForNavigation<ShakerCenturyView>();
            this.container.RegisterTypeForNavigation<ShakerCountryView>();
            this.container.RegisterTypeForNavigation<ShakerEleganceView>();
            this.container.RegisterTypeForNavigation<ShakerEuro05View>();
            this.container.RegisterTypeForNavigation<ShakerExoticView>();
            this.container.RegisterTypeForNavigation<ShakerFinestView>();
            this.container.RegisterTypeForNavigation<ShakerView>();

            // Raised Panel Styles
            this.container.RegisterTypeForNavigation<RaisedPanelRCenturyView>();
            this.container.RegisterTypeForNavigation<RaisedPanelRClassicView>();
            this.container.RegisterTypeForNavigation<RaisedPanelREuro08View>();
            this.container.RegisterTypeForNavigation<RaisedPanelRShakerView>();

            // Anything placed in a region in this manner will not be added to the navigation journal.            
            this.regionManager.RegisterViewWithRegion(Regions.SettingsRegion, typeof(SettingsView));
        }

        #endregion
    }
}