// -----------------------------------------------------------------------
// <copyright file="A2.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Commands.SubCommands
{
    using System;
    using System.Collections.Generic;
    using CommandSystem;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using MEC;
    using RemoteAdmin;

    /// <summary>
    /// The second ability. Gasses the current room.
    /// </summary>
    public class A2 : ICommand
    {
        /// <inheritdoc/>
        public string Command { get; } = "a2";

        /// <inheritdoc/>
        public string[] Aliases { get; } = Array.Empty<string>();

        /// <inheritdoc/>
        public string Description { get; } = "The second ability. Gasses the current room.";

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

            var a2Configs = Plugin.Instance.Config.A2Configs;

            if (!Methods.SufficientLevel(player, a2Configs.RequiredLevel))
            {
                response = Plugin.Instance.Config.MainTranslations.TierRequired.Replace("$tier", a2Configs.RequiredLevel.ToString());
                return false;
            }

            if (DateTimeOffset.UtcNow < Cooldown)
            {
                response = a2Configs.Translations.OnCooldown.Replace("$seconds", (DateTimeOffset.UtcNow - Cooldown).ToString("ss"));
                return false;
            }

            Room currentRoom = Map.FindParentRoom(player.ReferenceHub.gameObject);
            if (a2Configs.BlacklistedRooms.Contains(currentRoom.Type))
            {
                response = a2Configs.Translations.Fail;
                return false;
            }

            if (!Methods.SufficientEnergy(player, a2Configs.RequiredEnergy))
            {
                response = Plugin.Instance.Config.MainTranslations.NoPower.Replace("$energy", a2Configs.RequiredEnergy.ToString());
                return false;
            }

            player.Energy -= a2Configs.RequiredEnergy;
            Timing.RunCoroutine(GasRoom(currentRoom, player));
            Cooldown = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(a2Configs.Cooldown);
            response = a2Configs.Translations.Run;
            return true;
        }

        private static IEnumerator<float> GasRoom(Room room, Player scp079)
        {
            foreach (var item in room.Doors)
            {
                item.Open = true;
                item.Base.NetworkActiveLocks = 1;
            }

            for (int i = Plugin.Instance.Config.A2Configs.Timer; i > 0f; i--)
            {
                foreach (var player in room.Players)
                {
                    if (!player.IsScp)
                    {
                        player.ShowHint(Plugin.Instance.Config.A2Configs.Translations.Warn.Replace("$seconds", i.ToString()), 1f);
                    }
                }

                yield return Timing.WaitForSeconds(1f);
            }

            foreach (var item in room.Doors)
            {
                item.Open = false;
                item.Base.NetworkActiveLocks = 1;
            }

            foreach (var player in room.Players)
            {
                if (player.Team != Team.SCP && player.CurrentRoom != null && player.CurrentRoom.Transform == room.Transform)
                {
                    player.ShowHint(Plugin.Instance.Config.A2Configs.Translations.Active, 5f);
                }
            }

            for (int i = 0; i < Plugin.Instance.Config.A2Configs.GasTimer * 2; i++)
            {
                foreach (var player in room.Players)
                {
                    if (!player.IsScp)
                    {
                        player.Hurt(Plugin.Instance.Config.A2Configs.DamagePerTick, DamageTypes.Decont);
                        if (!player.IsAlive)
                        {
                            scp079.Experience += Plugin.Instance.Config.A2Configs.Exp;
                        }
                    }
                }

                yield return Timing.WaitForSeconds(0.5f);
            }

            foreach (var item in room.Doors)
            {
                item.Base.NetworkActiveLocks = 0;
            }
        }
    }
}