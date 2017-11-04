// <copyright file="SettingsViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.ViewModels
{
    using ModuleDoors.Services;
    using Prism.Mvvm;

    public class SettingsViewModel : BindableBase
    {
        /// <summary>   Manager for defaults. </summary>
        private readonly IDefaultsManager defaultsManager;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Mick George, 11/3/2017. </remarks>
        ///
        /// <param name="defaultsManager">  Manager for defaults. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SettingsViewModel(IDefaultsManager defaultsManager)
        {
            // Used to set default settings
            this.defaultsManager = defaultsManager;
        }
    }
}
