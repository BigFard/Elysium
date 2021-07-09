using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Elysium.Items.Accessories
{
    public class RelicofSlime : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Relic of Slime");
            Tooltip.SetDefault("The preserved core of a slime n/ Used to create the 'Ultimate Relic'");
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
            //On critical hit on Enemy, apply the "Slowed" debuff to same enemy + 10% Damage.
            //In my opinion, adding 10% damage towards an already slowed target is insane pre-boss.
        }
    }
}