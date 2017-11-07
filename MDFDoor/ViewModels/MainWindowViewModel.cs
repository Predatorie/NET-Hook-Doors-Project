// <copyright file="MainWindowViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.ViewModels
{
    using MahApps.Metro.Controls;
    using Shared.Localization;
    using Prism.Commands;
    using Prism.Mvvm;

	public class MainWindowViewModel : BindableBase
    {
        #region Private Fields

	    /// <summary> The title backing field. </summary>
	    private string title;

		#endregion

		#region Construction

	    /// <summary>
	    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
	    /// 
	    /// </summary>
	    public MainWindowViewModel()
	    {
		    this.Title = ApplicationStrings.Title;
		    this.SettingsCommand = new DelegateCommand<Flyout>(ToggleSettingsDisplay);
	    } 

		#endregion

		#region Public Commands

		/// <summary>
		/// The Settings Command
		/// </summary>
		public DelegateCommand<Flyout> SettingsCommand { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the Title property
        /// </summary>
        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }

        #endregion

        #region Private Methods

        /// <summary> Toggle settings display. </summary>
        ///
        /// <param name="flyout"> The flyout. </param>
        private static void ToggleSettingsDisplay(Flyout flyout) => flyout.IsOpen = !flyout.IsOpen;

        #endregion
    }
}
