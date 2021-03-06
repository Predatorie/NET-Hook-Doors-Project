﻿// <copyright file="ShakerFinestViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module.ViewModels
{
    using Models;
    using Prism.Regions;

    public class ShakerFinestViewModel : BaseDoor, INavigationAware
    {
        public void OnNavigatedTo(NavigationContext navigationContext) { }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext) { }
    }
}
