// -----------------------------------------------------------------------
// <copyright file="A4.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Abilities
{
    using Better079.API;
    using Better079.Configs;
    using Exiled.API.Features;
    using Exiled.API.Features.Items;

    /// <summary>
    /// Ability four. Spawns a flashbang on Scp079's active camera.
    /// </summary>
    public class A4 : Ability
    {
        /// <inheritdoc />
        public override string Name { get; set; } = nameof(A4);

        /// <inheritdoc />
        public override string Description { get; set; } = "Flashes nearby players";

        /// <inheritdoc />
        public override int Cooldown { get; set; } = 30;

        /// <inheritdoc />
        public override int RequiredEnergy { get; set; } = 100;

        /// <inheritdoc />
        public override int RequiredLevel { get; set; } = 3;

        /// <inheritdoc />
        public override int Experience { get; set; } = 0;

        /// <summary>
        /// Gets or sets the translations for ability four.
        /// </summary>
        public A4Translations Translations { get; set; } = new A4Translations();

        /// <inheritdoc />
        protected override bool RunAbility(Player scp079, out string response)
        {
            new FlashGrenade(ItemType.GrenadeFlash, scp079)
            {
                FuseTime = 0.5f,
            }.SpawnActive(scp079.Camera.transform.position, scp079);

            response = Translations.Run;
            return true;
        }
    }
}