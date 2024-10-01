using Microsoft.Xna.Framework;
using SOTS.Buffs;
using SOTS.Items.Celestial;
using SOTS.Items.Earth;
using SOTS.Items.Planetarium;
using SOTS.Items.Permafrost;
using SOTS.Items.Secrets;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using SOTS.Items.Tide;
using SOTS.Items;
using System.Diagnostics;
using SOTS.Items.AbandonedVillage;
using SOTS.Biomes;
using SOTS.Void;
using SOTS;
using CalamityMod;
using SOTSXCalam.Void;

namespace SOTSXCALAM.Void
{
    public abstract class VoidRogueItem : VoidItem
    {
        public virtual void SafeSetDefaults(){}
        public void SetDefaults()
        {
            Item.shoot = ProjectileID.PurificationPowder;
            SafeSetDefaults();
            if (Item.DamageType == ModContent.GetInstance<RogueDamageClass>())
                Item.DamageType = ModContent.GetInstance<VoidRogue>();
            Item.mana = 1;
        }

        public void ModifyTooltips(List<TooltipLine> tooltips)
        {
            VoidPlayer voidPlayer = VoidPlayer.ModPlayer(Main.LocalPlayer); //only the local player will see the tooltip, afterall
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.Text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = Language.GetTextValue("Mods.SOTS.Common.Damage");

                tt.Text = Language.GetTextValue("Mods.SOTS.Common.Void2", damageValue, damageWord);

                //if (Item.CountsAsClass(ModContent.GetInstance<RogueDamageClass>()))
                    tt.Text = Language.GetTextValue("Mods.SOTS.Common.VoidM", damageValue, damageWord);

            }
            string voidCostText = VoidCost(Main.LocalPlayer).ToString();
            TooltipLine tt2 = tooltips.FirstOrDefault(x => x.Name == "UseMana" && x.Mod == "Terraria");
            if (tt2 != null)
            {
                string[] splitText = tt2.Text.Split(' ');
                if (Item.accessory)
                    tooltips.Remove(tt2);
                else
                {
                    tt2.Text = Language.GetTextValue("Mods.SOTS.Common.CV", voidCostText);
                }
            }
            ModifyTooltip(tooltips);
        }
        



       
       
        
        
        
    }
}