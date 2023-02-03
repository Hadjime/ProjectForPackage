using System;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using Tools;
using UnityEngine;

namespace AdsModule.AdsProviders
{
    public class AppodealProvider : IAdsProvider
    {
        private const string APP_KEY = "c74b848f0a3259104e18d74f4ec049d20b513cbfb05cff5e";
        
        
        private Action _onRewardedVideoComplete;


        public void Initialize(bool isTestingMode = default)
        {
            int adTypes = AppodealAdType.Interstitial | AppodealAdType.RewardedVideo;
            AppodealCallbacks.Sdk.OnInitialized += OnInitializationFinished;
            Appodeal.Initialize(APP_KEY, adTypes);
            
            Appodeal.SetTesting(isTestingMode);
            AppodealCallbacks.RewardedVideo.OnFinished += OnRewardedVideoFinished; 
        }

        public void ShowInterstitialVideo()
        {
            if (!Appodeal.IsLoaded(AppodealAdType.Interstitial))
                return;
            
            Appodeal.Show(AppodealShowStyle.Interstitial);
        }

        public void ShowRewardedVideo(Action onRewardedVideoComplete)
        {
            _onRewardedVideoComplete = onRewardedVideoComplete;
            
            if (!Appodeal.IsLoaded(AppodealAdType.RewardedVideo))
                return;
            
            
            Appodeal.Show(AppodealShowStyle.RewardedVideo);
        }

        public void OnInitializationFinished(object sender, SdkInitializedEventArgs e)
        {
            CustomDebug.Log("[ADS] Appodeal initialization Finished", Color.yellow);
        }
        
        private void OnRewardedVideoFinished(object sender, RewardedVideoFinishedEventArgs e)
        {
            _onRewardedVideoComplete?.Invoke();
        }
    }
}