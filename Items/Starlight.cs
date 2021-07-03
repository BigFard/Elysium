using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;
using Elysium.Items;

namespace Elysium.Items
{
	public class Starlight : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
			Tooltip.SetDefault("Brother of the Starfury. Shoots homing star missiles at enemies.");
		}

		public override void SetDefaults() 
		{
			item.damage = 10;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.sellPrice(0, 60);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = ProjectileID.SporeGas3;
			item.shootSpeed = 5f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenSword, 1);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}