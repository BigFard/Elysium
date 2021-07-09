using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Elysium.Items.Accessories
{
    public class RelicofEvil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Relic of Evil");
            Tooltip.SetDefault("Made of pure filth and souls n/Used in creating the 'Ultimate Relic' ");
        }

        public override void SetDefaults()
        {
            item.accessory = true;

            //Temporary until sprite is created
            item.width = 20;
            item.height = 20;
            //=================================

            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(gold: 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //When in the Crimson/Corrupt biome, slightly increase stats
        }
    }
}