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
        #region Fields

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

        /// <summary>
        /// Backing field for the A Dimension
        /// </summary>
        private double a;

        /// <summary>
        /// Backing field for the B Dimension
        /// </summary>
        private double b;

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

        /// <summary>
        /// Backing field for the Outside Level Name
        /// </summary>
        private string outside;

        /// <summary>
        /// Backing field for the Inside Level Name
        /// </summary>
        private string inside;

        /// <summary>
        /// Backing field for the Groove Level Name
        /// </summary>
        private string groove;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ShakerEleganceViewModel"/> class.
        /// 
        /// </summary>
        public ShakerEleganceViewModel()
        {
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

        public double Width
        {
            get => this.a;
            set => this.SetProperty(ref this.a, value);
        }

        public double Height
        {
            get => this.b;
            set => this.SetProperty(ref this.b, value);
        }

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

        public string OuterLevelName
        {
            get => this.outside;
            set => this.SetProperty(ref this.outside, value);
        }

        public string InnerLevelName
        {
            get => this.inside;
            set => this.SetProperty(ref this.inside, value);
        }

        public string GrooveLevelName
        {
            get => this.groove;
            set => this.SetProperty(ref this.groove, value);
        }

        #endregion

        #region Public Methods

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

        #endregion
    }
}
