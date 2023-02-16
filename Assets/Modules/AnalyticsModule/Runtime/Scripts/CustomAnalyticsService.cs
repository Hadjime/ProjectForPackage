namespace GRV.AnalyticsModule
{
    /// <summary>
    /// Пример сервиса аналитики с заранее подготовленными событиями. Просто биндить его по типу а не по интерфейсу.
    /// </summary>
    public class CustomAnalyticsService : AnalyticsService
    {
        private const string LOADING_SCENE_START_KEY = "loading_scene_start";
        private const string LOADING_SCENE_STOP_KEY = "loading_scene_stop";
        private const string OPEN_URL_DISCORD_KEY = "open_url_discord_key";
        private const string OPEN_MULTIPLAYER_WARNING_WINDOW_KEY = "open_multiplayer_warning_window";
        private const string EQUIPPED_AIRCRAFT_KEY = "equipped_aircraft_";
        private const string BTN_FIGHT_CLICK_KEY = "btn_fight_click";
        private const string SESSION_COUNT_KEY = "session_count_";
        private const string TUTORIAL_STAGE_COMPLETE_KEY = "tutorial_stage_complete_";
        private const string AMOUNT_ALL_MATCHES = "amount_all_matches_";
        private const string START_WITH_CHEAT_PANEL_KEY = "start_with_cheat_panel";
        
        public void SendStartWithCheatPanel() => SendEvent(START_WITH_CHEAT_PANEL_KEY);
        public void SendLoadingSceneStart() => SendEvent(LOADING_SCENE_START_KEY);
        public void SendLoadingSceneStop() => SendEvent(LOADING_SCENE_STOP_KEY);
        public void SendOpenUrlDiscord() => SendEvent(OPEN_URL_DISCORD_KEY);
        public void SendOpenMultiplayerWarningWindow() => SendEvent(OPEN_MULTIPLAYER_WARNING_WINDOW_KEY);
        public void SendEquippedAircraft(string aircraftName) => SendEvent(EQUIPPED_AIRCRAFT_KEY + aircraftName);
        public void SendBtnFightClick() => SendEvent(BTN_FIGHT_CLICK_KEY);
        public void SendSessionCount(int matchHistorySessionsCount) => SendEvent(SESSION_COUNT_KEY + matchHistorySessionsCount);
        public void SendTutorialStageComplete(int numberStage) => SendEvent(TUTORIAL_STAGE_COMPLETE_KEY + numberStage);
        public void SendAmountAllMatch(int amountMatches) => SendEvent(AMOUNT_ALL_MATCHES + amountMatches);
        
    }
}