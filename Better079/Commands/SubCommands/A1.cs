// <copyright file="A1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Better079.Commands.SubCommands
{
    using System;
    using System.Collections.Generic;
    using CommandSystem;
    using Exiled.API.Features;
    using RemoteAdmin;
    using UnityEngine;

    /// <summary>
    /// The first ability. Teleports the user to another scp.
    /// </summary>
    public class A1 : ICommand
    {
        /// <inheritdoc/>
        public string Command { get; } = "a1";

        /// <inheritdoc/>
        public string[] Aliases { get; } = Array.Empty<string>();

        /// <inheritdoc/>
        public string Description { get; } = "The first ability. Teleports the user to another scp.";

        /// <summary>
        /// Gets or sets the time that the cooldown wears off.
        /// </summary>
        internal static DateTimeOffset Cooldown { get; set; }

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(((PlayerCommandSender)sender).ReferenceHub);
            var a1Configs = Plugin.Instance.Config.A1Configs;

            if (!Methods.SufficientLevel(player, a1Configs.RequiredLevel))
            {
                response = Plugin.Instance.Config.MainTranslations.TierRequired.Replace("$tier", a1Configs.RequiredLevel.ToString());
                return false;
            }

            if (DateTimeOffset.UtcNow < Cooldown)
            {
                response = a1Configs.Translations.OnCooldown.Replace("$seconds", (DateTimeOffset.UtcNow - Cooldown).ToString("ss"));
                return false;
            }

            if (!Methods.SufficientEnergy(player, a1Configs.RequiredEnergy))
            {
                response = Plugin.Instance.Config.MainTranslations.NoPower.Replace("$energy", a1Configs.RequiredEnergy.ToString());
                return false;
            }

            var cameras = GetScpCameras();
            if (cameras.Count == 0)
            {
                response = a1Configs.Translations.Fail;
                return false;
            }

            player.Energy -= a1Configs.RequiredEnergy;
            player.Camera = cameras[UnityEngine.Random.Range(0, cameras.Count)];
            Cooldown = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(a1Configs.Cooldown);
            response = a1Configs.Translations.Run;
            return true;
        }

        private static List<Camera079> GetScpCameras()
        {
            List<Camera079> cams = new List<Camera079>();
            foreach (var ply in Player.List)
            {
                if (ply.IsScp && !ply.SessionVariables.ContainsKey("IsNPC") && ply.Role != RoleType.Scp079)
                {
                    foreach (Camera079 cam in Map.Cameras)
                    {
                        if (Vector3.Distance(cam.transform.position, ply.Position) <= Plugin.Instance.Config.A1Configs.MaximumDistance)
                        {
                            cams.Add(cam);
                        }
                    }
                }
            }

            return cams;
        }
    }
}