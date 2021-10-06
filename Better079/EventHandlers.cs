// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079
{
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Contains all EXILED based events.
    /// </summary>
    public class EventHandlers
    {
        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnSpawning(SpawningEventArgs)"/>
        public void OnSpawning(SpawningEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp079)
            {
                ev.Player.ShowHint(Plugin.Instance.Translation.SpawnMsg, 10f);
            }
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Scp079.OnGainingExperience(GainingExperienceEventArgs)"/>
        public void OnGainingExperience(GainingExperienceEventArgs ev)
        {
            if (Plugin.Instance.Config.ExperienceGain.TryGetValue(ev.GainType, out float experience))
            {
                ev.Amount += experience;
            }
        }
    }
}