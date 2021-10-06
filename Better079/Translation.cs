// -----------------------------------------------------------------------
// <copyright file="Translation.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Translation : ITranslation
    {
        /// <summary>
        /// Gets or sets the spawn message that SCP-079 receives when they spawn.
        /// </summary>
        [Description("The spawn message that SCP-079 receives when they spawn.")]
        public string SpawnMsg { get; set; } = "<color=#00ff00>[Better079] Type \".079\" in the console to view abilities.</color>";

        /// <summary>
        /// Gets or sets the translation for when SCP-079 is on cooldown for the ability.
        /// </summary>
        [Description("The translation for when SCP-079 is on cooldown for the ability.")]
        public string OnCooldown { get; set; } = "You must wait {duration} seconds until you can use this command.";

        /// <summary>
        /// Gets or sets the translation for when SCP-079 is not at the required level for the ability.
        /// </summary>
        [Description("The translation for when SCP-079 is not at the required level for the ability.")]
        public string TierRequired { get; set; } = "Tier {tier} is required.";

        /// <summary>
        /// Gets or sets the translation for when SCP-079 does not have enough power for the ability.
        /// </summary>
        [Description("The translation for when SCP-079 does not have enough power for the ability.")]
        public string EnergyRequired { get; set; } = "{energy} energy is required.";
    }
}