// <copyright file="ModuleDoorModule.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module
{
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;

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

        public void Initialize()
        {
            // TODO: Add anything we need
        }
    }
}