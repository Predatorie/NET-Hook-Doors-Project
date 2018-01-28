// <copyright file="BaseDoor.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

using MDFDoors.Shared.Models;

namespace MDFDoors.Module.Models
{
    /// <summary>A base door.</summary>
    ///
    /// <remarks>Mick George, 11/4/2017.</remarks>
    public class BaseDoor
    {
        #region Public Properties

        /// <summary>Gets or sets the height.</summary>
        ///
        /// <value>The height.</value>
        public double Height { get; set; }

        /// <summary>Gets or sets the width.</summary>
        ///
        /// <value>The width.</value>
        public double Width { get; set; }

        /// <summary>Gets or sets the outer level number.</summary>
        ///
        /// <value>The outer level number.</value>
        public int OuterLevelNumber { get; set; }

        /// <summary>Gets or sets the inner level number.</summary>
        ///
        /// <value>The inner level number.</value>
        public int InnerLevelNumber { get; set; }

        /// <summary>Gets or sets the name of the outer level.</summary>
        ///
        /// <value>The name of the outer level.</value>
        public string OuterLevelName { get; set; }

        /// <summary>Gets or sets the name of the inner level.</summary>
        ///
        /// <value>The name of the inner level.</value>
        public string InnerLevelName { get; set; }

        /// <summary>
        /// Gets or sets the MultipleCopies property
        /// </summary>
        public MultipleCopiesData MultipleCopies { get; set; } = new MultipleCopiesData();

        #endregion
    }
}