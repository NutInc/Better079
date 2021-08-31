// -----------------------------------------------------------------------
// <copyright file="A3.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Commands.SubCommands
{
    using System;
    using CommandSystem;
    using Exiled.API.Features;
    using RemoteAdmin;

    /// <summary>
    /// The third ability. Turns the lights off across the facility.
    /// </summary>
    public class A3 : ICommand
    {
        /// <inheritdoc/>
        public string Command { get; } = "a3";

        /// <inheritdoc/>
        public string[] Aliases { get; } = Array.Empty<string>();

        /// <inheritdoc/>
        public string Description { get; } = "The third ability. Turns the lights off across the facility.";

        /// <summary>
        /// Gets or sets the time that the cooldown wears off.
        /// </summary>
        internal static DateTimeOffset Cooldown { get; set; }

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(((PlayerCommandSender)sender).ReferenceHub);
            if (player.Role != RoleType.Scp079)
            {
                response = "You are not an Scp079!";
                return false;
            }

            var a3Configs = Plugin.Instance.Config.A3Configs;

            if (!Methods.SufficientLevel(player, a3Configs.RequiredLevel))
            {
                response = Plugin.Instance.Config.MainTranslations.TierRequired.Replace("$tier", a3Configs.RequiredLevel.ToString());
                return false;
            }

            if (DateTimeOffset.UtcNow < Cooldown)
            {
                response = a3Configs.Translations.OnCooldown.Replace("$seconds", (DateTimeOffset.UtcNow - Cooldown).ToString("ss"));
                return false;
            }

            if (!Methods.SufficientEnergy(player, a3Configs.RequiredEnergy))
            {
                response = Plugin.Instance.Config.MainTranslations.NoPower.Replace("$energy", a3Configs.RequiredEnergy.ToString());
                return false;
            }

            Map.TurnOffAllLights(Plugin.Instance.Config.A3Configs.Duration);
            Cooldown = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(a3Configs.Cooldown);
            response = Plugin.Instance.Config.A3Configs.Translations.Run;
            return true;
        }
    }
}