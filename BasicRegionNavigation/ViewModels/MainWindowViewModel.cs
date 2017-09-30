// <copyright file="MainWindowViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private string title = "MDF Doors";

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            this.NavigateCommand = new DelegateCommand<string>(this.Navigate);
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                this.regionManager.RequestNavigate("ContentRegion", navigatePath);
            }
        }
    }
}
