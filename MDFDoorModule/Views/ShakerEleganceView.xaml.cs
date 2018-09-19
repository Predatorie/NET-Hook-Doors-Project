// <copyright file="ShakerEleganceView.xaml.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Module.Views
{
    using System.Windows;
    using MahApps.Metro.Controls.Dialogs;

    /// <summary>
    /// Interaction logic for ShakerEleganceView
    /// </summary>
    public partial class ShakerEleganceView
    {
        public ShakerEleganceView() => this.InitializeComponent();

        private void ShakerEleganceView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            // If using DialogParticipation on Windows which open / close frequently you will get a
            // memory leak unless you unregistered.  The easiest way to do this is in your Closing/ Unloaded event
            DialogParticipation.SetRegister(this, null);
        }
    }
}
