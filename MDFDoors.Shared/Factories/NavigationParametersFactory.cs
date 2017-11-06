// <copyright file="NavigationParametersFactory.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Factories
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
                { NavigationParamIndexer.Style, style },
                { NavigationParamIndexer.Name, DoorName(style) }
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
                    return ViewNames.ShakerElegance;
                case DoorStyles.ShakerCentury:
                    return ViewNames.ShakerCentury;
                case DoorStyles.ShakerCountry:
                    return ViewNames.ShakerCountry;
                case DoorStyles.ShakerEuro05:
                    return ViewNames.ShakerEuro05;
                case DoorStyles.ShakerExotic:
                    return ViewNames.ShakerExotic;
                case DoorStyles.ShakerFinest:
                    return ViewNames.ShakerFinest;
                case DoorStyles.Shaker:
                    return ViewNames.Shaker;
            }

            // TODO: Implement the Result class
            return default(string);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>  Gets the Door name. </summary>
        ///
        /// <remarks>   Mick George, 11/3/2017. </remarks>
        ///
        /// <param name="style">    The door type. </param>
        ///
        /// <returns>   The Door Name. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static string DoorName(DoorStyles style)
        {
            switch (style)
            {
                case DoorStyles.ShakerElegance:
                    return DoorNames.ShakerElegance;
                case DoorStyles.ShakerCentury:
                    return DoorNames.ShakerCentury;
                case DoorStyles.ShakerCountry:
                    return DoorNames.ShakerCountry;
                case DoorStyles.ShakerEuro05:
                    return DoorNames.ShakerEuro05;
                case DoorStyles.ShakerExotic:
                    return DoorNames.Exotic;
                case DoorStyles.ShakerFinest:
                    return DoorNames.ShakerFinest;
                case DoorStyles.Shaker:
                    return DoorNames.Shaker;
                default:
                    return default(string); 
            }
        }
    }
}