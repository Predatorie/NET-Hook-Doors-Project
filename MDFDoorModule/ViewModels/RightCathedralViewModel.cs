// <copyright file="RightCathedralViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace ModuleDoors.ViewModels
{
    using Models;
    using Services;
    using Prism.Regions;

    public class RightCathedralViewModel : BaseDoor, INavigationAware
    {
        private readonly IDoorPropertyManager defaultsManager;

        public RightCathedralViewModel(IDoorPropertyManager defaultsManager)
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