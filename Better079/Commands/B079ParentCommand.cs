// -----------------------------------------------------------------------
// <copyright file="B079ParentCommand.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Commands
{
#pragma warning disable SA1101
    using System;
    using System.Text;
    using Better079.Commands.SubCommands;
    using CommandSystem;
    using NorthwoodLib.Pools;

    /// <summary>
    /// The command which all Better079 commands are run off of.
    /// </summary>
    [CommandHandler(typeof(ClientCommandHandler))]
    public class B079ParentCommand : ParentCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="B079ParentCommand"/> class.
        /// </summary>
        public B079ParentCommand() => LoadGeneratedCommands();

        /// <inheritdoc/>
        public override string Command { get; } = "079";

        /// <inheritdoc/>
        public override string[] Aliases { get; } = Plugin.Instance.Config.MainTranslations.Aliases;

        /// <inheritdoc/>
        public override string Description { get; } = "Ability commands for SCP-079 to use.";

        /// <inheritdoc/>
        public sealed override void LoadGeneratedCommands()
        {
            RegisterCommand(new A1());
            RegisterCommand(new A2());
            RegisterCommand(new A3());
            RegisterCommand(new A4());
        }

        /// <inheritdoc/>
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var config = Plugin.Instance.Config;
            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent();
            stringBuilder.AppendLine(config.MainTranslations.HelpTitle);
            stringBuilder.Append("\"").Append(Command).Append(" a1\" - ").Append(config.A1Configs.Translations.Help)
                .Append(" - ").Append(config.A1Configs.RequiredEnergy).Append(" AP - Tier ")
                .AppendLine(config.A1Configs.RequiredLevel.ToString());

            stringBuilder.Append("\"").Append(Command).Append(" a2\" - ").Append(config.A2Configs.Translations.Help)
                .Append(" - ").Append(config.A2Configs.RequiredEnergy).Append(" AP - Tier ")
                .AppendLine(config.A2Configs.RequiredLevel.ToString());

            stringBuilder.Append("\"").Append(Command).Append(" a3\" - ").Append(config.A3Configs.Translations.Help)
                .Append(" - ").Append(config.A3Configs.RequiredEnergy).Append(" AP - Tier ")
                .AppendLine(config.A3Configs.RequiredLevel.ToString());

            stringBuilder.Append("\"").Append(Command).Append(" a4\" - ").Append(config.A4Configs.Translations.Help)
                .Append(" - ").Append(config.A4Configs.RequiredEnergy).Append(" AP - Tier ")
                .AppendLine(config.A4Configs.RequiredLevel.ToString());

            response = StringBuilderPool.Shared.ToStringReturn(stringBuilder);
            return false;
        }
    }
}