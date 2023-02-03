using System;
using GRV.AdsModule.AdsProviders;
using UnityEngine;
using Zenject;

namespace GRV.AdsModule
{
    [CreateAssetMenu(fileName = "AdsServiceInstaller", menuName = "Installers/AdsServiceInstaller")]
    public class AdsServiceInstaller : ScriptableObjectInstaller<AdsServiceInstaller>
    {
        [SerializeField] private Settings settings;
        
        
        public override void InstallBindings()
        {
            Container.BindInstance(settings).IfNotBound();
            Container.BindInterfacesTo<AdsService>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public bool IsTestingMode;
            public MobileAdsProviderType MobileAdsProviderType;

            [TextArea]
            public const string info = "Для WebGL сборки используется GameScore SDK по умолчанию";
        }
    }
}