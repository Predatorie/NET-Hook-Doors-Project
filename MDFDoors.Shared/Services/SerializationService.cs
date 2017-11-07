// <copyright file="SerializationService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    using System;
    using Models;

    /// <summary>A serialization service.</summary>
    ///
    /// <remarks>Mick George, 11/6/2017.</remarks>
    public partial class SerializationService : ISerializationService
    {

        /// <summary>The file browser.</summary>
        private readonly IFileBrowserService fileBrowser;

        /// <summary>Constructor.</summary>
        /// <param name="fileBrowser">The file browser.</param>
        public SerializationService(IFileBrowserService fileBrowser) => this.fileBrowser = fileBrowser;

        /// <summary>Serialize door style.</summary>
        /// <param name="style">The style.</param>
        /// <returns>A Result.</returns>
        public Result SerializeDoorStyle(DoorStyles style)
        {
            var result = this.Save(style);
            return result.IsSuccess ? Result.Ok(result) : Result.Fail(result.Error);
        }

        /// <summary>Deserialize door style.</summary>
        /// <param name="style">The style.</param>
        /// <returns>A Result.</returns>
        public Result<object> DeserializeDoorStyle(DoorStyles style)
        {
            var result = this.Load(style);
            return result.IsSuccess ? Result.Ok<object>(result) : Result.Fail<object>(result.Error);
        }
    }

    /// <summary>A serialization service.</summary>
    ///
    /// <remarks>Mick George, 11/6/2017.</remarks>
    public partial class SerializationService
    {
        /// <summary>Saves the given style.</summary>
        /// <param name="style">The style to load.</param>
        /// <returns>A Result of true if success.</returns>
        private Result Save(DoorStyles style)
        {
            try
            {
                // TODO: Add explicit exception handlers
                switch (style)
                {
                    case DoorStyles.ShakerElegance:
                        return Result.Ok();

                    case DoorStyles.ShakerCentury:
                        return Result.Ok();

                    case DoorStyles.ShakerCountry:
                        return Result.Ok();

                    case DoorStyles.ShakerEuro05:
                        return Result.Ok();

                    case DoorStyles.ShakerExotic:
                        return Result.Ok();

                    case DoorStyles.ShakerFinest:
                        return Result.Ok();

                    case DoorStyles.Shaker:
                        return Result.Ok();

                    default:
                        return Result.Fail($"{nameof(style)} does not exist.");
                }
            }
            catch (Exception e)
            {
                return Result.Fail($"An error occured: {e.Message}.");
            }
        }

        /// <summary>Loads the given style from disk.</summary>
        /// <param name="style">The style to load.</param>
        /// <returns>A Result that contains the door style if success.</returns>
        private Result<object> Load(DoorStyles style)
        {
            try
            {
                switch (style)
                {
                    case DoorStyles.ShakerElegance:
                        return Result.Ok<object>(this.LoadShakerElegance());

                    default:
                        return Result.Fail<object>($"{nameof(style)} does not exist.");
                }
            }
            // TODO: Add explicit exception handlers
            catch (Exception e)
            {
                return Result.Fail<object>($"An error occured: {e.Message}.");
            }
        }

        /// <summary>Loads shaker elegance.</summary>
        ///
        /// <remarks>Mick George, 11/6/2017.</remarks>
        ///
        /// <returns>The shaker elegance.</returns>
        private Result<ShakerElegance> LoadShakerElegance()
        {
            // TODO: Prompt for file off disk to de-serialize
            var result = this.fileBrowser.SelectDoorStyleSettingsFile();
            if (result.IsFailure)
            {
                return Result.Fail<ShakerElegance>(result.Error);
            }

            // TODO: We have the file now de-serialize it and return
            var file = result.Value;


            var door = new ShakerElegance();
            return Result.Ok(door);
        }
    }
}