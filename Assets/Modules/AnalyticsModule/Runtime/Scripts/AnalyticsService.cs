using System.Collections.Generic;
using GRV.ToolsModule;
using UnityEngine;
using Zenject;

namespace GRV.AnalyticsModule
{
    /// <summary>
    /// Сервис для отправки аналитики через различные SDK.
    /// </summary>
    public class AnalyticsService: IAnalyticsService, IInitializable
    {
        //TODO: вынести поставщиков аналитики в отдельный ScriptableInstaller с настройкой через инспектор и сюда в конструктор прокинуть
        private List<IAnalyticsProvider> providers = new List<IAnalyticsProvider>()
        {
            new AppMetricaProvider(),
            new GameAnalyticsProvider(),
            new FirebaseProvider(),
            // Пока не отправляю события через Unity аналитику из-за ошибки непонятной связаной со сбором статистики в Китае
            //new UnityAnalyticsProvider(),
        };

        public bool IsLoggingInitializingProviders { get; set; }
        public bool IsLoggingSendEvents { get; set; }


        public void Initialize()
        {
            providers.ForEach(provider => provider.Initialize(IsLoggingInitializingProviders));
        }

        public void SendEvent(string eventName)
        {
            providers.ForEach(provider => provider.SendEvent(eventName));
            PrintLog(eventName);
        }

        private void PrintLog(string eventKey)
        {
            if (!IsLoggingSendEvents)
                return;
            
            CustomDebug.Log($"[AnalyticsService] Send Event : \"{eventKey}\"", Color.yellow);
        }

        
    }
}