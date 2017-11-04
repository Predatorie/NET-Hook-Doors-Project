﻿// <copyright file="ShakerFinestViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace ModuleDoors.ViewModels
{
    using Models;
    using Prism.Regions;

    public class ShakerFinestViewModel : BaseDoor, INavigationAware
    {
        public ShakerFinestViewModel()
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
