// <copyright file="ISettingsService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    using Models;

    public interface ISettingsService
    {
        MultipleCopiesData MultipleCopiesData();

        void SaveMultipleCopiesData(MultipleCopiesData data);
    }
}