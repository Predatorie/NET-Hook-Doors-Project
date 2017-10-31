// <copyright file="MainWindow.xaml.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Views
{
    using System.Windows;
    using MahApps.Metro.Controls.Dialogs;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow() => this.InitializeComponent();

        private void MainWindow_OnUnloaded(object sender, RoutedEventArgs e)
        {
            // If using DialogParticipation on Windows which open / close frequently you will get a
            // memory leak unless you unregister.  The easiest way to do this is in your Closing/ Unloaded event
            DialogParticipation.SetRegister(this, null);
        }
    }
}
