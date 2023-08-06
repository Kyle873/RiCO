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
using BepInEx.Logging;
using HarmonyLib;
using RiCO.Emu;
using System.Reflection;
using UnityEngine;

namespace RiCO;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class RiCO : BaseUnityPlugin
{
    public static ManualLogSource Log;

    public static bool ServerEnabled = false;
    public bool HostPatched;

    void Awake()
    {
        Log = Logger;

        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

        Logger.LogMessage($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        AudioManager.Instance.PlaySystemSE(SystemSE.CRI_SYSTEMSE_SYS_WINDOW_OP03);

        if (ServerEnabled)
            Server.Start();
        else
            HostPatched = true;
    }

    void OnDestroy()
    {
        if (ServerEnabled)
            Server.Stop();

        Harmony.UnpatchAll();

        // Restart the game, essentially, but only if we're running the server, since it'll require a full login flow again
        if (ServerEnabled)
            OrangeSceneManager.Instance.ChangeScene("switch", OrangeSceneManager.LoadingType.DEFAULT, null, true);
    }

    void Update()
    {
        GameServerService service = Traverse.Create(PlayerNetManager.Instance).Field("WebService").GetValue() as GameServerService;

        if (Input.GetKeyDown(KeyCode.F1))
        {
            // foreach (var item in PlayerNetManager.Instance.dicItem)
            // Utils.LogObject(item.Value.netItemInfo);

            // PlayerNetManager.Instance.dicItem[1].netItemInfo.Stack = 1021420;
        }

        if (Input.GetKeyDown(KeyCode.F11))
            OrangeSceneManager.Instance.ChangeScene("switch", OrangeSceneManager.LoadingType.DEFAULT, null, true);

        // Redirect Server
        if (!HostPatched && ServerEnabled && ServerConfig.Instance.ServerSetting != null)
        {
            foreach (GameServerGameInfo info in ServerConfig.Instance.ServerSetting.Game)
                foreach (GameServerZoneInfo zone in info.Zone)
                    zone.Host = "http://localhost:443";

            HostPatched = true;
        }
    }
}
