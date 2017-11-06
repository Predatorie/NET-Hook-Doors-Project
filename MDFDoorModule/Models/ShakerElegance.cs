// <copyright file="ShakerElegance.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module.Models
{
    using Shared;

    /// <summary>Describes the shaker elegance class</summary>
    ///
    /// <remarks>Mick George, 11/4/2017.</remarks>
    public class ShakerElegance : BaseDoor
    {
        #region Private Backing Fields

        /// <summary>Width of the top rail.</summary>
        private double topRailWidth;

        /// <summary>Width of the bottom rail.</summary>
        private double bottomRailWidth;

        /// <summary>Width of the left stile.</summary>
        private double leftStileWidth;

        /// <summary>Width of the right side.</summary>
        private double rightSideWidth;

        /// <summary>The groove level number.</summary>
        private int grooveLevelNumber;

        /// <summary>Name of the groove level.</summary>
        private string grooveLevelName;

        #endregion
        
        #region Public Properties

        /// <summary>Gets or sets the groove level number.</summary>
        ///
        /// <value>The groove level number.</value>
        public int GrooveLevelNumber
        {
            get => this.grooveLevelNumber;
            set => this.SetProperty(ref this.grooveLevelNumber, value);
        }

        /// <summary>Gets or sets the name of the groove level.</summary>
        ///
        /// <value>The name of the groove level.</value>
        public string GrooveLevelName
        {
            get => this.grooveLevelName;
            set => this.SetProperty(ref this.grooveLevelName, value);
        }

        /// <summary>Gets or sets the width of the top rail.</summary>
        ///
        /// <value>The width of the top rail.</value>
        public double TopRailWidth
        {
            get => this.topRailWidth;
            set => this.SetProperty(ref this.topRailWidth, value);
        }

        /// <summary>Gets or sets the width of the bottom rail.</summary>
        ///
        /// <value>The width of the bottom rail.</value>
        public double BottomRailWidth
        {
            get => this.bottomRailWidth;
            set => this.SetProperty(ref this.bottomRailWidth, value);
        }

        /// <summary>Gets or sets the width of the left stile.</summary>
        ///
        /// <value>The width of the left stile.</value>
        public double LeftStileWidth
        {
            get => this.leftStileWidth;
            set => this.SetProperty(ref this.leftStileWidth, value);
        }

        /// <summary>Gets or sets the width of the right side.</summary>
        ///
        /// <value>The width of the right side.</value>
        public double RightSideWidth
        {
            get => this.rightSideWidth;
            set => this.SetProperty(ref this.rightSideWidth, value);
        }

        /// <summary>Convert this object into a string representation.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        ///
        /// <returns>A string that represents this object.</returns>
        public override string ToString() => DoorNames.ShakerElegance;

        #endregion
    }
}