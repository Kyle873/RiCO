using HarmonyLib;

namespace RiCO.Hooks;

[HarmonyPatch]
static class GachaAnimationBypass
{
    [HarmonyPrefix, HarmonyPatch(typeof(GachaConfirmUI), nameof(GachaConfirmUI.Setup))]
    static bool Setup(GachaConfirmUI __instance, GACHALIST_TABLE p_gachalistTable, ITEM_TABLE p_costItem)
    {
        if (!RiCO.GachaAnimationBypass.Value)
            return true;

        p_gachalistTable.n_PERFORM = 0;

        Traverse.Create(__instance).Field("gachalistTable").SetValue(p_gachalistTable);
        Traverse.Create(__instance).Field("costItem").SetValue(p_costItem);

        return true;
    }
}
