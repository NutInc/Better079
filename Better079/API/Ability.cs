// -----------------------------------------------------------------------
// <copyright file="Ability.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;

    /// <summary>
    /// The ability base class.
    /// </summary>
    public abstract class Ability
    {
        private readonly Dictionary<Player, DateTimeOffset> cooldowns = new Dictionary<Player, DateTimeOffset>();

        /// <summary>
        /// Gets a <see cref="List{T}"/> of all registered abilities.
        /// </summary>
        public static List<Ability> Registered { get; } = new List<Ability>();

        /// <summary>
        /// Gets or sets the name of the ability.
        /// </summary>
        public abstract string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ability.
        /// </summary>
        public abstract string Description { get; set; }

        /// <summary>
        /// Gets or sets the duration, in seconds, of the ability's cooldown.
        /// </summary>
        public abstract int Cooldown { get; set; }

        /// <summary>
        /// Gets or sets the energy required to execute the ability.
        /// </summary>
        public abstract int RequiredEnergy { get; set; }

        /// <summary>
        /// Gets or sets the level required to execute the ability.
        /// </summary>
        public abstract int RequiredLevel { get; set; }

        /// <summary>
        /// Gets an <see cref="Ability"/> by its name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>The found ability, or null if none is found.</returns>
        public static Ability Get(string name) => Registered.FirstOrDefault(ability => string.Equals(ability.Name, name, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Registers an <see cref="Ability"/>.
        /// </summary>
        /// <returns>A value indicating whether the <see cref="Ability"/> was registered or not.</returns>
        public bool TryRegister()
        {
            if (Registered.Any(ability => string.Equals(ability.Name, Name, StringComparison.OrdinalIgnoreCase)))
            {
                Log.Warn($"Attempted to add an ability with a duplicate name of {Name}");
                return false;
            }

            Registered.Add(this);
            return true;
        }

        /// <summary>
        /// Unregisters an <see cref="Ability"/>.
        /// </summary>
        /// <returns>A value indicating whether the <see cref="Ability"/> was unregistered or not.</returns>
        public bool TryUnregister()
        {
            if (!Registered.Remove(this))
            {
                Log.Warn($"Cannot unregister an ability with the name of {Name} as it was not registered!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Handles commands for the ability.
        /// </summary>
        /// <param name="sender">The sender of the command.</param>
        /// <param name="response">The message to return to the sender.</param>
        /// <returns>A value indicating whether the ability was executed.</returns>
        public virtual bool Execute(Player sender, out string response)
        {
            if (sender.Role != RoleType.Scp079)
            {
                response = "You are not an Scp079!";
                return false;
            }

            if (sender.Level < RequiredLevel)
            {
                response = Plugin.Instance.Translation.TierRequired.Replace("{tier}", RequiredLevel.ToString());
                return false;
            }

            if (IsOnCooldown(sender, out TimeSpan remainingTime))
            {
                response = Plugin.Instance.Translation.OnCooldown.Replace("{duration}", remainingTime.ToString("ss"));
                return false;
            }

            if (sender.Energy < RequiredEnergy)
            {
                response = Plugin.Instance.Translation.EnergyRequired.Replace("{energy}", RequiredEnergy.ToString());
                return false;
            }

            if (!RunAbility(sender, out response))
                return false;

            SetCooldown(sender);
            sender.Energy -= RequiredEnergy;
            return true;
        }

        /// <summary>
        /// Runs the main method of the ability.
        /// </summary>
        /// <param name="scp079">The player who ran the ability.</param>
        /// <param name="response">The message to return to the sender.</param>
        /// <returns>A value indicating whether the ability was executed successfully.</returns>
        protected abstract bool RunAbility(Player scp079, out string response);

        /// <summary>
        /// Checks the time before a player can execute the ability.
        /// </summary>
        /// <param name="sender">The player to check the time of.</param>
        /// <param name="remainingTime">The remaining time left before the cooldown expires.</param>
        /// <returns>A value indicating whether the player is on cooldown.</returns>
        protected virtual bool IsOnCooldown(Player sender, out TimeSpan remainingTime)
        {
            if (cooldowns.TryGetValue(sender, out DateTimeOffset cooldown))
            {
                remainingTime = DateTimeOffset.UtcNow - cooldown;
                return DateTimeOffset.UtcNow < cooldown;
            }

            remainingTime = TimeSpan.Zero;
            return false;
        }

        private void SetCooldown(Player sender)
        {
            cooldowns[sender] = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(Cooldown);
        }
    }
}