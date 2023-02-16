using System;
using System.Collections.Generic;
using GRV.ToolsModule;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

namespace GRV.AnalyticsModule
{
    public class UnityAnalyticsProvider : IAnalyticsProvider
    {
        string consentIdentifier;
        bool isOptInConsentRequired;
        
        
        public async void Initialize(bool isLoggingInitializingProviders)
        {
            try
            {
                await UnityServices.InitializeAsync();
                
                List<string> consentIdentifiers = await Events.CheckForRequiredConsents();
                if (consentIdentifiers.Count > 0)
                {
                    consentIdentifier = consentIdentifiers[0];
                    isOptInConsentRequired = consentIdentifier == "pipl";
                }
                if (isOptInConsentRequired)
                {
                    Events.ProvideOptInConsent(consentIdentifier, false);
                }
                
                if (!isLoggingInitializingProviders)
                    return;
                
                CustomDebug.Log($"[AnalyticsService] UnityAnalyticsProvider initialize", Color.yellow);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void SendEvent(string eventKey)
        {
            Unity.Services.Analytics.AnalyticsService.Instance.CustomData(eventKey, null);
            Unity.Services.Analytics.AnalyticsService.Instance.Flush();
        }
    }
}