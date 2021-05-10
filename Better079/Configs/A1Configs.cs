// -----------------------------------------------------------------------
// <copyright file="A1Configs.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Configs
{
    using System.ComponentModel;

    /// <summary>
    /// All of the configs for ability one.
    /// </summary>
    public class A1Configs
    {
        /// <summary>
        /// Gets or sets the minimum level to run this command.
        /// </summary>
        [Description("The minimum level to run this command.")]
        public int RequiredLevel { get; set; } = 1;

        /// <summary>
        /// Gets or sets the amount of energy required to run this command.
        /// </summary>
        [Description("The amount of energy required to run this command.")]
        public int RequiredEnergy { get; set; } = 20;

        /// <summary>
        /// Gets or sets the cooldown for the command.
        /// </summary>
        [Description("The cooldown for the command.")]
        public double Cooldown { get; set; } = 0;

        /// <summary>
        /// Gets or sets the maximum distance that an SCP can be from a camera to be in range.
        /// </summary>
        [Description("The maximum distance that an SCP can be from a camera to be in range.")]
        public float MaximumDistance { get; set; } = 15f;

        /// <summary>
        /// Gets or sets the translations for ability one.
        /// </summary>
        [Description("The translations for ability one.")]
        public A1Translations Translations { get; set; } = new A1Translations();
    }
}