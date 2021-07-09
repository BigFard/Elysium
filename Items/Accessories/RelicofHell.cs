using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Elysium.Items.Accessories
{
    public class RelicofHell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Relic of Hell");
            Tooltip.SetDefault("Made of pure lava n/Used in creating the 'Ultimate Relic' ");
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
            //On critical hit on Enemy, apply the "On Fire!" debuff to enemy
        }
    }
}