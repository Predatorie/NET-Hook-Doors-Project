// <copyright file="Shaker.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module.Models
{
    using Shared;

    public class Shaker : BaseDoor
    {
        #region Public Properties

        /// <summary>Gets the style.</summary>
        public DoorStyles Style => DoorStyles.Shaker;

        /// <summary>Convert this object into a string representation.</summary>
        /// <returns>A string that represents this object.</returns>
        public override string ToString() => DoorNames.Shaker;

        #endregion
    }
}