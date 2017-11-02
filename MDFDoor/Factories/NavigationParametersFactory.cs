// <copyright file="NavigationParametersFactory.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Factories
{
	using Prism.Regions;

	/// <summary>
	/// Defines the INavigationParametersFactory class
	/// </summary>
	public class NavigationParametersFactory : INavigationParametersFactory
	{
		public NavigationParameters Create(DoorStyles style) =>
			new NavigationParameters("Door")
			{
				{ "Style", style },
				{ "Name", this.GetReadableNameOfView(style) }
			};

		/// <summary>
		/// Gets the door types view
		/// </summary>
		/// <param name="style">The door type</param>
		/// <returns>The uri to the view</returns>
		public string View(DoorStyles style)
		{
			switch (style)
			{
				case DoorStyles.ShakerElegance:
					return "ShakerEleganceView";
				case DoorStyles.ShakerCentury:
					return "ShakerCenturyView";
				case DoorStyles.ShakerCountry:
					return "ShakerCountryView";
				case DoorStyles.ShakerEuro05:
					return "ShakerEuro05View";
				case DoorStyles.ShakerExotic:
					return "ShakerFinestView";
				case DoorStyles.ShakerFinest:
					return "ShackerEleganceView";
				case DoorStyles.Shaker:
					return "ShackerView";
			}

			// TODO: Implement the Result class
			return default(string);
		}

		private string GetReadableNameOfView(DoorStyles style)
		{
			switch (style)
			{
				case DoorStyles.ShakerElegance:
					return "Shaker Elegance";
				case DoorStyles.ShakerCentury:
					return "Shaker Century";
				case DoorStyles.ShakerCountry:
					return "Shaker Country";
				case DoorStyles.ShakerEuro05:
					return "Shaker Euro05";
				case DoorStyles.ShakerExotic:
					return "Shaker Finest";
				case DoorStyles.ShakerFinest:
					return "Shacker Elegance";
				case DoorStyles.Shaker:
					return "Shacker";
			}

			// TODO: Implement the Result class
			return default(string);
		}
	}
}