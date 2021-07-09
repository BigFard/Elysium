using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElysiumMod.Items.Accessories
{
    public class RelicofBone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Relic of Bone");
            Tooltip.SetDefault("Ancient Artifact of skeletons n/Used to create the 'Ultimate Relic'");
        }

        public override void SetDefaults()
        {
            item.accessory = true;

            //Temporary until a sprite is designed
            item.height = 20;
            item.width = 20;
            //====================================

            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(gold: 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            /*I THINK this is correct, but please alert me if I'm wrong
                                                        -Kryptic Kralo*/
            player.statDefense += 4;
        }
    }
}