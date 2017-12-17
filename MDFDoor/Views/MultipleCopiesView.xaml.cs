// <copyright file="MultipleCopiesView.xaml.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Views
{
    using System.Windows;
    using MahApps.Metro.Controls.Dialogs;

    /// <summary>
    /// Interaction logic for MultipleCopiesView
    /// </summary>
    public partial class MultipleCopiesView
    {
        public MultipleCopiesView() => this.InitializeComponent();

        private void MultipleCopiesView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            // If using DialogParticipation on Windows which open / close frequently you will get a
            // memory leak unless you unregister.  The easiest way to do this is in your Closing/ Unloaded event
            DialogParticipation.SetRegister(this, null);
        }
    }
}
