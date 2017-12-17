// <copyright file="MultipleCopiesData.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Models
{
    public class MultipleCopiesData : CopiesData
    {
        /// <summary>Gets or sets the steps.</summary>
        ///
        /// <value>The x coordinate steps.</value>
        public int XSteps { get; set; }

        /// <summary>Gets or sets the steps.</summary>
        ///
        /// <value>The y coordinate steps.</value>
        public int YSteps { get; set; }       
    }
}