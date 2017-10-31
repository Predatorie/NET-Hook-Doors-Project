// <copyright file="ModuleDoorModule.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace ModuleDoors
{
    using Microsoft.Practices.Unity;
    using Views;
    using Prism.Modularity;
    using Prism.Unity;

    public class ModuleDoorModule : IModule
    {
        private readonly IUnityContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleDoorModule"/> class.
        /// </summary>
        /// <param name="container">The IUnityContainer instance</param>
        public ModuleDoorModule(IUnityContainer container) => this.container = container;

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
        }
    }
}