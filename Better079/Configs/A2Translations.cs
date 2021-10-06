// -----------------------------------------------------------------------
// <copyright file="A2Translations.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Configs
{
    using System.ComponentModel;

    /// <summary>
    /// All of the translation configs for ability two.
    /// </summary>
    public class A2Translations
    {
        /// <summary>
        /// Gets or sets the message to send when the ability is executed.
        /// </summary>
        [Description("The message to send when the ability is executed.")]
        public string Run { get; set; } = "Deploying memetic kill agent.";

        /// <summary>
        /// Gets or sets the message to send when the ability fails.
        /// </summary>
        [Description("The message to send when the ability fails.")]
        public string Fail { get; set; } = "You may not use this command in a blacklisted room.";

        /// <summary>
        /// Gets or sets the message to be sent to players before the room is gassed.
        /// </summary>
        [Description("The message to be sent to players before the room is gassed.")]
        public string Warn { get; set; } = "<color=#ff0000>This room will be gassed in $seconds seconds.</color>";

        /// <summary>
        /// Gets or sets the message to be sent to players when the gas is activated.
        /// </summary>
        [Description("The message to be sent to players when the gas is activated.")]
        public string Active { get; set; } = "<color=#ff0000>GAS ACTIVATED.</color>";
    }
}