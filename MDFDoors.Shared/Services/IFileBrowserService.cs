// <copyright file="IFileBrowserService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    using Models;

    public interface IFileBrowserService
    {
        Result<string> SelectDoorStyleSettingsFile();

        Result<string> SaveDoorStyleSettingsFile();
    }
}