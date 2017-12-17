// <copyright file="IGeometryCreationService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    using Models;

    public interface IGeometryCreationService
    {
        Result CreateDoor(object model);

        Result CreateDoorMultipleCopies(object model, MultipleCopiesData data);

        Result CreateDoorMultipleCopiesExcel(object model, ExcelData data);
    }
}