// <copyright file="DoorController.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Controller
{
    using Models;
    using ModuleDoors;

	public class DoorController : IDoorController
	{
        /// <summary>Creates a door.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        ///
        /// <param name="style">The Door Style.</param>
        ///
        /// <returns>The new door.</returns>
	    public Result CreateDoor(DoorStyles style)
	    {
	        return Result.Ok();
	    }
	}
}   