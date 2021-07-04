using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;
using Elysium.Items;

namespace Elysium.Items
{
	public class IceRupture : ModItem
	{
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("Forged of pure ice, inflicts enemies with frostburn debuff on critical hits.");
		}

		public override void SetDefaults()
		{
			item.damage = 13;
			item.melee = true;
			item.width = 26;
			item.height = 26;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 60, 1);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 5);
		}
	}
}