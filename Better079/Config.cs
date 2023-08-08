// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Better079.Abilities;
    using Better079.Configs;
    using Exiled.API.Interfaces;

    /// <inheritdoc cref="IConfig"/>
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; }

        /// <summary>
        //

        /// <summary>
        /// Gets or sets the configs of ability one.
        /// </summary>
        public A1 A1 { get; set; } = new A1();

        /// <summary>
        /// Gets or sets the configs of ability two.
        /// </summary>
        public A2 A2 { get; set; } = new A2();

        /// <summary>
        /// Gets or sets the configs of ability three.
        /// </summary>
        public A3 A3 { get; set; } = new A3();

        /// <summary>
        /// Gets or sets the configs of ability four.
        /// </summary>
        public A4 A4 { get; set; } = new A4();
    }
}