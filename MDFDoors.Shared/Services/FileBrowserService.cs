// <copyright file="FileBrowserService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    using Models;

    public class FileBrowserService : IFileBrowserService
    {
        /// <summary>Select door style settings file.</summary>
        /// <returns>A Result&lt;string&gt;</returns>
        public Result<string> SelectDoorStyleSettingsFile()
        {
            // TODO: Implement
            return Result.Ok(string.Empty);
        }
    }
}