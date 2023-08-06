using HarmonyLib;
using System.Text;
using System;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using CallbackDefs;

namespace RiCO.Hooks;

[HarmonyPatch]
static class TrafficMonitor
{
    [HarmonyPrefix, HarmonyPatch(typeof(GameServerService), "WWWRequestError")]
    static bool WWWRequestError(UnityWebRequest www, RequestCommand cmd)
    {
        if (!RiCO.TrafficMonitoring.Value)
            return true;
        
        byte[] data = www.downloadHandler.data;
        Code code = (Code)Convert.ToInt32(JObject.Parse(Encoding.ASCII.GetString(data))["_b"]);

        RiCO.Log.LogWarning($"WWW Request Error: Code {code}");

        return true;
    }

    [HarmonyPrefix, HarmonyPatch(typeof(OrangeServerService<GameServerService>), "WWWNetworkError")]
    static bool WWWNetworkError(RequestCommand cmd)
    {
        if (!RiCO.TrafficMonitoring.Value)
            return true;
        
        RiCO.Log.LogWarning($"WWW Network Error: {cmd.serverRequest.GetType()}");

        return true;
    }

    [HarmonyPrefix, HarmonyPatch(typeof(GameServerService), "ParseServerResponse")]
    static bool ParseServerResponse(RequestCommand cmd, IResponse res)
    {
        if (!RiCO.TrafficMonitoring.Value)
            return true;
        
        RiCO.Log.LogWarning($"Received {cmd.responseType.Name} from Server");
        Utils.LogObject(res);
        return true;
    }

    [HarmonyPrefix, HarmonyPatch(typeof(ServerService<GameServerService>), "BeginCommand")]
    static bool BeginCommand(RequestCommand cmd)
    {
        if (!RiCO.TrafficMonitoring.Value)
            return true;
        
        RiCO.Log.LogWarning($"Client requested {cmd.responseType.Name} from Server");

        return true;
    }
    
    [HarmonyPrefix, HarmonyPatch(typeof(OrangeGameManager), nameof(OrangeGameManager.LoginToGameService))]
    static bool LoginToGameService(object[] __args, string serverUrl, Callback p_cb)
    {
        if (!RiCO.TrafficMonitoring.Value)
            return true;
        
        RiCO.Log.LogWarning($"Server URL: {__args[0]}");

        return true;
    }
}
