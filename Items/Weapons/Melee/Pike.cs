using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Elysium.Items.Weapons.Melee
{
	public class Pike : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Pike");
			base.Tooltip.SetDefault("A long, sharp spear that penetrates enemies indefinetely.");
		}

		public override void SetDefaults()
		{
			base.item.width = 60;
			base.item.height = 60;
			base.item.damage = 13;
			base.item.melee = true;
			base.item.useTurn = true;
			base.item.noUseGraphic = true;
			base.item.useTime = 28;
			base.item.useAnimation = 28;
			base.item.useStyle = ItemUseStyleID.HoldingOut;
			base.item.knockBack = 5f;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = false;                           
			base.item.value = Item.sellPrice(0, 2);
			base.item.rare = ItemRarityID.Blue;
			base.item.shoot = ModContent.ProjectileType<Projectiles.Melee.PikeProj>();
			base.item.shootSpeed = 4f;
		}
	}
}