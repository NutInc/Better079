// -----------------------------------------------------------------------
// <copyright file="A1.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

using PlayerRoles;

namespace Better079.Abilities
{
    using System.Collections.Generic;
    using Better079.API;
    using Better079.Configs;
    using Exiled.API.Features;
    using Exiled.API.Features.Roles;
    using UnityEngine;
    using Camera = Exiled.API.Features.Camera;

    /// <summary>
    /// Ability one. Changes Scp079's camera to be near a teammate.
    /// </summary>
    public class A1 : Ability
    {
        /// <inheritdoc />
        public override string Name { get; set; } = nameof(A1);

        /// <inheritdoc />
        public override string Description { get; set; } = "Teleports you to another SCP.";

        /// <inheritdoc />
        public override int Cooldown { get; set; } = 0;

        /// <inheritdoc />
        public override int RequiredEnergy { get; set; } = 10;

        /// <inheritdoc />
        public override int RequiredLevel { get; set; } = 1;

        /// <inheritdoc/>
        public override int Experience { get; set; } = 0;

        /// <summary>
        /// Gets or sets the maximum acceptable distance that a camera and an scp can be.
        /// </summary>
        public float MaximumDistance { get; set; } = 15f;

        /// <summary>
        /// Gets or sets the translations for ability one.
        /// </summary>
        public A1Translations Translations { get; set; } = new A1Translations();

        /// <inheritdoc />
        protected override bool RunAbility(Player scp079, out string response)
        {
            List<Camera> cameras = GetScpCameras();
            if (cameras.Count == 0)
            {
                response = Translations.Fail;
                return false;
            }

            scp079.Role.As<Scp079Role>().Camera = cameras[Random.Range(0, cameras.Count)];
            response = Translations.Run;
            return true;
        }

        private List<Camera> GetScpCameras()
        {
            List<Camera> cams = new List<Camera>();
            foreach (Player player in Player.List)
            {
                if (!player.IsScp || string.IsNullOrEmpty(player.UserId) || player.Role == RoleTypeId.Scp079)
                    continue;

                foreach (Camera cam in Camera.List)
                {
                    if ((cam.Position - player.Position).sqrMagnitude <= MaximumDistance * MaximumDistance)
                    {
                        cams.Add(cam);
                    }
                }
            }

            return cams;
        }
    }
}