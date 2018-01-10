// <copyright file="SpreadsheetView.xaml.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Views
{
    using System.Windows;
    using MahApps.Metro.Controls.Dialogs;

    /// <summary>
    /// Interaction logic for SpreadsheetView
    /// </summary>
    public partial class SpreadsheetView
    {
        public SpreadsheetView() => this.InitializeComponent();

        /// <summary>
        /// If using DialogParticipation on Windows which open / close frequently you will get a
        /// memory leak unless you unregister.  The easiest way to do this is in your Closing/ Unloaded event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The RoutedEventArgs payload</param>
        private void SpreadsheetView_OnUnloaded(object sender, RoutedEventArgs e) =>
            DialogParticipation.SetRegister(this, null);
    }
}