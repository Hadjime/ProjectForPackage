using GameAnalyticsSDK;
using GRV.ToolsModule;
using UnityEngine;

namespace GRV.AnalyticsModule
{
    public class GameAnalyticsProvider : IAnalyticsProvider
    {
        public void Initialize(bool isLoggingInitializingProviders)
        {
            GameAnalytics.Initialize();
            
            if (!isLoggingInitializingProviders)
                return;
            
            CustomDebug.Log($"[AnalyticsService] GameAnalyticsProvider initialize", Color.yellow);
        }
        
        public void SendEvent(string eventKey)
        {
            GameAnalytics.NewDesignEvent(eventKey);
        }
    }
}