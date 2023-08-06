using HarmonyLib;
using OrangeApi;

namespace RiCO.Hooks;

[HarmonyPatch]
static class DisableAC
{
    [HarmonyPrefix, HarmonyPatch(typeof(PlayerHelper), nameof(PlayerHelper.SetUseCheatPlugin))]
    static bool SetUseCheatPlugin(PlayerHelper __instance, LoginToServerRes res)
    {
        if (!RiCO.DisableAC)
            return true;

        RiCO.Log.LogWarning($"PlayerHelper.SetUseCheatPlugin({res})");

        Traverse.Create(__instance).Field("CheatPlayer").SetValue(false);

        RiCO.Log.LogWarning("Anti-Cheat disabled!");

        return false;
    }
}
