// <copyright file="ExcelService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    public class ExcelService : IExcelService
    {
        /// <summary>
        /// Exports the T of type door to disk
        /// </summary>
        /// <typeparam name="T">The door type</typeparam>
        /// <param name="door">The door payload</param>
        public void Export<T>(T door)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Reads a door type from disk
        /// </summary>
        /// <typeparam name="T">The door type</typeparam>
        /// <returns>A door payload</returns>
        public T Read<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}