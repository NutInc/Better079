// -----------------------------------------------------------------------
// <copyright file="A2Configs.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Configs
{
    using System.ComponentModel;
    using Exiled.API.Enums;

    /// <summary>
    /// All of the configs for ability two.
    /// </summary>
    public class A2Configs
    {
        /// <summary>
        /// Gets or sets the minimum level to run this command.
        /// </summary>
        [Description("The minimum level to run this command.")]
        public int RequiredLevel { get; set; } = 2;

        /// <summary>
        /// Gets or sets the amount of energy required to run this command.
        /// </summary>
        [Description("The amount of energy required to run this command.")]
        public int RequiredEnergy { get; set; } = 75;

        /// <summary>
        /// Gets or sets the cooldown for the command.
        /// </summary>
        [Description("The cooldown for the command.")]
        public double Cooldown { get; set; } = 60f;

        /// <summary>
        /// Gets or sets the rooms where this ability cannot be used.
        /// </summary>
        [Description("The rooms where this ability cannot be used.")]
        public RoomType[] BlacklistedRooms { get; set; } =
        {
            RoomType.Lcz914,
            RoomType.Hcz106,
            RoomType.EzGateA,
            RoomType.EzGateB,
            RoomType.Surface,
        };

        /// <summary>
        /// Gets or sets the amount of experience granted per gas kill.
        /// </summary>
        [Description("The amount of experience granted per gas kill.")]
        public float Exp { get; set; } = 35;

        /// <summary>
        /// Gets or sets the amount of time before the room is gassed.
        /// </summary>
        [Description("The amount of time before the room is gassed.")]
        public int Timer { get; set; } = 5;

        /// <summary>
        /// Gets or sets the amount of time that a room is gassed.
        /// </summary>
        [Description("The amount of time that a room is gassed.")]
        public int GasTimer { get; set; } = 10;

        /// <summary>
        /// Gets or sets the amount of damage to be dealt every half of a second.
        /// </summary>
        [Description("The amount of damage to be dealt every half seconds.")]
        public float DamagePerTick { get; set; } = 10f;

        /// <summary>
        /// Gets or sets the translations for ability two.
        /// </summary>
        [Description("The translations for ability two.")]
        public A2Translations Translations { get; set; } = new A2Translations();
    }
}