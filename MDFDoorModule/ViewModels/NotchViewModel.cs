﻿// <copyright file="NotchViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

using MDFDoors.Module.Models;

namespace MDFDoors.Module.ViewModels
{
    using Shared.Models;
    using Prism.Regions;

    public class NotchViewModel : BaseDoor, INavigationAware
    {
        public void OnNavigatedTo(NavigationContext navigationContext) { }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext) { }
    }
}