// -----------------------------------------------------------------------
// <copyright file="A3Translations.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Configs
{
    using System.ComponentModel;

    /// <summary>
    /// All of the translation configs for ability three.
    /// </summary>
    public class A3Translations
    {
        /// <summary>
        /// Gets or sets the help information for the ability.
        /// </summary>
        public string Help { get; set; } = "Shuts off all lights in the facility";

        /// <summary>
        /// Gets or sets the message to send when the ability is executed.
        /// </summary>
        public string Run { get; set; } = "Overcharging...";

        /// <summary>
        /// Gets or sets the message to be sent when the ability is on cooldown.
        /// </summary>
        [Description("The message to be sent when the ability is on cooldown.")]
        public string OnCooldown { get; set; } = "You must wait $seconds seconds to use this command.";
    }
}