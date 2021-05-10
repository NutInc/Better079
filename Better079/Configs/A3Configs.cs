// -----------------------------------------------------------------------
// <copyright file="A3Configs.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Configs
{
    using System.ComponentModel;

    /// <summary>
    /// All of the configs for ability three.
    /// </summary>
    public class A3Configs
    {
        /// <summary>
        /// Gets or sets the minimum level to run this command.
        /// </summary>
        public int RequiredLevel { get; set; } = 1;

        /// <summary>
        /// Gets or sets the amount of energy required to run this command.
        /// </summary>
        [Description("The amount of energy required to run this command.")]
        public int RequiredEnergy { get; set; } = 100;

        /// <summary>
        /// Gets or sets the cooldown for the command.
        /// </summary>
        [Description("The cooldown for the command.")]
        public double Cooldown { get; set; } = 60;

        /// <summary>
        /// Gets or sets the duration of the blackout.
        /// </summary>
        [Description("The duration of the blackout.")]
        public float Duration { get; set; } = 30f;

        /// <summary>
        /// Gets or sets the translations for ability three.
        /// </summary>
        public A3Translations Translations { get; set; } = new A3Translations();
    }
}