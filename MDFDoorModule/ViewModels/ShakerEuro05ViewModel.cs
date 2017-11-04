﻿// <copyright file="ShakerEuro05ViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace ModuleDoors.ViewModels
{
    using Models;
    using Prism.Regions;

    public class ShakerEuro05ViewModel : BaseDoor, INavigationAware
    {
        public ShakerEuro05ViewModel()
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
