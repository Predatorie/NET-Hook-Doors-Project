// <copyright file="Bootstrapper.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors
{
    using System.Windows;
    using Controller;
    using Factories;
    using Microsoft.Practices.Unity;
    using ModuleDoors;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;
    using Views;

    internal class Bootstrapper : UnityBootstrapper
	{
		/// <summary> The window. </summary>
		private MainWindow window;

		/// <summary> Creates the shell or main window of the application. </summary>
		///
		/// <remarks> If the returned instance is a <see cref="T:System.Windows.DependencyObject" />
		/// 		  , the
		/// 		  <see cref="T:Prism.Bootstrapper" />
		/// 		  will attach the default <see cref="T:Prism.Regions.IRegionManager" />
		/// 		  of the application in its <see cref="F:Prism.Regions.RegionManager.RegionManagerProperty" />
		/// 		  attached property in order to be able to add regions by using the
		/// 		  <see cref="F:Prism.Regions.RegionManager.RegionNameProperty" />
		/// 		  attached property from XAML. </remarks>
		///
		/// <returns> The shell of the application. </returns>
		protected override DependencyObject CreateShell()
		{
			this.window = this.Container.Resolve<MainWindow>();
			return this.window;
		}

		/// <summary> Initializes the shell. </summary>
		protected override void InitializeShell() => this.window.ShowDialog();

		/// <summary> Configures the <see cref="T:Prism.Modularity.IModuleCatalog" />
		/// 		  used by Prism. </summary>
		protected override void ConfigureModuleCatalog()
		{
			var catalog = (ModuleCatalog)this.ModuleCatalog;
			catalog.AddModule(typeof(ModuleDoorModule));
		}

		/// <summary> Configures the <see cref="T:Microsoft.Practices.Unity.IUnityContainer" />
		/// 		  . May be overwritten in a derived class to add specific
		/// 		  type mappings required by the application. </summary>
		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();

		   this.Container.RegisterType<IViewFactory,
		        ViewFactory>(new ContainerControlledLifetimeManager());

            this.Container.RegisterType<INavigationParametersFactory,
				NavigationParametersFactory>(new ContainerControlledLifetimeManager());

			// Creates the door style
			this.Container.RegisterType<IDoorController,
				DoorController>(new ContainerControlledLifetimeManager());
		}

		/// <summary>
		/// Configures the default region adapter mappings to use in the application, in order
		/// to adapt UI controls defined in XAML to use a region and register it automatically.
		/// May be overwritten in a derived class to add specific mappings required by the application.
		/// </summary>
		/// <returns>The <see cref="T:Prism.Regions.RegionAdapterMappings" /> instance containing all the mappings.</returns>
		protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
		{
			// Anything placed in a region in this manner will not be added to the navigation journal.            
			var regionManager = this.Container.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion(Regions.DoorTypesMenuRegion, typeof(DoorStylesMenuView));
		    regionManager.RegisterViewWithRegion(Regions.SettingsRegion, typeof(SettingsView));

            return base.ConfigureRegionAdapterMappings();
		}
	}
}
