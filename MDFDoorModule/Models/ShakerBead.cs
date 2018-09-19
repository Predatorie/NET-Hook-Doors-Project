// <copyright file="ShakerBead.cs" company="MyCompany.com">
// Copyright (c) 2018 CNC Software. All rights reserved.
// </copyright>
// <author>MG</author>
// <date>9/19/2018</date>
// <summary>Implements the shaker bead class</summary>

namespace MDFDoors.Module.Models
{
    using MDFDoors.Shared;

    public class ShakerBead : BaseDoor
    {
        #region Public Properties

        /// <summary>Gets or sets the groove level number.</summary>
        ///
        /// <value>The groove level number.</value>
        public int GrooveLevelNumber { get; set; }

        /// <summary>Gets or sets the name of the groove level.</summary>
        ///
        /// <value>The name of the groove level.</value>
        public string GrooveLevelName { get; set; }

        /// <summary>Gets or sets the width of the top rail.</summary>
        ///
        /// <value>The width of the top rail.</value>
        public double TopRailWidth { get; set; }

        /// <summary>Gets or sets the width of the bottom rail.</summary>
        ///
        /// <value>The width of the bottom rail.</value>
        public double BottomRailWidth { get; set; }

        /// <summary>Gets or sets the width of the left stile.</summary>
        ///
        /// <value>The width of the left stile.</value>
        public double LeftStileWidth { get; set; }

        /// <summary>Gets or sets the width of the right side.</summary>
        ///
        /// <value>The width of the right side.</value>
        public double RightSideWidth { get; set; }

        /// <summary> Gets or sets the bead spacing. </summary>
        ///
        /// <value> The bead spacing. </value>
        public double BeadSpacing { get; set; }

        /// <summary>Gets width of the inner.</summary>
        public double InnerWidth => this.Width - (this.LeftStileWidth + this.RightSideWidth);

        /// <summary>Gets height of the inner.</summary>
        public double InnerHeight => this.Height - (this.TopRailWidth + this.BottomRailWidth);

        /// <summary>Gets the style.</summary>
        public DoorStyles Style => DoorStyles.ShakerBead;

        /// <summary> Gets or sets the name of the bead level. </summary>
        ///
        /// <value> The name of the bead level. </value>
        public string BeadLevelName { get; set; }

        /// <summary> Gets or sets the bead level number. </summary>
        ///
        /// <value> The bead level number. </value>
        public int BeadLevelNumber { get; set; }

        /// <summary>Convert this object into a string representation.</summary>
        ///
        /// <remarks>Mick George, 11/11/2017.</remarks>
        ///
        /// <returns>A string that represents this object.</returns>
        public override string ToString() => DoorNames.ShakerBead;

        #endregion
    }
}