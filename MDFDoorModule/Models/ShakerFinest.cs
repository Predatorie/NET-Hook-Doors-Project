// <copyright file="ShakerFinest.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module.Models
{
    using Shared;

    public class ShakerFinest : BaseDoor
    {
        #region Public Properties

        /// <summary>Gets the style.</summary>
        public DoorStyles Style => DoorStyles.ShakerFinest;

        /// <summary>Convert this object into a string representation.</summary>
        /// <returns>A string that represents this object.</returns>
        public override string ToString() => DoorNames.ShakerFinest;

        #endregion
    }
}