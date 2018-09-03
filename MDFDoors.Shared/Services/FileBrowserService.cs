// <copyright file="FileBrowserService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Localization;
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
                dlg.Title = ApplicationStrings.LoadDoorStyle;

                switch (dlg.ShowDialog())
                {
                    case DialogResult.OK:
                        return Result.Ok(dlg.FileName);
                    default:
                        return Result.Fail<string>(Enum.GetName(typeof(ApplicationState), ApplicationState.UserCancelledDialog));
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
                dlg.Title = ApplicationStrings.SaveDoorStyle;

                switch (dlg.ShowDialog())
                {
                    case DialogResult.OK:
                        return Result.Ok(dlg.FileName);
                    default:
                        return Result.Fail<string>(Enum.GetName(typeof(ApplicationState), ApplicationState.UserCancelledDialog));
                }
            }
        }

        /// <summary>
        /// Prompts for a CVS file containing list of doors to create
        /// </summary>
        /// <returns>The path to the file</returns>
        public Result<string> SelectExcelFile()
        {
            using (var dlg = new OpenFileDialog())
            {
                // F:\Users\Public\Documents\shared Mcam2018\router\Template
                dlg.InitialDirectory = Path.Combine(SettingsManager.SharedDirectory, "router\\Template");
                dlg.Filter = @"Excel (*.csv)|*.csv";
                dlg.CheckFileExists = true;
                dlg.Multiselect = false;
                dlg.Title = ApplicationStrings.SelectCSVFile;

                switch (dlg.ShowDialog())
                {
                    case DialogResult.OK:
                        return Result.Ok(dlg.FileName);
                    default:
                        return Result.Fail<string>("user cancelled");
                }
            }
        }
    }
}