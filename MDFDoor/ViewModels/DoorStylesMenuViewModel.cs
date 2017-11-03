// <copyright file="DoorStylesMenuViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.ViewModels
{
	using MDFDoors.Factories;

	using Prism.Commands;
	using Prism.Mvvm;
	using Prism.Regions;

	/// <summary> A ViewModel for the door styles menu. </summary>
	public class DoorStylesMenuViewModel : BindableBase
	{
		#region Private Fields

		/// <summary>
		/// Backing field for the Region Manager
		/// </summary>
		private readonly IRegionManager regionManager;

		/// <summary> The view factory. </summary>
		private readonly IViewFactory viewFactory;

		/// <summary>
		/// Backing field for the Navigation Parameters Factory
		/// </summary>
		private readonly INavigationParametersFactory navigationParamsFactory;

		#endregion

		#region Construction

		/// <summary> Initializes a new instance of the MDFDoors.ViewModels.DoorStylesMenuViewModel class. </summary>
		///
		/// <param name="navigationParametersFactory"> The navigation parameters factory. </param>
		/// <param name="regionManager">			   Backing field for the Region Manager. </param>
		/// <param name="viewFactory">				   The IViewFactory. </param>
		public DoorStylesMenuViewModel(
			INavigationParametersFactory navigationParametersFactory,
			IRegionManager regionManager,
			IViewFactory viewFactory)
		{
			this.navigationParamsFactory = navigationParametersFactory;
			this.regionManager = regionManager;
			this.viewFactory = viewFactory;
			this.NavigateCommand = new DelegateCommand<object>(this.Navigate);
		}

		#endregion

		#region Public Commands

		/// <summary>
		/// The Navigate Command
		/// </summary>
		public DelegateCommand<object> NavigateCommand { get; private set; }

		#endregion

		#region Private Methods

		/// <summary> Navigates the given style. </summary>
		///
		/// <param name="style"> The style. </param>
		private void Navigate(object style)
		{
			var door = (DoorStyles)style;
			var viewName = this.navigationParamsFactory.View(door);
			var navigationParams = this.navigationParamsFactory.Create(door);

			// TODO: Check is the view is already added to the region manager before
			// TODO: requesting a new one

			var view = this.viewFactory.View(door);

			// TODO: Refactor this check as its not applicable now

			////var contentRegion = this.regionManager.Regions[Regions.ContentRegion];

			////// Remove all views for now (look to activate/deactivate)
			////var activeViews = contentRegion.ActiveViews;
			////foreach (var activeView in activeViews)
			////{
			////	contentRegion.Deactivate(activeView);
			////}

			////var viewExists = contentRegion.Views.FirstOrDefault(v => v.Equals(view));
			////if (viewExists == null)
			////{
			////	// Add the view to display it, we need to do this if our MainView is Model (which it is)
			////	var scopedRegionManager = this.regionManager.Regions[Regions.ContentRegion].Add(view, viewName, true);
			////	scopedRegionManager.RequestNavigate(Regions.ContentRegion, viewName, navigationParams);
			////}
			////else
			////{
			////	contentRegion.Activate(view);
			////}
		}

		#endregion
	}
}