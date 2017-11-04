// <copyright file="BaseDoor.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace ModuleDoors.Models
{
    using Prism.Mvvm;
    using Prism.Regions;

    public class BaseDoor : BindableBase, IRegionMemberLifetime
    {
        /// <summary>
        /// Backing field for the DoorType
        /// </summary>
        private string doorType;

        /// <summary>
        /// Backing field for the A Dimension
        /// </summary>
        private double a;

        /// <summary>
        /// Backing field for the B Dimension
        /// </summary>
        private double b;

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

        /// <summary>   True to keep alive. </summary>
        public bool KeepAlive => true;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the door. </summary>
        ///
        /// <value> The type of the door. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string DoorType
        {
            get => this.doorType;
            set => this.SetProperty(ref this.doorType, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the width. </summary>
        ///
        /// <value> The width. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public double Width
        {
            get => this.a;
            set => this.SetProperty(ref this.a, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the height. </summary>
        ///
        /// <value> The height. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public double Height
        {
            get => this.b;
            set => this.SetProperty(ref this.b, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the outer level number. </summary>
        ///
        /// <value> The outer level number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int OuterLevelNumber
        {
            get => this.outerLevelNumber;
            set => this.SetProperty(ref this.outerLevelNumber, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the inner level number. </summary>
        ///
        /// <value> The inner level number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int InnerLevelNumber
        {
            get => this.innerLevelNumber;
            set => this.SetProperty(ref this.innerLevelNumber, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the groove level number. </summary>
        ///
        /// <value> The groove level number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int GrooveLevelNumber
        {
            get => this.grooveLevelNumber;
            set => this.SetProperty(ref this.grooveLevelNumber, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the outer level./ </summary>
        ///
        /// <value> The name of the outer level. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string OuterLevelName
        {
            get => this.outside;
            set => this.SetProperty(ref this.outside, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the inner level. </summary>
        ///
        /// <value> The name of the inner level. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string InnerLevelName
        {
            get => this.inside;
            set => this.SetProperty(ref this.inside, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the groove level. </summary>
        ///
        /// <value> The name of the groove level. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GrooveLevelName
        {
            get => this.groove;
            set => this.SetProperty(ref this.groove, value);
        }
    }
}