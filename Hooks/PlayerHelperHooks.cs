using HarmonyLib;
using OrangeApi;

namespace RiCO.Hooks;

[HarmonyPatch]
static class PlayerHelperHooks
{
    // Disable AC
    [HarmonyPrefix, HarmonyPatch(typeof(PlayerHelper), nameof(PlayerHelper.SetUseCheatPlugin))]
    static bool SetUseCheatPlugin(PlayerHelper __instance, LoginToServerRes res)
    {
        RiCO.Log.LogWarning($"PlayerHelper.SetUseCheatPlugin({res})");
        
        Traverse.Create(__instance).Field("CheatPlayer").SetValue(false);
        
        RiCO.Log.LogWarning("Anti-Cheat disabled!");
        
        return false;
    }
}
