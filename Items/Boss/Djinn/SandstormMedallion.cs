using Terraria;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
using Terraria.ModLoader;

namespace AAMod.Items.Boss.Djinn
{
    public class SandstormMedallion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandstorm Medallion");
            Tooltip.SetDefault(@"Doubles your stats during a Sandstorm");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 50;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateEquip(Player p)
        {
			if(p.ZoneSandstorm)
			{
				p.meleeDamage *= 2f;
				p.rangedDamage *= 2f;
				p.magicDamage *= 2f;
				p.minionDamage *= 2f;
				p.thrownDamage *= 2f;
				p.meleeCrit *= 2;
				p.rangedCrit *= 2;
				p.magicCrit += 2;
				p.thrownCrit *= 2;
			}
        }
    }
}