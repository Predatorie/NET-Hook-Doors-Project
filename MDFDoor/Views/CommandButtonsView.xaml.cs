﻿// <copyright file="CommandButtonsView.xaml.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Views
{
    using System.Windows;
    using MahApps.Metro.Controls.Dialogs;

    /// <summary>
    /// Interaction logic for CommandButtonsView
    /// </summary>
    public partial class CommandButtonsView
    {
        public CommandButtonsView() => this.InitializeComponent();

        private void CommandButtonsView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            // If using DialogParticipation on Windows which open / close frequently you will get a
            // memory leak unless you unregister.  The easiest way to do this is in your Closing/ Unloaded event
            DialogParticipation.SetRegister(this, null);
        }
    }
}
