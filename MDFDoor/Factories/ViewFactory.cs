// <copyright file="ViewFactory.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Factories
{
    using Shared.Factories;
    using Microsoft.Practices.Unity;
    using Module.Views;
    using Shared;
    using Shared.Models;

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
        public ResultOfT<object> View(DoorStyles door)
        {
            switch (door)
            {
                case DoorStyles.ShakerElegance:
                    return Result.Ok<object>(this.container.Resolve<ShakerEleganceView>());

                case DoorStyles.ShakerCentury:
                    return Result.Ok<object>(this.container.Resolve<ShakerCenturyView>());

                case DoorStyles.ShakerCountry:
                    return Result.Ok<object>(this.container.Resolve<ShakerCountryView>());

                case DoorStyles.ShakerEuro05:
                    return Result.Ok<object>(this.container.Resolve<ShakerEuro05View>());

                case DoorStyles.ShakerExotic:
                    return Result.Ok<object>(this.container.Resolve<ShakerExoticView>());

                case DoorStyles.ShakerFinest:
                    return Result.Ok<object>(this.container.Resolve<ShakerFinestView>());

                case DoorStyles.Shaker:
                    return Result.Ok<object>(this.container.Resolve<ShakerView>());

                default:
                    return Result.Fail<object>($"Uknown door type {nameof(door)}");
            }
        }
    }
}