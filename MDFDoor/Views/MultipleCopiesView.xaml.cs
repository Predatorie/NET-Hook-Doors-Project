// <copyright file="MultipleCopiesView.xaml.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Views
{
    using System.Windows;
    using MahApps.Metro.Controls.Dialogs;
    using Prism.Events;
    using Shared.Events;

    /// <summary>
    /// Interaction logic for MultipleCopiesView
    /// </summary>
    public partial class MultipleCopiesView
    {
        public MultipleCopiesView(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<CloseMultipleCopiesViewEvent>().Subscribe(this.OnCloseMultipleCopiesViewEvent);

            this.InitializeComponent();
        }

        private void OnCloseMultipleCopiesViewEvent() => this.Close();

        /// <summary>
        /// If using DialogParticipation on Windows which open / close frequently you will get a
        /// memory leak unless you unregister.  The easiest way to do this is in your Closing/ Unloaded event
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event payload</param>
        private void MultipleCopiesView_OnUnloaded(object sender, RoutedEventArgs e) => DialogParticipation.SetRegister(this, null);
    }
}
