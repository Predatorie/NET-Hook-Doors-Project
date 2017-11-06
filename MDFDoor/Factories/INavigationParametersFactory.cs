// <copyright file="INavigationParametersFactory.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

using MDFDoors.Module;

namespace MDFDoors.Factories
{
    using Prism.Regions;

    public interface INavigationParametersFactory
    {
        /// <summary>
        /// Creates a NavigationParamters payload from the uri
        /// </summary>
        /// <param name="style">The door style we are navigation to</param>
        /// <returns>A NavigationParameter</returns>
        NavigationParameters Create(DoorStyles style);

        /// <summary>
        /// Gets the views uri to navigate too
        /// </summary>
        /// <param name="door">The door type</param>
        /// <returns>The uri to the view</returns>
        string View(DoorStyles door);
    }
}
