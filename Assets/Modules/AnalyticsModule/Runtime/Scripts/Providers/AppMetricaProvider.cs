using GRV.ToolsModule;
using UnityEngine;

namespace GRV.AnalyticsModule
{
    public class AppMetricaProvider : IAnalyticsProvider
    {
        public void Initialize(bool isLoggingInitializingProviders)
        {
            if (!isLoggingInitializingProviders)
                return;

            AppMetrica.Instance.OnActivation += config =>
            {
                CustomDebug.Log($"[AnalyticsService] AppMetricaProvider initialize", Color.yellow);
            };
        }

        public void SendEvent(string eventKey)
        {
            AppMetrica.Instance.ReportEvent(eventKey);
            AppMetrica.Instance.SendEventsBuffer();
        }
    }
}