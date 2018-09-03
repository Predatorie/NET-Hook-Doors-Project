// <copyright file="MultipleCopiesViewModel.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.ViewModels
{
    using System.IO;
    using System.Windows.Input;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;
    using Shared.Events;
    using Shared.Localization;
    using Shared.Models;
    using Shared.Services;

    public class MultipleCopiesViewModel : BindableBase
    {
        #region Private Fields

        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// Backing field for the IFileBrowserService singleton
        /// </summary>
        private readonly IFileBrowserService browserService;

        /// <summary>
        /// Backing field for the ISettingsService singleton
        /// </summary>
        private readonly ISettingsService settingsService;

        /// <summary>The steps.</summary>
        private int xSteps;

        /// <summary>The steps.</summary>
        private int ySteps;

        /// <summary>The distance between.</summary>
        private int xDistanceBetween;

        /// <summary>The distance between.</summary>
        private int yDistanceBetween;

        /// <summary>
        /// Backing field for the title property
        /// </summary>
        private string title;

        /// <summary>
        /// Backing field for the header property
        /// </summary>
        private string header;

        /// <summary>
        /// Backing field for the steps property
        /// </summary>
        private bool steps;

        /// <summary>
        /// Backing field for the excel property
        /// </summary>
        private bool excel;

        /// <summary>
        /// Backing field for the distance property
        /// </summary>
        private string distance;

        /// <summary>
        /// Backing field for the csv file path
        /// </summary>
        private string file;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleCopiesViewModel"/> class.Constructor.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="fileBrowserService">The IFileBrowserService singleton</param>
        /// <param name="settingsService">The ISettingsService singleton</param>
        public MultipleCopiesViewModel(
            IEventAggregator eventAggregator,
            IFileBrowserService fileBrowserService,
            ISettingsService settingsService)
        {
            this.eventAggregator = eventAggregator;
            this.browserService = fileBrowserService;
            this.settingsService = settingsService;

            this.Title = ApplicationStrings.MultipleCopiesTitle;
            this.MultiCopyMethodHeader = ApplicationStrings.MultiCopyMethodHeader;
            this.MultiCopyDistanceHeader = ApplicationStrings.MultiCopyDistanceHeader;

            // Wire up our commands
            this.OKCommand = new DelegateCommand(
                    this.OnOKCommand,
                    () => ((this.IsSteps && this.XSteps >= 1 && this.YSteps >= 1 &&
                           this.XDistanceBetween >= 1 && this.YDistanceBetween >= 1) ||
                           (this.IsExcel && File.Exists(this.FilePath))) &&
                           this.XDistanceBetween >= 1 && this.YDistanceBetween >= 1)
                .ObservesProperty(() => this.XSteps)
                .ObservesProperty(() => this.YSteps)
                .ObservesProperty(() => this.XDistanceBetween)
                .ObservesProperty(() => this.YDistanceBetween);

            this.BrowseForExcelCommand = new DelegateCommand(
                this.OnBrowseForExcelCommand,
                () => this.IsExcel)
                .ObservesProperty(() => this.IsExcel);

            this.CancelCommand = new DelegateCommand(this.OnCancelCommand);

            this.ReadMultipleCopiesFromDefault();
        }

        #endregion

        #region Public Commands

        /// <summary>Gets the ok command.</summary>
        ///
        /// <value>The ok command.</value>
        public ICommand OKCommand { get; }

        /// <summary>Gets the cancel command.</summary>
        ///
        /// <value>The cancel command.</value>
        public ICommand CancelCommand { get; }

        /// <summary>Gets the browse excel command.</summary>
        ///
        /// <value>The cancel command.</value>
        public ICommand BrowseForExcelCommand { get; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the <see cref="XSteps"/> property
        /// </summary>
        public int XSteps
        {
            get => this.xSteps;
            set => this.SetProperty(ref this.xSteps, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="YSteps"/> property
        /// </summary>
        public int YSteps
        {
            get => this.ySteps;
            set => this.SetProperty(ref this.ySteps, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="XDistanceBetween"/> property
        /// </summary>
        public int XDistanceBetween
        {
            get => this.xDistanceBetween;
            set => this.SetProperty(ref this.xDistanceBetween, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="YDistanceBetween"/> property
        /// </summary>
        public int YDistanceBetween
        {
            get => this.yDistanceBetween;
            set => this.SetProperty(ref this.yDistanceBetween, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="Title"/> property
        /// </summary>
        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="MultiCopyMethodHeader"/> property
        /// </summary>
        public string MultiCopyMethodHeader
        {
            get => this.header;
            set => this.SetProperty(ref this.header, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="MultiCopyDistanceHeader"/> property
        /// </summary>
        public string MultiCopyDistanceHeader
        {
            get => this.distance;
            set => this.SetProperty(ref this.distance, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the <see cref="IsSteps"/> property
        /// </summary>
        public bool IsSteps
        {
            get => this.steps;
            set
            {
                this.SetProperty(ref this.steps, value);
                this.IsExcel = !this.IsSteps;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the <see cref="IsExcel"/> property
        /// </summary>
        public bool IsExcel
        {
            get => this.excel;
            set => this.SetProperty(ref this.excel, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the <see cref="FilePath"/> property
        /// </summary>
        public string FilePath
        {
            get => this.file;
            set => this.SetProperty(ref this.file, value);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initialize to default state
        /// </summary>
        private void ReadMultipleCopiesFromDefault()
        {
            var data = this.settingsService.MultipleCopiesData();

            this.XSteps = data.XSteps;
            this.YSteps = data.YSteps;
            this.xDistanceBetween = data.XDistanceBetween;
            this.YDistanceBetween = data.YDistanceBetween;
            this.IsSteps = data.UseSteps;
            this.IsExcel = data.UseExcel;
            this.FilePath = data.Excel;
        }

        /// <summary>Executes the cancel command action.</summary>
        private void OnCancelCommand() => this.eventAggregator.GetEvent<CloseMultipleCopiesViewEvent>().Publish();

        /// <summary>Executes the ok command action.</summary>
        private void OnOKCommand()
        {
            var data = new MultipleCopiesData
            {
                XSteps = this.XSteps,
                YSteps = this.YSteps,
                XDistanceBetween = this.XDistanceBetween,
                YDistanceBetween = this.YDistanceBetween,
                UseSteps = this.IsSteps,
                UseExcel = this.IsExcel,
                Excel = this.FilePath
            };

            // Save to defaults for others to read
            this.settingsService.SaveMultipleCopiesData(data);

            // Close the dialog
            this.eventAggregator.GetEvent<CloseMultipleCopiesViewEvent>().Publish();
        }

        /// <summary>
        /// Browse for an excel file
        /// </summary>
        private void OnBrowseForExcelCommand()
        {
            var result = this.browserService.SelectExcelFile();
            if (result.IsSuccess)
            {
                this.FilePath = result.Value;
            }
        }

        #endregion
    }
}
