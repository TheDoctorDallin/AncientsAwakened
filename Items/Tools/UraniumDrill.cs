using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AAMod.Items.Tools
{
    //ported from my tAPI mod because I don't want to make more artwork
    public class UraniumDrill : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Uranium Drill");
		}

		public override void SetDefaults()
		{
            item.useStyle = 1;
            item.useAnimation = 29;
            item.useTime = 12;
            item.knockBack = 5f;
            item.useTurn = true;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.width = 36;
            item.height = 36;
            item.damage = 25;
            item.pick = 150;
            item.UseSound = SoundID.Item1;
            item.rare = 4;
            item.value = 81000;
            item.melee = true;
            item.shoot = mod.ProjectileType("UraniumDrill");
            item.shootSpeed = 40f;
        }

        public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod, "UraniumBar", 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}