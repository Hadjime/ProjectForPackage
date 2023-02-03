#if UNITY_WEBGL
using System;
using GameScore;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace InternalAssets.Scripts.Services.Ads.AdsProviders
{
    public class GameScoreProvider : IAdsProvider
    {
        private Action onRewarded;

        public void Initialize()
        {
            GS_SDK.OnReady += OnReady;
            GS_Ads.OnRewardedReward += RewardReceived;
        }

        public void ShowInterstitialVideo()
        {
            GS_Ads.ShowFullscreen();
        }

        public void ShowRewardedVideo(Action onRewardedVideoComplete)
        {
            onRewarded = onRewardedVideoComplete;
            
            GS_Ads.ShowRewarded();
        }

        public Locale GetLocale()
        {
            string current;
            try
            {
                current = GS_Language.Current();
                Debug.Log($"GS_Language.Current() = {GS_Language.Current()}");
            }
            catch (Exception e)
            {
                current = "en";
                Debug.Log($"GS_Language.Current() ERROR so current lamguage = {current}");
            }
           
            Locale locale = current switch
            {
                "en" => LocalizationSettings.AvailableLocales.Locales[0],
                "ru" => LocalizationSettings.AvailableLocales.Locales[1],
                "tr" => LocalizationSettings.AvailableLocales.Locales[2],
                _ => LocalizationSettings.AvailableLocales.Locales[0]
            };
            
            return locale;
        }

        private void OnReady()
        {
            Debug.Log($"[GS] Initialized");
            GS_SDK.OnReady -= OnReady;
        }
        
        private void RewardReceived(string arg0)
        {
            onRewarded?.Invoke();
        }
    }
}
#endif