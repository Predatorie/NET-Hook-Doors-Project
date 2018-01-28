// <copyright file="MultipleCopiesData.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Models
{
    public class MultipleCopiesData : CopiesData
    {
        /// <summary>Gets or sets the steps.</summary>
        public int XSteps { get; set; }

        /// <summary>Gets or sets the steps.</summary>
        public int YSteps { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the UseSteps
        /// </summary>
        public bool UseSteps { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the UseExcel
        /// </summary>
        public bool UseExcel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the Excel
        /// </summary>
        public string Excel { get; set; }
    }
}