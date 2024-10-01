using Terraria.ModLoader;
using SOTS.Void;

using CalamityMod;

namespace SOTSXCalam.Void
{
	public class VoidRogue : DamageClass
	{
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
		{
			if (damageClass == DamageClass.Generic || damageClass == ModContent.GetInstance<VoidGeneric>() || damageClass == ModContent.GetInstance<RogueDamageClass>())
				return StatInheritanceData.Full;
			return new StatInheritanceData(
				damageInheritance: 0f,
				critChanceInheritance: 0f,
				attackSpeedInheritance: 0f,
				armorPenInheritance: 0f,
				knockbackInheritance: 0f
			);
		}
		public override bool GetEffectInheritance(DamageClass damageClass)
		{
            //CalamityMod.RogueDamageClass.Generic
            if (damageClass == ModContent.GetInstance<RogueDamageClass>() || damageClass == ModContent.GetInstance<VoidGeneric>())
				return true;
			return false;
		}
		public override bool UseStandardCritCalcs => true;
	}
}
