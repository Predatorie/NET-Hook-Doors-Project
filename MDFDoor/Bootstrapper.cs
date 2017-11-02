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
	using Prism.Unity;
	using Services;

	internal class Bootstrapper : UnityBootstrapper
	{
		private Views.MainWindow window;

		protected override DependencyObject CreateShell()
		{
			this.window = this.Container.Resolve<Views.MainWindow>();
			return this.window;
		}

		protected override void InitializeShell() => this.window.Show();

		protected override void ConfigureModuleCatalog()
		{
			var catalog = (ModuleCatalog)this.ModuleCatalog;
			catalog.AddModule(typeof(ModuleDoorModule));
		}

		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();

			this.Container.RegisterType<INavigationParametersFactory,
				NavigationParametersFactory>(new ContainerControlledLifetimeManager());

			// Creates the door style
			this.Container.RegisterType<IDoorController,
				DoorController>(new ContainerControlledLifetimeManager());

			// Manages default settings for each door style relative to level properties
			this.Container.RegisterType<IDefaultsManager,
				DefaultsManager>(new ContainerControlledLifetimeManager());
		}
	}
}
