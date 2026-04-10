using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace SkilletinRadial
{
	public class Main : MelonMod
	{
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg(System.ConsoleColor.Red, "Adding skillet to radial panel...");
        }
        private static bool HasSkillet()
        {
            var inventoryComponent = GameManager.GetInventoryComponent();
            if (inventoryComponent == null)
            {
                return false;
            }
            bool hasSkillet = inventoryComponent.GearInInventory("GEAR_Skillet", 1);
            return hasSkillet;
        }
        public static Il2CppStringArray RadialItems()
        {
            string[] items = [
                "GEAR_Bedroll",
        "SnowShelter",
        "Fire",
        "GEAR_CookingPot",
        "PassTime",
        "IceFishingHole",
        HasSkillet() ? "GEAR_Skillet" : "GEAR_Snare",
        "GEAR_RecycledCan"
            ];
            return items;
        }
        [HarmonyPatch(typeof(Panel_ActionsRadial), nameof(Panel_ActionsRadial.Update))]
        public class NewRifleAmmunition
        {
            internal static void Postfix(ref Panel_ActionsRadial __instance)
            {
                __instance.m_PlaceItemRadialOrder = RadialItems();
            }
        }
    }
}
