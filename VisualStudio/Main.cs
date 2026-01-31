using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace SkilletinRadial
{
	public class Main : MelonMod
	{
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg(System.ConsoleColor.Red, "Adding skillet to radial panel...");
        }

        public static Il2CppStringArray RadialItems()
        {
            string[] items = [
                "SnowShelter",
                "Fire",
                "GEAR_CookingPot",
                "GEAR_Skillet",
                "PassTime",
                "IceFishingHole",
                "GEAR_Snare",
                "GEAR_RecycledCan"
            ];
            return items;
        }

        [HarmonyPatch(typeof(Panel_ActionsRadial), nameof(Panel_ActionsRadial.Initialize))]
        public class NewRifleAmmunition
        {
            internal static void Postfix(ref Panel_ActionsRadial __instance)
            {
                __instance.m_PlaceItemRadialOrder = RadialItems();
            }
        }
    }
}
