using GRV.ToolsModule;
using UnityEngine;
#if UNITY_ANDROID || UNITY_IOS
    using Firebase;
    using Firebase.Analytics;
#endif

namespace GRV.AnalyticsModule
{
    public class FirebaseProvider : IAnalyticsProvider
    {
        public void Initialize(bool isLoggingInitializingProviders)
        {
            #if  UNITY_ANDROID || UNITY_IOS
                        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
                        {
                            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                            
                            if (!isLoggingInitializingProviders)
                                return;
            
                            CustomDebug.Log($"[AnalyticsService] FirebaseProvider initialize", Color.yellow);
                        });

            #endif
        }

        public void SendEvent(string eventKey)
        {
            #if UNITY_ANDROID || UNITY_IOS
                FirebaseAnalytics.LogEvent(eventKey);
            #endif
        }
    }
}