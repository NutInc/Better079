// -----------------------------------------------------------------------
// <copyright file="A2.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Abilities
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Better079.API;
    using Better079.Configs;
    using CustomPlayerEffects;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Interactables.Interobjects.DoorUtils;
    using MEC;

    /// <summary>
    /// Ability two. Gasses and locks down Scp079's current room.
    /// </summary>
    public class A2 : Ability
    {
        /// <inheritdoc />
        public override string Name { get; set; } = nameof(A2);

        /// <inheritdoc />
        public override string Description { get; set; } = "Deploys gas into a room to damage users.";

        /// <inheritdoc />
        public override int Cooldown { get; set; } = 60;

        /// <inheritdoc />
        public override int RequiredEnergy { get; set; } = 150;

        /// <inheritdoc />
        public override int RequiredLevel { get; set; } = 3;

        /// <inheritdoc />
        public override int Experience { get; set; } = 0;

        /// <summary>
        /// Gets or sets the rooms where this ability cannot be used.
        /// </summary>
        [Description("The rooms where this ability cannot be used.")]
        public RoomType[] BlacklistedRooms { get; set; } =
        {
            RoomType.Lcz914,
            RoomType.Hcz106,
            RoomType.EzGateA,
            RoomType.EzGateB,
            RoomType.Surface,
        };

        /// <summary>
        /// Gets or sets the amount of experience granted per gas kill.
        /// </summary>
        [Description("The amount of experience granted per gas kill.")]
        public float Exp { get; set; } = 35;

        /// <summary>
        /// Gets or sets the amount of time before the room is gassed.
        /// </summary>
        [Description("The amount of time before the room is gassed.")]
        public int Timer { get; set; } = 5;

        /// <summary>
        /// Gets or sets the amount of time that a room is gassed.
        /// </summary>
        [Description("The amount of time that a room is gassed.")]
        public int GasTimer { get; set; } = 10;

        /// <summary>
        /// Gets or sets the amount of damage to be dealt every half of a second.
        /// </summary>
        [Description("The amount of damage to be dealt every half seconds.")]
        public float DamagePerTick { get; set; } = 10f;

        /// <summary>
        /// Gets or sets the translations for ability two.
        /// </summary>
        public A2Translations Translations { get; set; } = new A2Translations();

        /// <inheritdoc />
        protected override bool RunAbility(Player scp079, out string response)
        {
            Room currentRoom = scp079.CurrentRoom;
            if (BlacklistedRooms.Contains(currentRoom.Type))
            {
                response = Translations.Fail;
                return false;
            }

            Timing.RunCoroutine(GasRoom(currentRoom, scp079));
            response = Translations.Run;
            return true;
        }

        private IEnumerator<float> GasRoom(Room room, Player scp079)
        {
            foreach (Door door in room.Doors)
            {
                door.IsOpen = true;
                door.Base.ServerChangeLock(DoorLockReason.Lockdown079, true);
            }

            for (int i = Timer; i > 0f; i--)
            {
                foreach (Player player in room.Players)
                {
                    if (!player.IsScp)
                    {
                        player.ShowHint(Translations.Warn.Replace("$seconds", i.ToString()), 1f);
                    }
                }

                yield return Timing.WaitForSeconds(1f);
            }

            foreach (Door door in room.Doors)
            {
                door.IsOpen = false;
            }

            foreach (Player player in room.Players)
            {
                if (player.Team != Team.SCP && player.CurrentRoom != null && player.CurrentRoom.Transform == room.Transform)
                {
                    player.ShowHint(Translations.Active, 5f);
                    player.EnableEffect<Amnesia>();
                    player.EnableEffect<Concussed>();
                }
            }

            List<Player> toEffect = new List<Player>(room.Players);
            for (int i = 0; i < GasTimer; i++)
            {
                foreach (Player player in room.Players)
                {
                    if (!player.IsScp && toEffect.Contains(player))
                    {
                        player.Hurt(DamagePerTick, DamageTypes.Decont, scp079.ReferenceHub.LoggedNameFromRefHub(), scp079.Id);
                        if (!player.IsAlive)
                        {
                            scp079.Experience += Exp;
                            player.DisableEffect<Amnesia>();
                            player.DisableEffect<Concussed>();
                            toEffect.Remove(player);
                        }
                    }
                }

                yield return Timing.WaitForSeconds(0.5f);
            }

            foreach (Door door in room.Doors)
            {
                door.Base.ServerChangeLock(DoorLockReason.Lockdown079, false);
            }

            foreach (Player player in room.Players)
            {
                player.DisableEffect<Amnesia>();
                player.DisableEffect<Concussed>();
            }
        }
    }
}