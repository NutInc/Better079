// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Better079.Configs
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Better079.Configs.SubConfigs;
    using Exiled.API.Interfaces;

    /// <inheritdoc cref="IConfig"/>
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets additional experience for SCP-079 interactions.
        /// </summary>
        [Description("SCP-079 XP boost, it does not affect the exp of the memetic agent | Default: KillAssist = 0 DirectKill = 1, HardwareHack = 2, AdminCheat = 3, GeneralInteractions = 4, PocketAssist = 5")]
        public Dictionary<ExpGainType, float> ExperienceGain { get; set; } = new Dictionary<ExpGainType, float>
        {
            [ExpGainType.GeneralInteractions] = 5,
            [ExpGainType.KillAssist] = 2,
        };

        /// <summary>
        /// Gets or sets the non-ability specific translations.
        /// </summary>
        [Description("The non-ability specific translations.")]
        public MainTranslations MainTranslations { get; set; } = new MainTranslations();

        /// <summary>
        /// Gets or sets the configs for ability one.
        /// </summary>
        [Description("The configs for ability one (SCP Teleportation).")]
        public A1Configs A1Configs { get; set; } = new A1Configs();

        /// <summary>
        /// Gets or sets the configs for ability two.
        /// </summary>
        [Description("The configs for ability two (Gassing of rooms).")]
        public A2Configs A2Configs { get; set; } = new A2Configs();

        /// <summary>
        /// Gets or sets the configs for ability three.
        /// </summary>
        [Description("The configs for ability three (Blackout).")]
        public A3Configs A3Configs { get; set; } = new A3Configs();

        /// <summary>
        /// Gets or sets the configs for ability four.
        /// </summary>
        [Description("The configs for ability four (Flashing).")]
        public A4Configs A4Configs { get; set; } = new A4Configs();
    }
}