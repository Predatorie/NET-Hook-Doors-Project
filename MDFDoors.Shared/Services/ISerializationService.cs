// <copyright file="ISerializationService.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Services
{
    using Models;

    public interface ISerializationService
    {
        Result SerializeDoorStyle<T>();

        Result<T> DeserializeDoorStyle<T>();
    }
}