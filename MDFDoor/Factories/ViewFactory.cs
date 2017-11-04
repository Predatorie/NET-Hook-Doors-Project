﻿// <copyright file="ViewFactory.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Factories
{
	using System;

	using Microsoft.Practices.Unity;

	using ModuleDoors.Views;

	public class ViewFactory : IViewFactory
	{
		/// <summary> The container. </summary>
		private readonly IUnityContainer container;

        /// <summary> Initializes a new instance of the MDFDoors.Factories.ViewFactory class. </summary>
        ///
        /// <param name="container"> The container. </param>
        public ViewFactory(IUnityContainer container) => this.container = container;

        /// <summary> Get the View from the Door Style Type. </summary>
        ///
        /// <param name="door"> The door style view to resolve. </param>
        ///
        /// <returns> A view </returns>
        public object View(DoorStyles door)
		{
			switch (door)
			{
				case DoorStyles.ShakerElegance:
					return this.container.Resolve<ShakerEleganceView>();

				case DoorStyles.ShakerCentury:
					return this.container.Resolve<ShakerCenturyView>();

				case DoorStyles.ShakerCountry:
					return this.container.Resolve<ShakerCountryView>();

				case DoorStyles.ShakerEuro05:
					return this.container.Resolve<ShakerEuro05View>();

				case DoorStyles.ShakerExotic:
					return this.container.Resolve<ShakerExoticView>();

				case DoorStyles.ShakerFinest:
					return this.container.Resolve<ShakerFinestView>();

				case DoorStyles.Shaker:
					return this.container.Resolve<ShakerView>();

				default:
					throw new ArgumentOutOfRangeException(nameof(door), door, null);
			}
		}
	}
}