// -----------------------------------------------------------------------
// <copyright file="A1Translations.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Configs
{
    using System.ComponentModel;

    /// <summary>
    /// All of the translation configs for ability one.
    /// </summary>
    public class A1Translations
    {
        /// <summary>
        /// Gets or sets the help information for the ability.
        /// </summary>
        [Description("The help information for the ability.")]
        public string Help { get; set; } = "Teleports you to another SCP.";

        /// <summary>
        /// Gets or sets the message to send when the ability is executed.
        /// </summary>
        [Description("The message to send when the ability is executed.")]
        public string Run { get; set; } = "Teleporting...";

        /// <summary>
        /// Gets or sets the message when no SCPs can be teleported to.
        /// </summary>
        [Description("The message when no SCPs can be teleported to.")]
        public string Fail { get; set; } = "Unable to find any SCP to teleport to.";

        /// <summary>
        /// Gets or sets the message to be sent when the ability is on cooldown.
        /// </summary>
        [Description("The message to be sent when the ability is on cooldown.")]
        public string OnCooldown { get; set; } = "You must wait $seconds seconds to use this command.";
    }
}