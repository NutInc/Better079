// -----------------------------------------------------------------------
// <copyright file="A3.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Abilities
{
    using Better079.API;
    using Better079.Configs;
    using Exiled.API.Features;

    /// <summary>
    /// Ability three. Disables all lights for the configured duration.
    /// </summary>
    public class A3 : Ability
    {
        /// <inheritdoc />
        public override string Name { get; set; } = nameof(A3);

        /// <inheritdoc />
        public override string Description { get; set; } = "Shuts off all lights in the facility";

        /// <inheritdoc />
        public override int Cooldown { get; set; } = 60;

        /// <inheritdoc />
        public override int RequiredEnergy { get; set; } = 100;

        /// <inheritdoc />
        public override int RequiredLevel { get; set; } = 3;

        /// <inheritdoc />
        public override int Experience { get; set; } = 0;

        /// <summary>
        /// Gets or sets how long the lights should be disabled.
        /// </summary>
        public float Duration { get; set; } = 30f;

        /// <summary>
        /// Gets or sets the translations for ability three.
        /// </summary>
        public A3Translations Translations { get; set; } = new A3Translations();

        /// <inheritdoc />
        protected override bool RunAbility(Player scp079, out string response)
        {
            Map.TurnOffAllLights(Duration);
            response = Translations.Run;
            return true;
        }
    }
}