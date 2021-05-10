// <copyright file="A4Translations.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Better079.Configs.SubConfigs
{
    using System.ComponentModel;

    /// <summary>
    /// All of the translation configs for ability four.
    /// </summary>
    public class A4Translations
    {
        /// <summary>
        /// Gets or sets the help information for the ability.
        /// </summary>
        public string Help { get; set; } = "Flashes nearby players";

        /// <summary>
        /// Gets or sets the message to send when the ability is executed.
        /// </summary>
        public string Run { get; set; } = "Flashing...";

        /// <summary>
        /// Gets or sets the message to be sent when the ability is on cooldown.
        /// </summary>
        [Description("The message to be sent when the ability is on cooldown.")]
        public string OnCooldown { get; set; } = "You must wait $seconds seconds to use this command.";
    }
}