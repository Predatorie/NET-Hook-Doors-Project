// <copyright file="MainWindowViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.ViewModels
{
    using Factories;
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private readonly INavigationParametersFactory navigationParamsFactory;

        private string title = "MDF Doors";

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// 
        /// </summary>
        /// <param name="regionManager">The IRegionManager singleton</param>
        /// <param name="navigationParametersFactory">The INavigationParametersFactory singleton</param>
        public MainWindowViewModel(
            IRegionManager regionManager,
            INavigationParametersFactory navigationParametersFactory)
        {
            this.regionManager = regionManager;
            this.navigationParamsFactory = navigationParametersFactory;

            this.NavigateCommand = new DelegateCommand<object>(this.Navigate);
            this.FlyOutCommand = new DelegateCommand(this.FlyOut);
        }

        public DelegateCommand<object> NavigateCommand { get; private set; }

        public DelegateCommand FlyOutCommand { get; private set; }

        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }

        private void FlyOut()
        {

        }

        private void Navigate(object door)
        {
            var style = (DoorStyles)door;
            var view = this.navigationParamsFactory.View(style);
            var navigationParams = this.navigationParamsFactory.Create(style);
            this.regionManager.RequestNavigate("ContentRegion", view, navigationParams);
        }
    }
}
