// <copyright file="IDoorController.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

using MDFDoors.Module;

namespace MDFDoors.Controller
{
    using Models;

    public interface IDoorController
    {
        /// <summary>Creates a door.</summary>
        ///
        /// <param name="style">The door style.</param>
        ///
        /// <returns>A Result</returns>
        Result CreateDoor(DoorStyles style);
    }
}