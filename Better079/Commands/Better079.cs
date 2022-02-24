// -----------------------------------------------------------------------
// <copyright file="Better079.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Commands
{
    using System;
    using System.Text;
    using CommandSystem;
    using Exiled.API.Features;
    using NorthwoodLib.Pools;

    /// <summary>
    /// The command to run all abilities.
    /// </summary>
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Better079 : ICommand
    {
        /// <inheritdoc />
        public string Command => "079";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "b079" };

        /// <inheritdoc />
        public string Description => "The command to run all abilities.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count == 0)
            {
                response = $"Please specify an ability. Available:\n{GetHelpMessage()}";
                return false;
            }

            Player player = Player.Get(sender);
            if (player == null)
            {
                response = "This command must be executed on the game level.";
                return false;
            }

            API.Ability ability = API.Ability.Get(arguments.At(0));
            if (ability == null)
            {
                response = "Ability not found.";
                return false;
            }

            return ability.Execute(player, out response);
        }

        private string GetHelpMessage()
        {
            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent();
            foreach (API.Ability ability in API.Ability.Registered)
            {
                stringBuilder.Append(ability.Name).Append(" - ").AppendLine(ability.Description);
            }

            return StringBuilderPool.Shared.ToStringReturn(stringBuilder).TrimEnd();
        }
    }
}