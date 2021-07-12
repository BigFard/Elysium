using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Elysium.Items.Weapons.Summoner
{
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
            if (player.ownedProjectileCounts[ModContent.ProjectileType<TaintedHaloMinion>()] > 0)
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
            item.shoot = ModContent.ProjectileType<TaintedHaloMinion>();
        }
    }
}
 
//Weapon, minion, and buff icon sprites from one of my previous projects being used as placeholders for now. -Kryptic Kralo