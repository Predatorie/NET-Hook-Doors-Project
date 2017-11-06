// <copyright file="MainWindow.xaml.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

using MDFDoors.Module.Events;

namespace MDFDoors.Views
{
    using System.Windows;
    using MahApps.Metro.Controls.Dialogs;
    using Prism.Events;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>Constructor.</summary>
        ///
        /// <remarks>Mick George, 11/5/2017.</remarks>
        ///
        /// <param name="eventAggregator">The event aggregator.</param>
        public MainWindow(IEventAggregator eventAggregator)
        {
            this.InitializeComponent();

            eventAggregator.GetEvent<ExitAppEvent>().Subscribe(this.OnExit);
        }

        /// <summary>Executes the exit action.</summary>
        ///
        /// <remarks>Mick George, 11/5/2017.</remarks>
        private void OnExit() => this.Close();

        /// <summary>Event handler. Called by MainWindow for on unloaded events.</summary>
        ///
        /// <remarks>Mick George, 11/5/2017.</remarks>
        ///
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">     Routed event information.</param>
        private void MainWindow_OnUnloaded(object sender, RoutedEventArgs e)
        {
            // If using DialogParticipation on Windows which open / close frequently you will get a
            // memory leak unless you unregister.  The easiest way to do this is in your Closing/ Unloaded event
            DialogParticipation.SetRegister(this, null);
        }
    }
}
