// <copyright file="SettingsService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Services
{
    using Properties;
    using Shared.Models;
    using Shared.Services;

    public class SettingsService : ISettingsService
    {
        public MultipleCopiesData MultipleCopiesData()
        {
            var data = new MultipleCopiesData
            {
                UseExcel = Settings.Default.UseExcel,
                UseSteps = Settings.Default.UseSteps,
                XSteps = Settings.Default.XSteps,
                YSteps = Settings.Default.YSteps,
                XDistanceBetween = Settings.Default.XDistanceBetween,
                YDistanceBetween = Settings.Default.YDistanceBetween,
                Excel = Settings.Default.Excel
            };

            return data;
        }

        public void SaveMultipleCopiesData(MultipleCopiesData data)
        {
            Settings.Default.UseExcel = data.UseExcel;
            Settings.Default.UseSteps = data.UseSteps;
            Settings.Default.XSteps = data.XSteps;
            Settings.Default.YSteps = data.YSteps;
            Settings.Default.XDistanceBetween = data.XDistanceBetween;
            Settings.Default.YDistanceBetween = data.YDistanceBetween;
            Settings.Default.Excel = data.Excel;

            Settings.Default.Save();
        }
    }
}