using CalamityMod.Items.Materials;
using CalamityMod.Projectiles.Rogue;
using Microsoft.Xna.Framework;
using SOTS;
using SOTSXCALAM.Void;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityMod.Items.Weapons.Rogue
{
    public class EnchantedAxe : VoidRogueItem
    {
        public override void SetStaticDefaults()
        {
            this.SetResearchCost(1);
        }
        public override void SafeSetDefaults()
        {
            Item.width = 40;
            Item.height = 36;
            Item.damage = 20;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.knockBack = 1f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.maxStack = 1;
            Item.value = 1000;
            Item.rare = ItemRarityID.Orange;
            Item.value = CalamityGlobalItem.RarityOrangeBuyPrice;
            Item.shoot = ModContent.ProjectileType<EnchantedAxeProj>();
            Item.shootSpeed = 30f;
            Item.DamageType = ModContent.GetInstance<RogueDamageClass>();

        }
        public override int GetVoid(Player player)
        {
            return 20;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.Calamity().StealthStrikeAvailable())
            {
                int p = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI, 0f, 1f);
                if (p.WithinBounds(Main.maxProjectiles))
                    Main.projectile[p].Calamity().stealthStrike = true;
                return false;
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<IronFrancisca>(100).
                AddIngredient(ItemID.FallenStar, 5).
                AddIngredient<PearlShard>(10).
                AddIngredient(ItemID.Bone, 30).
                AddTile(TileID.Anvils).
                Register();

            CreateRecipe().
                AddIngredient<LeadTomahawk>(100).
                AddIngredient(ItemID.FallenStar, 5).
                AddIngredient<PearlShard>(10).
                AddIngredient(ItemID.Bone, 30).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}