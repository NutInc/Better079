// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079
{
    using System;
    using Exiled.API.Features;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config, Translation>
    {
        private EventHandlers eventHandlers;

        /// <summary>
        /// Gets a static instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Instance = this;
            RegisterAbilities();
            eventHandlers = new EventHandlers();
            Exiled.Events.Handlers.Player.Spawning += eventHandlers.OnSpawning;
            Exiled.Events.Handlers.Scp079.GainingExperience += eventHandlers.OnGainingExperience;
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            UnregisterAbilities();
            Exiled.Events.Handlers.Player.Spawning -= eventHandlers.OnSpawning;
            Exiled.Events.Handlers.Scp079.GainingExperience -= eventHandlers.OnGainingExperience;
            eventHandlers = null;
            Instance = null;
            base.OnDisabled();
        }

        private void RegisterAbilities()
        {
            Config.A1.TryRegister();
            Config.A2.TryRegister();
            Config.A3.TryRegister();
            Config.A4.TryRegister();
        }

        private void UnregisterAbilities()
        {
            Config.A1.TryUnregister();
            Config.A2.TryUnregister();
            Config.A3.TryUnregister();
            Config.A4.TryUnregister();
        }
    }
}
