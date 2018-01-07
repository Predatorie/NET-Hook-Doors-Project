// <copyright file="IExcelService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    public interface IExcelService
    {
        void Export<T>(T door);
    }
}