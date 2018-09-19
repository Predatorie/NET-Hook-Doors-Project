// <copyright file="ShakerBeadView.xaml.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module.Views
{
    using System.Windows;

    using MahApps.Metro.Controls.Dialogs;

    /// <summary>
    /// Interaction logic for ShakerBeadView
    /// </summary>
    public partial class ShakerBeadView
    {
        /// <summary> Initializes a new instance of the MDFDoors.Module.Views.ShakerBeadView class. </summary>
        public ShakerBeadView() => this.InitializeComponent();

        /// <summary> Event handler. Called by ShakerBeadView for on unloaded events. </summary>
        ///
        /// <param name="sender"> Source of the event. </param>
        /// <param name="e">      Routed event information. </param>
        private void ShakerBeadView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            // If using DialogParticipation on Windows which open / close frequently you will get a
            // memory leak unless you unregistered.  The easiest way to do this is in your Closing/ Unloaded event
            DialogParticipation.SetRegister(this, null);
        }
    }
}
