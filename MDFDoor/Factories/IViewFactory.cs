// <copyright file="IViewFactory.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Factories
{
    using Models;
    using ModuleDoors;

	public interface IViewFactory
	{
		/// <summary> Get a View. </summary>
		///
		/// <param name="door"> The name of the view to resolve. </param>
		///
		/// <returns> A view. </returns>
		ResultOfT<object> View(DoorStyles door);
	}
}