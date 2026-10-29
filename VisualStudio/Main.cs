using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace SkilletinRadial
{
	public class Main : MelonMod
	{
        private static bool HasSkillet()
        {
            Inventory inv = GameManager.GetInventoryComponent();
            if (inv == null) return false;
            
            bool hasSkillet = inv.GearInInventory("GEAR_Skillet", 1);
            return hasSkillet;
        }
        internal static Il2CppStringArray RadialItems()
        {
            string[] items = [
        "GEAR_BedRoll",
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
        internal class PlaceItemRadialOrderPatch
        {
            internal static void Postfix(Panel_ActionsRadial __instance)
            {
                if (__instance == null) return;

                __instance.m_PlaceItemRadialOrder = RadialItems();
            }
        }
    }
}
