// <copyright file="GeometryCreationService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    using Models;

    public class GeometryCreationService : IGeometryCreationService
    {
        /// <summary>Creates shaker elegance door.</summary>
        /// <param name="door">The door.</param>
        /// <returns>The new shaker elegance door.</returns>
        public Result CreateShakerEleganceDoor(ShakerElegance door)
        {
            return Result.Ok();
        }
    }
}