using HarmonyLib;

namespace RiCO.Mods;

[HarmonyPatch]
static class SetEventSliderMax
{
    // Fuck you Taicom stop making everything private you assholes
    enum TabType
    {
        SKILLITEM,
        GOLD,
        ARMORITEM,
        EXP,
        SP,
        TIMELIMITED,
        BOSSRUSH,
        MAX
    }
    
    [HarmonyPrefix, HarmonyPatch(typeof(EventStageMain), "EventTabHelper")]
    static bool EventTabHelper(EventStageMain __instance, TabType tabType, int tabIndex = 0)
    {
        if (!RiCO.SetEventSliderMax)
            return true;

        /*
        if (!Traverse.Create(__instance).Method("IsInitComplete", tabType, tabIndex).GetValue<bool>())
            return false;
        
        EventStageMain.BgmInfo bgmInfo = __instance.BGM_Default;

        int num = 0;
        if (tabType == __instance.m_currentSelectedTab && __instance.m_currentSelectedTabIndex == tabIndex)
            return false;

        __instance.bChangePage = true;

        if (__instance.b_ignoreFristSE)
            __instance.b_ignoreFristSE = false;
        else if (tabIndex != __instance.m_currentSelectedTabIndex || __instance.m_currentSelectedTab != tabType)
            AudioManager.Instance.PlaySystemSE(__instance.m_clickTapSE);

        __instance.m_currentSelectedTab = tabType;
        __instance.m_currentSelectedTabIndex = tabIndex;
        __instance.m_currentDifficulty = __instance.GetLocalDifficultySetting();
        __instance.UpdateCurrentStageTableWithDifficulty();
        __instance.setMaxDifficulty();
        __instance.EnableChallengeToggle();
        __instance.EnableChallengePanel(false);
        __instance.m_currentMode = EventStageMain.ModeType.NONE;
        __instance.m_toggleNormal.isOn = true;
        __instance.m_toggleChallenge.isOn = false;
        __instance.m_bgExt.ChangeBackground(__instance.m_currentStageTable.s_BG, 0.3f);
        __instance.m_stageTitle.text = ManagedSingleton<OrangeTextDataManager>.Instance.STAGETEXT_TABLE_DICT.GetL10nValue(__instance.m_currentStageTable.w_NAME);
        */

        return true;
    }
}
