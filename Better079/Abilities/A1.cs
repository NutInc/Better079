// -----------------------------------------------------------------------
// <copyright file="A1.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079.Abilities
{
    using System.Collections.Generic;
    using Better079.API;
    using Better079.Configs;
    using Exiled.API.Features;
    using UnityEngine;

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
        public override int RequiredEnergy { get; set; } = 20;

        /// <inheritdoc />
        public override int RequiredLevel { get; set; } = 1;

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
            List<Camera079> cameras = GetScpCameras();
            if (cameras.Count == 0)
            {
                response = Translations.Fail;
                return false;
            }

            scp079.Camera = cameras[Random.Range(0, cameras.Count)];
            response = Translations.Run;
            return true;
        }

        private List<Camera079> GetScpCameras()
        {
            List<Camera079> cams = new List<Camera079>();
            foreach (Player player in Player.List)
            {
                if (player.IsScp && !player.SessionVariables.ContainsKey("IsNPC") && player.Role != RoleType.Scp079)
                {
                    foreach (Camera079 cam in Map.Cameras)
                    {
                        if (Vector3.Distance(cam.transform.position, player.Position) <= MaximumDistance)
                        {
                            cams.Add(cam);
                        }
                    }
                }
            }

            return cams;
        }
    }
}