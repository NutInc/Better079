// <copyright file="A4Configs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Better079.Configs.SubConfigs
{
    /// <summary>
    /// All of the configs for ability four.
    /// </summary>
    public class A4Configs
    {
        /// <summary>
        /// Gets or sets the minimum level to run this command.
        /// </summary>
        public int RequiredLevel { get; set; } = 1;

        /// <summary>
        /// Gets or sets the amount of energy to run this command.
        /// </summary>
        public int RequiredEnergy { get; set; } = 40;

        /// <summary>
        /// Gets or sets the cooldown for the command.
        /// </summary>
        public double Cooldown { get; set; } = 60;

        /// <summary>
        /// Gets or sets the translations for ability four.
        /// </summary>
        public A4Translations Translations { get; set; } = new A4Translations();
    }
}