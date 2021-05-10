// <copyright file="Plugin.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Better079
{
    using System;
    using Exiled.API.Features;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Configs.Config>
    {
        private static readonly Plugin InstanceValue = new Plugin();

        private Plugin()
        {
        }

        /// <inheritdoc/>
        public override string Name { get; } = "Better079";

        /// <inheritdoc/>
        public override string Author { get; } = "VirtualBrightPlayz, upgraded by Build";

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 2, 3);

        /// <summary>
        /// Gets a static instance of the <see cref="Plugin"/> class.
        /// </summary>
        internal static Plugin Instance { get; } = InstanceValue;

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted += EventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Player.Spawning += EventHandlers.OnSpawning;
            Exiled.Events.Handlers.Scp079.GainingExperience += EventHandlers.OnGainingExperience;
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= EventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Player.Spawning -= EventHandlers.OnSpawning;
            Exiled.Events.Handlers.Scp079.GainingExperience -= EventHandlers.OnGainingExperience;
            base.OnDisabled();
        }
    }
}
