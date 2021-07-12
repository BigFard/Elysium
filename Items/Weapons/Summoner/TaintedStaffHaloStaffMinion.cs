using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Elysium.Items.Weapons.Summoner
{
    #region Tainted Halo Buff
    public class TaintedHaloBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Tainted Halo");
            Description.SetDefault("The Tainted Halo serves you!");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<TaintedHalo>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
    #endregion

    #region Tainted Halo Staff
    public class TaintedHaloStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a Tainted Halo to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 1;
            item.knockBack = 1;
            item.mana = 10;

            //Temporary until final sprite is designed
            item.width = 32;
            item.height = 32;
            //========================================

            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(silver: 50);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item44;
            item.noMelee = true;
            item.summon = true;
            item.buffType = ModContent.BuffType<TaintedHaloBuff>();
            item.shoot = ModContent.ProjectileType<TaintedHalo>();
        }
    }
    #endregion

    #region Tainted Halo Minion
    public class TaintedHalo : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //Set for placeholder sprite, will change based on official sprite
            Main.projFrames[projectile.type] = 4;
            //================================================================

            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public sealed override void SetDefaults()
        {
            //Will change based on final sprite
            projectile.width = 18;
            projectile.height = 28;
            //=================================

            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1f;
            projectile.penetrate = -1;
        }

        //Minion won't destroy grass, pots, and other destructable terrain
        public override bool? CanCutTiles()
        {
            return false;
        }

        //Take a wild fucking guess
        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];

            #region Active Check
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<TaintedHaloBuff>());
            }

            if (player.HasBuff(ModContent.BuffType<TaintedHaloBuff>()))
            {
                projectile.timeLeft = 2;
            }
            #endregion

            #region General Behavior
            Vector2 idlePosition = player.Center;
            idlePosition.Y -= 30f;

            //Move near and behind the player
            float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
            idlePosition.X += minionPositionOffsetX;

            //Teleport to player if too far away
            Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
            float distanceToIdlePosition = vectorToIdlePosition.Length();
            if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 1000f)
            {
                projectile.position = idlePosition;
                projectile.velocity *= 0.1f;
                projectile.netUpdate = true;
            }

            float overlapVelocity = 0.0f;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile other = Main.projectile[i];
                if (i != projectile.whoAmI && other.active && other.owner == projectile.owner && Math.Abs(projectile.position.X - other.position.X) + Math.Abs(projectile.position.Y - other.position.Y) < projectile.width)
                {
                    if (projectile.position.X < other.position.X) projectile.velocity.Y -= overlapVelocity;
                    else projectile.velocity.X += overlapVelocity;

                    if (projectile.position.Y < other.position.Y) projectile.velocity.Y -= overlapVelocity;
                    else projectile.velocity.Y += overlapVelocity;
                }
            }
            #endregion

            #region Locate Target
            float distanceFromTarget = 300f;
            Vector2 targetCenter = projectile.position;
            bool targetFound = false;

            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, projectile.Center);

                if (between < 1000f)
                {
                    distanceFromTarget = between;
                    targetCenter = npc.Center;
                    targetFound = true;
                }                
            }

            if (!targetFound)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, projectile.Center);
                        bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
                        bool closeThroughWall = between < 100f;
                        if(((closest && inRange) || !targetFound) && (lineOfSight || closeThroughWall))
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            targetFound = true;
                        }

                    }
                }
            }

            projectile.friendly = targetFound;
            #endregion

            #region Movement
            float speed = 8f;
            float inertia = 20f;

            if (targetFound)
            {
                if (distanceFromTarget > 40f)
                {
                    Vector2 direction = targetCenter - projectile.Center;
                    direction.Normalize();
                    direction *= speed;
                    projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
                }
            }
            else
            {
                if (distanceToIdlePosition > 600f)
                {
                    speed = 12f;
                    inertia = 60f;
                }
                else
                {
                    speed = 4f;
                    inertia = 80f;
                }
                if (distanceToIdlePosition > 20f)
                {
                    vectorToIdlePosition.Normalize();
                    vectorToIdlePosition *= speed;
                    projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
                }
                else if (projectile.velocity == Vector2.Zero)
                {
                    projectile.velocity.X = -0.15f;
                    projectile.velocity.Y = -0.05f;
                }
            }
            #endregion

            #region Animation and Visuals
            projectile.rotation = projectile.velocity.X * 0.05f;

            int framespeed = 5;
            projectile.frameCounter++;
            if (projectile.frameCounter >= framespeed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }

            Lighting.AddLight(projectile.Center, Color.Gold.ToVector3() * 0.50f);
            #endregion
        }
    }
    #endregion
}



//Weapon, minion, and buff icon sprites from one of my previous projects being used as placeholders for now. -Kryptic Kralo
//Big shoutout to ExampleMod for putting out such a wonderful project for us new developers to reference. You absolutely rock,