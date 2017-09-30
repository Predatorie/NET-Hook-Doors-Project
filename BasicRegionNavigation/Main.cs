// <copyright file="Main.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors
{
    using Mastercam.App;
    using Mastercam.App.Types;

    public class Main : NetHook3App
    {
        #region Public Override Methods

        /// <summary>
        /// The main entry point for your NETHook.
        /// </summary>
        /// <param name="param">System parameter.</param>
        /// <returns>A <c>MCamReturn</c> return type representing the outcome of your NetHook application.</returns>
        public override MCamReturn Run(int param)
        {
            var b = new Bootstrapper();
            b.Run();

            return MCamReturn.NoErrors;
        }

        #endregion
    }
}