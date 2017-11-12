// <copyright file="GeometryCreationService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Services
{
    using System.Linq;
    using Mastercam.GeometryUtility;
    using Mastercam.IO;
    using Mastercam.Math;
    using Module.Models;
    using Shared.Models;
    using Shared.Services;

    public class GeometryCreationService : IGeometryCreationService
    {
        /// <summary>Creates a door.</summary>
        ///
        /// <remarks>Mick George, 11/11/2017.</remarks>
        ///
        /// <param name="model">The model.</param>
        ///
        /// <returns>The new door.</returns>
        public Result CreateDoor(object model)
        {
            // TODO: Re-factor

            if (model.GetType() == typeof(ShakerElegance))
            {
                return this.CreateShakerElegance((ShakerElegance)model);
            }

            if (model.GetType() == typeof(ShakerCountry))
            {
                return this.CreateShakerCountry((ShakerCountry)model);
            }

            if (model.GetType() == typeof(ShakerCentry))
            {
                return this.CreateShakerCentry((ShakerCentry)model);
            }

            return Result.Fail($"Unkown Door Style {model.ToString()}");
        }

        private Result CreateShakerCentry(ShakerCentry model)
        {
            return Result.Ok();
        }

        private Result CreateShakerCountry(ShakerCountry model)
        {
            return Result.Ok();
        }

        /// <summary>Creates shaker elegance.</summary>
        ///
        /// <remarks>Mick George, 11/11/2017.</remarks>
        ///
        /// <param name="model">The model.</param>
        ///
        /// <returns>The new shaker elegance.</returns>
        private Result CreateShakerElegance(ShakerElegance model)
        {
            // Outer panel
            var result = this.DrawRectangle(model.Width, model.Height, model.OuterLevelNumber, model.OuterLevelName);
            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            // Inner panel
            result = this.DrawRectangle(model.InnerWidth, model.InnerHeight, model.InnerLevelNumber, model.InnerLevelName);
            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            // Grooves


            return Result.Ok();
        }

        /// <summary>Draw rectangle.</summary>
        ///
        /// <remarks>Mick George, 11/11/2017.</remarks>
        ///
        /// <param name="width"> The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="level"> The level.</param>
        /// <param name="name">  The name.</param>
        ///
        /// <returns>A Result.</returns>
        private Result DrawRectangle(double width, double height, int level, string name)
        {
            // TODO: Check/Set construction plane to TOP

            var rect = GeometryCreationManager.CreateRectangle(new Point3D(0, 0, 0), new Point3D(width, height, 0));
            if (rect.Any())
            {
                foreach (var line in rect)
                {
                    line.Color = 11;
                    line.Level = level;
                    line.Commit();
                }

                return !LevelsManager.SetLevelName(level, name) ?
                    Result.Fail($"Failed to set level name on {level} - {name}") :
                    Result.Ok();
            }

            return Result.Fail($"Failed to create geometry on level {level}");
        }
    }
}