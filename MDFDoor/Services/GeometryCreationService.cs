// <copyright file="GeometryCreationService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Services
{
    using System.Linq;
    using Mastercam.Curves;
    using Mastercam.GeometryUtility;
    using Mastercam.IO;
    using Mastercam.Math;
    using Shared;
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
            var result = this.DrawRectangle(door.Width, door.Height, 0, 0, door.OuterLevelNumber, door.OuterLevelName, 10);
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
            var result = this.DrawRectangle(door.Width, door.Height, 0, 0, door.OuterLevelNumber, door.OuterLevelName, 10);
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
            var result = this.DrawRectangle(door.Width, door.Height, 0, 0, door.OuterLevelNumber, door.OuterLevelName, 10);
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
            var result = this.DrawRectangle(door.Width, door.Height, 0, 0, door.OuterLevelNumber, door.OuterLevelName, 10);
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
            var result = this.DrawRectangle(door.Width, door.Height, 0, 0, door.OuterLevelNumber, door.OuterLevelName, 10);
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
            var result = this.DrawRectangle(door.Width, door.Height, 0, 0, door.OuterLevelNumber, door.OuterLevelName, 10);
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
            var result = this.DrawRectangle(
                door.Width,
                door.Height,
                0,
                0,
                door.OuterLevelNumber,
                door.OuterLevelName,
                10);

            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            // Inner panel
            result = this.DrawRectangle(
                door.InnerWidth + door.RightSideWidth,
                door.BottomRailWidth, door.LeftStileWidth,
                door.InnerHeight + door.TopRailWidth,
                door.InnerLevelNumber, door.InnerLevelName,
                12);

            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            // Grooves
            result = this.DrawShakerEleganceGrooves(door);
            if (result.IsFailure)
            {
                return Result.Fail(result.Error);
            }

            return Result.Ok();
        }

        /// <summary>Draw shaker elegance grooves.</summary>
        ///
        /// <remarks>Mick George, 11/16/2017.</remarks>
        ///
        /// <param name="door">The model.</param>
        ///
        /// <returns>A Result.</returns>
        private Result DrawShakerEleganceGrooves(ShakerElegance door)
        {
            var bottomLeftStartPosition = new Point3D(door.LeftStileWidth, 0, 0);
            var bottomLeftEndPosition = new Point3D(door.LeftStileWidth, door.BottomRailWidth, 0);

            var bottomRightStartPosition = new Point3D(door.Width - door.RightSideWidth, 0, 0);
            var bottomRightEndPosition = new Point3D(door.Width - door.RightSideWidth, door.BottomRailWidth, 0);

            var topLeftStartPosition = new Point3D(door.LeftStileWidth, door.Height - door.TopRailWidth, 0);
            var topLeftEndPosition = new Point3D(door.LeftStileWidth, door.Height, 0);

            var topRightStartPosition = new Point3D(door.Width - door.RightSideWidth, door.Height - door.TopRailWidth, 0);
            var topRightEndPosition = new Point3D(door.Width - door.RightSideWidth, door.Height, 0);

            var bottomLeft = new LineGeometry(bottomLeftStartPosition, bottomLeftEndPosition) { Level = door.GrooveLevelNumber, Color = 9 };
            var bottomRight = new LineGeometry(bottomRightStartPosition, bottomRightEndPosition) { Level = door.GrooveLevelNumber, Color = 9 };

            var topLeft = new LineGeometry(topLeftStartPosition, topLeftEndPosition) { Level = door.GrooveLevelNumber, Color = 9 };
            var topRight = new LineGeometry(topRightStartPosition, topRightEndPosition) { Level = door.GrooveLevelNumber, Color = 9 };

            bottomLeft.Commit();
            topLeft.Commit();
            topRight.Commit();
            bottomRight.Commit();

            LevelsManager.SetLevelName(bottomLeft.Level, door.GrooveLevelName);
            LevelsManager.SetLevelName(topLeft.Level, door.GrooveLevelName);
            LevelsManager.SetLevelName(topRight.Level, door.GrooveLevelName);
            LevelsManager.SetLevelName(bottomRight.Level, door.GrooveLevelName);

            LevelsManager.SetLevelSetName(bottomLeft.Level, DoorNames.ShakerElegance);

            return Result.Ok();
        }

        /// <summary>Draw rectangle.</summary>
        ///
        /// <remarks>Mick George, 11/16/2017.</remarks>
        ///
        /// <param name="width">       The width.</param>
        /// <param name="height">      The height.</param>
        /// <param name="leftOffset">  The left offset.</param>
        /// <param name="bottomOffset">The bottom offset.</param>
        /// <param name="level">       The level.</param>
        /// <param name="name">        The name.</param>
        /// <param name="colour">      The colour.</param>
        ///
        /// <returns>A Result.</returns>
        private Result DrawRectangle(double width, double height, double leftOffset, double bottomOffset, int level, string name, int colour)
        {
            // TODO: Check/Set construction plane to TOP

            var rect = GeometryCreationManager.CreateRectangle(new Point3D(leftOffset, bottomOffset, 0), new Point3D(width, height, 0));
            if (rect.Any())
            {
                foreach (var line in rect)
                {
                    line.Color = colour;
                    line.Level = level;
                    line.Commit();
                }

                LevelsManager.SetLevelSetName(level, DoorNames.ShakerElegance);

                return !LevelsManager.SetLevelName(level, name) ?
                    Result.Fail($"Failed to set level name on {level} - {name}") :
                    Result.Ok();
            }

            return Result.Fail($"Failed to create geometry on level {level}");
        }
    }
}