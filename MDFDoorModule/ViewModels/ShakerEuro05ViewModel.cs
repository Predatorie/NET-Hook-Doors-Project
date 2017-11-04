// <copyright file="ShakerEuro05ViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace ModuleDoors.ViewModels
{
    using Models;
    using ModuleDoors.Services;
    using Prism.Regions;

    public class ShakerEuro05ViewModel : BaseDoor, INavigationAware
    {
        private readonly IDoorPropertyManager defaultsManager;

        public ShakerEuro05ViewModel(IDoorPropertyManager defaultsManager)
        {
            this.defaultsManager = defaultsManager;
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
