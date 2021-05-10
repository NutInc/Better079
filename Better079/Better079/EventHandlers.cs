// <copyright file="EventHandlers.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Better079
{
    using System;
    using Better079.Commands.SubCommands;
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Contains all EXILED based events.
    /// </summary>
    public static class EventHandlers
    {
        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundStarted()"/>
        internal static void OnRoundStarted()
        {
            A1.Cooldown = DateTimeOffset.UtcNow;
            A2.Cooldown = DateTimeOffset.UtcNow;
            A3.Cooldown = DateTimeOffset.UtcNow;
            A4.Cooldown = DateTimeOffset.UtcNow;
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnSpawning(SpawningEventArgs)"/>
        internal static void OnSpawning(SpawningEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp079)
            {
                ev.Player.ShowHint(Plugin.Instance.Config.MainTranslations.SpawnMsg, 10f);
            }
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Scp079.OnGainingExperience(GainingExperienceEventArgs)"/>
        internal static void OnGainingExperience(GainingExperienceEventArgs ev)
        {
            if (Plugin.Instance.Config.ExperienceGain.TryGetValue(ev.GainType, out float experience))
            {
                ev.Amount += experience;
            }
        }
    }
}