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

            if (model.GetType() == typeof(Shaker))
            {
                return this.CreateShaker((Shaker)model);
            }

            if (model.GetType() == typeof(ShakerEuro05))
            {
                return this.CreateShakerEuro05((ShakerEuro05)model);
            }

            if (model.GetType() == typeof(ShakerExotic))
            {
                return this.CreateShakerExotic((ShakerExotic)model);
            }

            if (model.GetType() == typeof(ShakerFinest))
            {
                return this.CreateShakerFinest((ShakerFinest)model);
            }
            
            return Result.Fail($"Unkown Door Style {model.ToString()}");
        }

        /// <summary>Creates shaker centry.</summary>
        /// <param name="door">The model.</param>
        /// <returns>The new shaker centry.</returns>
        private Result CreateShakerCentry(ShakerCentry door)
        {
            // Outer panel
            var result = this.DrawRectangle(door.Width, door.Height, door.OuterLevelNumber, door.OuterLevelName);
            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            return Result.Ok();
        }

        /// <summary>Creates shaker country.</summary>
        /// <param name="door">The model.</param>
        /// <returns>The new shaker country.</returns>
        private Result CreateShakerCountry(ShakerCountry door)
        {
            // Outer panel
            var result = this.DrawRectangle(door.Width, door.Height, door.OuterLevelNumber, door.OuterLevelName);
            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            return Result.Ok();
        }

        /// <summary>Creates shaker finest.</summary>
        /// <param name="door">The model.</param>
        /// <returns>The new shaker finest.</returns>
        private Result CreateShakerFinest(ShakerFinest door)
        {
            // Outer panel
            var result = this.DrawRectangle(door.Width, door.Height, door.OuterLevelNumber, door.OuterLevelName);
            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            return Result.Ok();
        }

        /// <summary>Creates shaker exotic.</summary>
        /// <param name="door">The model.</param>
        /// <returns>The new shaker exotic.</returns>
        private Result CreateShakerExotic(ShakerExotic door)
        {
            // Outer panel
            var result = this.DrawRectangle(door.Width, door.Height, door.OuterLevelNumber, door.OuterLevelName);
            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            return Result.Ok();
        }

        /// <summary>Creates shaker euro 05.</summary>
        /// <param name="door">The model.</param>
        /// <returns>The new shaker euro 05.</returns>
        private Result CreateShakerEuro05(ShakerEuro05 door)
        {
            // Outer panel
            var result = this.DrawRectangle(door.Width, door.Height, door.OuterLevelNumber, door.OuterLevelName);
            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            return Result.Ok();
        }

        /// <summary>Creates a shaker.</summary>
        /// <param name="door">The model.</param>
        /// <returns>The new shaker.</returns>
        private Result CreateShaker(Shaker door)
        {
            // Outer panel
            var result = this.DrawRectangle(door.Width, door.Height, door.OuterLevelNumber, door.OuterLevelName);
            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            return Result.Ok();
        }

        /// <summary>Creates shaker elegance.</summary>
        ///
        /// <remarks>Mick George, 11/11/2017.</remarks>
        ///
        /// <param name="door">The model.</param>
        ///
        /// <returns>The new shaker elegance.</returns>
        private Result CreateShakerElegance(ShakerElegance door)
        {
            // Outer panel
            var result = this.DrawRectangle(door.Width, door.Height, door.OuterLevelNumber, door.OuterLevelName);
            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            // Inner panel
            result = this.DrawRectangle(door.InnerWidth, door.InnerHeight, door.InnerLevelNumber, door.InnerLevelName);
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