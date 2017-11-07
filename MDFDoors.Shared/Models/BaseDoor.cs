// <copyright file="BaseDoor.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Models
{
    using Prism.Mvvm;

    /// <summary>A base door.</summary>
    ///
    /// <remarks>Mick George, 11/4/2017.</remarks>
    public class BaseDoor : BindableBase
    {
        #region Private Backing Fields

        /// <summary>The height.</summary>
        private double height;

        /// <summary>The width.</summary>
        private double width;

        /// <summary>The outer level number.</summary>
        private int outerLevelNumber;

        /// <summary>The inner level number.</summary>
        private int innerLevelNumber;

        /// <summary>Name of the outer level.</summary>
        private string outerLevelName;

        /// <summary>Name of the inner level.</summary>
        private string innerLevelName;

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the height.</summary>
        ///
        /// <value>The height.</value>
        public double Height
        {
            get => this.height;
            set => this.SetProperty(ref this.height, value);
        }

        /// <summary>Gets or sets the width.</summary>
        ///
        /// <value>The width.</value>
        public double Width
        {
            get => this.width;
            set => this.SetProperty(ref this.width, value);
        }

        /// <summary>Gets or sets the outer level number.</summary>
        ///
        /// <value>The outer level number.</value>
        public int OuterLevelNumber
        {
            get => this.outerLevelNumber;
            set => this.SetProperty(ref this.outerLevelNumber, value);
        }

        /// <summary>Gets or sets the inner level number.</summary>
        ///
        /// <value>The inner level number.</value>
        public int InnerLevelNumber
        {
            get => this.innerLevelNumber;
            set => this.SetProperty(ref this.innerLevelNumber, value);
        }

        /// <summary>Gets or sets the name of the outer level.</summary>
        ///
        /// <value>The name of the outer level.</value>
        public string OuterLevelName
        {
            get => this.outerLevelName;
            set => this.SetProperty(ref this.outerLevelName, value);
        }

        /// <summary>Gets or sets the name of the inner level.</summary>
        ///
        /// <value>The name of the inner level.</value>
        public string InnerLevelName
        {
            get => this.innerLevelName;
            set => this.SetProperty(ref this.innerLevelName, value);
        }

        #endregion
    }
}