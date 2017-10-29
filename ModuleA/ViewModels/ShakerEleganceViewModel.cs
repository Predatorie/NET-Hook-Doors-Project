// <copyright file="ShakerEleganceViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace ModuleDoors.ViewModels
{
    using System.Linq;
    using Prism.Mvvm;
    using Prism.Regions;

    public class ShakerEleganceViewModel : BindableBase, INavigationAware
    {
        /// <summary>
        /// Backing field for the DoorType
        /// </summary>
        private string doorType;

        public ShakerEleganceViewModel()
        {           
        }

        /// <summary>
        /// Gets or sets the DoorType property
        /// </summary>
        public string DoorType
        {
            get => this.doorType;
            set => this.SetProperty(ref this.doorType, value);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.Any())
            {
                this.DoorType = navigationContext.Parameters["Name"].ToString();
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
