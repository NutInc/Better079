// -----------------------------------------------------------------------
// <copyright file="A4.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Commands.SubCommands
{
    using System;
    using System.Linq;
    using CommandSystem;
    using Exiled.API.Features;
    using Grenades;
    using Mirror;
    using RemoteAdmin;
    using UnityEngine;

    /// <summary>
    /// The fourth ability. Spawns flash grenades on the active camera.
    /// </summary>
    public class A4 : ICommand
    {
        /// <inheritdoc/>
        public string Command { get; } = "a4";

        /// <inheritdoc/>
        public string[] Aliases { get; } = Array.Empty<string>();

        /// <inheritdoc/>
        public string Description { get; } = "The fourth ability. Spawns flash grenades on the active camera.";

        /// <summary>
        /// Gets or sets the time that the cooldown wears off.
        /// </summary>
        internal static DateTimeOffset Cooldown { get; set; }

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(((PlayerCommandSender)sender).ReferenceHub);
            var a4Configs = Plugin.Instance.Config.A4Configs;

            if (!Methods.SufficientLevel(player, a4Configs.RequiredLevel))
            {
                response = Plugin.Instance.Config.MainTranslations.TierRequired.Replace("$tier", a4Configs.RequiredLevel.ToString());
                return false;
            }

            if (DateTimeOffset.UtcNow < Cooldown)
            {
                response = a4Configs.Translations.OnCooldown.Replace("$seconds", (DateTimeOffset.UtcNow - Cooldown).ToString("ss"));
                return false;
            }

            if (!Methods.SufficientEnergy(player, a4Configs.RequiredEnergy))
            {
                response = Plugin.Instance.Config.MainTranslations.NoPower.Replace("$energy", a4Configs.RequiredEnergy.ToString());
                return false;
            }

            SpawnFlash(player);
            Cooldown = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(a4Configs.Cooldown);
            response = a4Configs.Translations.Run;
            return true;
        }

        private static void SpawnFlash(Player player)
        {
            Vector3 position = player.Camera.gameObject
                ? player.Camera.transform.position
                : player.ReferenceHub.scp079PlayerScript.transform.position;

            GrenadeManager gm = player.GrenadeManager;
            GrenadeSettings settings = gm.availableGrenades.First(g => g.inventoryID == ItemType.GrenadeFlash);
            FlashGrenade flash = UnityEngine.Object.Instantiate(settings.grenadeInstance).GetComponent<FlashGrenade>();
            flash.fuseDuration = 0.5f;
            flash.InitData(gm, Vector3.zero, Vector3.zero);
            flash.transform.position = position;
            NetworkServer.Spawn(flash.gameObject);
        }
    }
}