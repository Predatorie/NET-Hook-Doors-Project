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

        /// <summary>
        /// Backing field for the OuterLevelNumber
        /// </summary>
        private int outerLevelNumber;

        /// <summary>
        /// Backing field for the InnerLevelNumber
        /// </summary>
        private int innerLevelNumber;

        /// <summary>
        /// Backing field for the GrooveLevelNumber
        /// </summary>
        private int grooveLevelNumber;

        public ShakerEleganceViewModel()
        {   
            // Initial setup
            this.OuterLevelNumber = 1;
            this.InnerLevelNumber = 10;
            this.GrooveLevelNumber = 20;
        }

        /// <summary>
        /// Gets or sets the DoorType property
        /// </summary>
        public string DoorType
        {
            get => this.doorType;
            set => this.SetProperty(ref this.doorType, value);
        }

        public int OuterLevelNumber
        {
            get => this.outerLevelNumber;
            set => this.SetProperty(ref this.outerLevelNumber, value);
        }

        public int InnerLevelNumber
        {
            get => this.innerLevelNumber;
            set => this.SetProperty(ref this.innerLevelNumber, value);
        }

        public int GrooveLevelNumber
        {
            get => this.grooveLevelNumber;
            set => this.SetProperty(ref this.grooveLevelNumber, value);
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
