using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElysiumMod.Items
{
    public class Bo : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Quick boy.");
        }

        public override void SetDefaults()
        {
            item.damage = 4;
            item.melee = true;

            //Needs to be adjusted to the final sprite size
            item.width = 40;
            item.height = 40;
            //=============================================

            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3;
            item.value = Item.sellPrice(copper: 20);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.crit = 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 40);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}