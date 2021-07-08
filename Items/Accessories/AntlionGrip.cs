using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Elysium.Items.Accessories
{
    public class AntlionGrip : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gives 7% Extra Range damage and 5% Extra Range Speed");
        }

        public override void SetDefaults()
        {
            item.accessory = true;

            //Temporary until sprite is made
            item.width = 20;
            item.height = 20;
            //==============================

            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(silver: 60);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage = 7;
            /*Don't know how to properly add a new projectile velocity onto the already existing projectile velocity. 
             Saving for later, or for anyone that wants to tackle it for me.*/
        }
    }
}