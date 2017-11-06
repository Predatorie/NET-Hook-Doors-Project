// <copyright file="IDoorController.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Controller
{
    using Shared.Models;
    using Shared;

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