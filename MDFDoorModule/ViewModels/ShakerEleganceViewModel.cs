// <copyright file="ShakerEleganceViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace ModuleDoors.ViewModels
{
    using System.Linq;
    using Models;
    using Services;
    using Prism.Regions;

    public class ShakerEleganceViewModel : BaseDoor, INavigationAware
    {
        #region Fields

        /// <summary>   Manager for defaults. </summary>
        private readonly IDefaultsManager defaultsManager;

        /// <summary>
        /// Backing field for the C Dimension
        /// </summary>
        private double c;

        /// <summary>
        /// Backing field for the D Dimension
        /// </summary>
        private double d;

        /// <summary>
        /// Backing field for the E Dimension
        /// </summary>
        private double e;

        /// <summary>
        /// Backing field for the F Dimension
        /// </summary>
        private double f;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ShakerEleganceViewModel"/> class.
        /// 
        /// </summary>
        public ShakerEleganceViewModel(IDefaultsManager defaultsManager)
        {
            this.defaultsManager = defaultsManager;

            // TODO: Temp Initial setup

            // Dimensions
            this.Height = 20;
            this.Width = 16;
            this.TopRailWidth = 2;
            this.BottomRailWidth = 2;
            this.LeftStileWidth = 2;
            this.RightSideWidth = 2;

            // Level numbers
            this.OuterLevelNumber = 1;
            this.InnerLevelNumber = 10;
            this.GrooveLevelNumber = 20;

            // Level names
            this.OuterLevelName = "Outside";
            this.InnerLevelName = "Inner";
            this.GrooveLevelName = "Groove";
        }

        #endregion

        #region Public Properties

        public double TopRailWidth
        {
            get => this.c;
            set => this.SetProperty(ref this.c, value);
        }

        public double BottomRailWidth
        {
            get => this.d;
            set => this.SetProperty(ref this.d, value);
        }

        public double LeftStileWidth
        {
            get => this.e;
            set => this.SetProperty(ref this.e, value);
        }

        public double RightSideWidth
        {
            get => this.f;
            set => this.SetProperty(ref this.f, value);
        }
       
        #endregion

        #region Public Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the navigated to action. </summary>
        /// <param name="navigationContext">    Context for the navigation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // TODO: Get defaults for this door
            
            // Read params passed
            if (navigationContext.Parameters.Any())
            {
                this.DoorType = navigationContext.Parameters["Name"].ToString();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'navigationContext' is navigation target. </summary>
        /// <param name="navigationContext">    Context for the navigation. </param>
        /// <returns>   True if navigation target, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the navigated from action. </summary>
        /// <param name="navigationContext">    Context for the navigation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // TODO: Any clean up
        }

        #endregion
    }
}
