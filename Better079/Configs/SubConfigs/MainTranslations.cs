// <copyright file="MainTranslations.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Better079.Configs.SubConfigs
{
    using System.ComponentModel;

    /// <summary>
    /// Contains non-ability specific translations.
    /// </summary>
    public class MainTranslations
    {
        /// <summary>
        /// Gets or sets the aliases for the 079 command.
        /// </summary>
        [Description("The aliases for the 079 command.")]
        public string[] Aliases { get; set; } = { "s079", "b079" };

        /// <summary>
        /// Gets or sets the spawn message that SCP-079 receives when they spawn.
        /// </summary>
        [Description("The spawn message that SCP-079 receives when they spawn.")]
        public string SpawnMsg { get; set; } = "<color=#00ff00>[Better079] Type \".079 help\" in the console for more abilities.</color>";

        /// <summary>
        /// Gets or sets the title of the help menu.
        /// </summary>
        [Description("The title of the help menu.")]
        public string HelpTitle { get; set; } = "Abilities/Commands:";

        /// <summary>
        /// Gets or sets the translation for when SCP-079 is not at the required level for the ability.
        /// </summary>
        [Description("The translation for when SCP-079 is not at the required level for the ability.")]
        public string TierRequired { get; set; } = "Tier $tier is required.";

        /// <summary>
        /// Gets or sets the translation for when SCP-079 does not have enough power for the ability.
        /// </summary>
        [Description("The translation for when SCP-079 does not have enough power for the ability.")]
        public string NoPower { get; set; } = "$energy energy is required.";
    }
}