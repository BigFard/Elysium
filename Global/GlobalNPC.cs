using Terraria;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Elysium.Items.Weapons.Melee;

namespace Elysium.Global
{
	class MyGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
            #region Ice Rupture
            if (npc.type == NPCID.IceBat)
			{
				if (Main.rand.NextFloat() < .45f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<IceRupture>(), 1);
				}
			}

            if (npc.type == NPCID.IceSlime)
            {
                if (Main.rand.NextFloat() < .45f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<IceRupture>(), 1);
                }
            }

            if (npc.type == NPCID.SpikedIceSlime)
            {
                if (Main.rand.NextFloat() < .45f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<IceRupture>(), 1);
                }
            }
            #endregion
        }
    }
}