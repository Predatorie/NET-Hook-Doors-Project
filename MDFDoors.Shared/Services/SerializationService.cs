// <copyright file="SerializationService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    using System;
    using System.IO;
    using Localization;
    using Models;
    using Newtonsoft.Json;

    /// <summary>A serialization service.</summary>
    ///
    /// <remarks>Mick George, 11/6/2017.</remarks>
    public partial class SerializationService : ISerializationService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationService"/> class.Constructor.</summary>
        /// <param name="fileBrowser">The file browser.</param>
        public SerializationService(IFileBrowserService fileBrowser) => this.fileBrowser = fileBrowser;

        /// <summary>Serialize door style.</summary>
        /// <returns>A Result.</returns>
        public Result SerializeDoorStyle<T>(object model)
        {
            var result = this.Save<T>(model);
            return result.IsSuccess ? Result.Ok(result) : Result.Fail(result.Error);
        }

        /// <summary>Deserialize door style.</summary>
        /// <returns>A Result.</returns>
        public Result<T> DeserializeDoorStyle<T>()
        {
            var result = this.Load<T>();
            return result.IsSuccess ? Result.Ok(result.Value) : Result.Fail<T>(result.Error);
        }
    }

    /// <summary>A serialization service.</summary>
    ///
    /// <remarks>Mick George, 11/6/2017.</remarks>
    public partial class SerializationService
    {
        /// <summary>The file browser.</summary>
        private readonly IFileBrowserService fileBrowser;

        /// <summary>Saves the given style.</summary>
        /// <returns>A Result of true if success.</returns>
        private Result Save<T>(object door)
        {
            // Get a location from disk
            var result = this.fileBrowser.SaveDoorStyleSettingsFile();
            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            var file = result.Value;

            try
            {
                // serialize the model
                var model = JsonConvert.SerializeObject(door, Formatting.Indented);

                // Write it to disk
                File.WriteAllText(file, model);

                return Result.Ok();
            }
            catch (DirectoryNotFoundException)
            {
                return Result.Fail<T>("Directory does not exist.");
            }
            catch (UnauthorizedAccessException)
            {
                return Result.Fail<T>("UnauthorizedAccess");
            }
            catch (PathTooLongException)
            {
                return Result.Fail<T>("File path is too long.");
            }
            catch (IOException ex)
            {
                return Result.Fail<T>($"File disk read exception {ex.Message}");
            }
        }

        /// <summary>Loads the given style from disk.</summary>
        /// <param name="style">The style to load.</param>
        /// <returns>A Result that contains the door style if success.</returns>
        private Result<T> Load<T>()
        {
            var result = this.fileBrowser.SelectDoorStyleSettingsFile();
            if (result.IsFailure)
            {
                return Result.Fail<T>(result.Error);
            }

            var file = result.Value;

            try
            {
                using (var sr = new StreamReader(file))
                {
                    var json = sr.ReadToEnd();
                    var model = JsonConvert.DeserializeObject<T>(json);

                    return model == null ? Result.Fail<T>(ApplicationStrings.WrongDoorStyleSelected) : Result.Ok(model);
                }
            }
            catch (FileNotFoundException)
            {
                return Result.Fail<T>($"File not found {file}.");
            }
            catch (DirectoryNotFoundException)
            {
                return Result.Fail<T>(ApplicationStrings.DirDoesNotExist);
            }
            catch (IOException ex)
            {
                return Result.Fail<T>($"File disk read exception {ex.Message}");
            }
        }
    }
}