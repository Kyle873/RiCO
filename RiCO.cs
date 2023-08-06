/* MANAGERS & HELPERS
 * 
 * CharacterHelper              - Helps manage characters
 * MissionHelper                - Quest, task, mission and event helper
 * OrangeBattleServerManager    - Manages battle and related state
 * OrangeCommunityManager       - Manages friends and community related things
 * OrangeDataManager            - Data manager
 * OrangeGameManager            - Game manager
 * OrangePlayerLocalData        - Settings storage
 * OrangeSceneManager           - Scene manager
 * OrangeTableHelper            - Table helper
 * PlayerHelper                 - Misc helpers for managing the player
 * PlayerNetManager             - Network/Server manager
 * StatusHelper                 - Manages player stats
 * UIManager                    - Manages UI
 * 
 */

using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace RiCO;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class RiCO : BaseUnityPlugin
{
    public static ManualLogSource Log;

    public static ConfigEntry<bool> ServerEnabled;
    public static ConfigEntry<bool> TrafficMonitoring;
    public static ConfigEntry<bool> DisableAC;
    public static ConfigEntry<bool> GachaAnimationBypass;
    public static ConfigEntry<bool> SetEventSliderMax;
    
    public bool HostPatched;

    void Awake()
    {
        Log = Logger;

        ServerEnabled = Config.Bind("Settings", "ServerEnabled", false, "Enable the local private server");
        TrafficMonitoring = Config.Bind("Settings", "TrafficMonitoring", false, "Enable traffic monitoring for requests and responses");
        DisableAC = Config.Bind("Settings", "DisableAC", false, "Disables the anti-cheat");
        GachaAnimationBypass = Config.Bind("Settings", "GachaAnimationBypass", false, "Bypass the capsule gacha animation");
        SetEventSliderMax = Config.Bind("Settings", "SetEventSliderMax", false, "Set the event stage slider to the max value");

        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

        Logger.LogMessage($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        AudioManager.Instance.PlaySystemSE(SystemSE.CRI_SYSTEMSE_SYS_WINDOW_OP03);

        if (ServerEnabled.Value)
            Server.Server.Start();
        else
            HostPatched = true;
    }

    void OnDestroy()
    {
        if (ServerEnabled.Value)
            Server.Server.Stop();

        Harmony.UnpatchAll();

        // Restart the game, essentially, but only if we're running the server, since it'll require a full login flow again
        if (ServerEnabled.Value)
            OrangeSceneManager.Instance.ChangeScene("switch", OrangeSceneManager.LoadingType.DEFAULT, null, true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GameServerService service = Traverse.Create(PlayerNetManager.Instance).Field("WebService").GetValue() as GameServerService;
        }

        if (Input.GetKeyDown(KeyCode.F11))
            OrangeSceneManager.Instance.ChangeScene("switch", OrangeSceneManager.LoadingType.DEFAULT, null, true);

        // Redirect Server
        if (!HostPatched && ServerEnabled.Value && ServerConfig.Instance.ServerSetting != null)
        {
            foreach (GameServerGameInfo info in ServerConfig.Instance.ServerSetting.Game)
                foreach (GameServerZoneInfo zone in info.Zone)
                    zone.Host = "http://localhost:443";

            HostPatched = true;
        }
    }
}
