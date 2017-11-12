// <copyright file="ShakerEuro05.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module.Models
{
    using Shared;

    public class ShakerEuro05 : BaseDoor
    {
        #region Public Properties

        /// <summary>The style.</summary>
        public DoorStyles Style => DoorStyles.ShakerEuro05;

        /// <summary>Convert this object into a string representation.</summary>
        /// <returns>A string that represents this object.</returns>
        public override string ToString() => DoorNames.ShakerEuro05;

        #endregion
    }
}