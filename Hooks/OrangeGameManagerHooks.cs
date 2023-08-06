using CallbackDefs;
using HarmonyLib;

namespace RiCO.Hooks;

[HarmonyPatch]
static class OrangeGameManagerHooks
{
    [HarmonyPrefix, HarmonyPatch(typeof(OrangeGameManager), nameof(OrangeGameManager.LoginToGameService))]
    static bool LoginToGameService(object[] __args, string serverUrl, Callback p_cb)
    {
        RiCO.Log.LogWarning($"Server URL: {__args[0]}");

        return true;
    }
}
