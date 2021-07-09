using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElysiumMod.Items.Accessories
{
    public class RelicofIce : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Relic of Ice");
            Tooltip.SetDefault("Unmeltable substance n/Used to create the 'Ultimate Relic'");
        }

        public override void SetDefaults()
        {
            item.accessory = true;

            //Temporary until sprite is made
            item.width = 20;
            item.height = 20;
            //==============================

            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(gold: 1);
            
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
           //On critical hit with any weapon, inflic Frostburn on opponent
        }
    }
}