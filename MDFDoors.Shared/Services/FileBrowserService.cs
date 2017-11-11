// <copyright file="FileBrowserService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    using System.Windows.Forms;
    using Mastercam.IO;
    using Models;

    public class FileBrowserService : IFileBrowserService
    {
        /// <summary>Select door style settings file.</summary>
        /// <returns>A Result&lt;string&gt;</returns>
        public Result<string> SelectDoorStyleSettingsFile()
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = SettingsManager.SharedDirectory;
                dlg.Filter = @"Door Style (*.xml)|*.xml";
                dlg.CheckFileExists = true;
                dlg.Multiselect = false;

                switch (dlg.ShowDialog())
                {
                    case DialogResult.OK:
                        return Result.Ok(dlg.FileName);
                    default:
                        return Result.Fail<string>(string.Empty);
                }
            }
        }

        /// <summary>Saves the door style settings file.</summary>
        /// <returns>A Result.</returns>
        public Result<string> SaveDoorStyleSettingsFile()
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.CreatePrompt = true;
                dlg.OverwritePrompt = true;
                dlg.InitialDirectory = SettingsManager.SharedDirectory;
                dlg.Filter = @"Door Style (*.xml)|*.xml";

                switch (dlg.ShowDialog())
                {
                    case DialogResult.OK:
                        return Result.Ok(dlg.FileName);
                    default:
                        return Result.Fail<string>(string.Empty);
                }
            }
        }
    }
}