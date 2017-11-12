﻿// <copyright file="ShakerExotic.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module.Models
{
    using Shared;

    public class ShakerExotic : BaseDoor
    {
        #region Public Properties

        /// <summary>The style.</summary>
        public DoorStyles Style => DoorStyles.ShakerExotic;

        /// <summary>Convert this object into a string representation.</summary>
        /// <returns>A string that represents this object.</returns>
        public override string ToString() => DoorNames.ShakerExotic;

        #endregion
    }
}