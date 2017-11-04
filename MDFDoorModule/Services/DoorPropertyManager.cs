// <copyright file="DefaultsManager.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace ModuleDoors.Services
{
    using Models;
    using Properties;

    public class DoorPropertyManager : IDoorPropertyManager
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="DoorPropertyManager"/> class.Specialised default constructor for use only by derived class.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        public DoorPropertyManager()
        {
           // this.Initialize();
        }

        #endregion

        #region Public Methods

        public ShakerElegance ShakerElegance { get; set; }

        /////// <summary>Saves default values to disk.</summary>
        ///////
        /////// <remarks>Mick George, 11/4/2017.</remarks>
        ////public void Save()
        ////{
        ////    Settings.Default.Height = this.Height;
        ////    Settings.Default.Width = this.Width;
        ////    Settings.Default.OuterLevelNumber = this.OuterLevelNumber;
        ////    Settings.Default.InnerLevelNumber = this.InnerLevelNumber;
        ////    Settings.Default.GrooveLevelNumber = this.GrooveLevelNumber;
        ////    Settings.Default.OuterLevelName = this.OuterLevelName;
        ////    Settings.Default.InnerLevelName = this.InnerLevelName;
        ////    Settings.Default.GrooveLevelName = this.GrooveLevelName;
        ////    Settings.Default.TopRailWidth = this.TopRailWidth;
        ////    Settings.Default.BottomRailWidth = this.BottomRailWidth;
        ////    Settings.Default.LeftStileWidth = this.LeftStileWidth;
        ////    Settings.Default.RightSideWidth = this.RightSideWidth;

        ////    Settings.Default.Save();

        ////}

        #endregion

        #region Private

        /// <summary>Reads the defaults from disk.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        ////internal void Initialize()
        ////{
        ////    this.Height = Settings.Default.Height;
        ////    this.Width = Settings.Default.Width;
        ////    this.OuterLevelNumber = Settings.Default.OuterLevelNumber;
        ////    this.InnerLevelNumber = Settings.Default.InnerLevelNumber;
        ////    this.GrooveLevelNumber = Settings.Default.GrooveLevelNumber;
        ////    this.OuterLevelName = Settings.Default.OuterLevelName;
        ////    this.InnerLevelName = Settings.Default.InnerLevelName;
        ////    this.GrooveLevelName = Settings.Default.GrooveLevelName;
        ////    this.TopRailWidth = Settings.Default.TopRailWidth;
        ////    this.BottomRailWidth = Settings.Default.BottomRailWidth;
        ////    this.LeftStileWidth = Settings.Default.LeftStileWidth;
        ////    this.RightSideWidth = Settings.Default.RightSideWidth;
        ////}

        #endregion
    }
}