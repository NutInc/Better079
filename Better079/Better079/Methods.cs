// <copyright file="Methods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Better079
{
    using Exiled.API.Features;

    /// <summary>
    /// Contains methods used primarily for abstraction.
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// Checks to see if the <see cref="Player"/> is at or above the specified energy.
        /// </summary>
        /// <param name="player">The SCP-079 to check.</param>
        /// <param name="required">The minimum energy that the player must be at.</param>
        /// <returns>Whether the player is at or above the specified energy.</returns>
        internal static bool SufficientEnergy(Player player, int required)
        {
            return player.Energy >= required;
        }

        /// <summary>
        /// Checks to see if the <see cref="Player"/> is at or above the specified level.
        /// </summary>
        /// <param name="player">The SCP-079 to check.</param>
        /// <param name="required">The minimum level that the player must be.</param>
        /// <returns>Whether the player is at or above the specified level.</returns>
        internal static bool SufficientLevel(Player player, int required)
        {
            return player.Level + 1 >= required;
        }
    }
}