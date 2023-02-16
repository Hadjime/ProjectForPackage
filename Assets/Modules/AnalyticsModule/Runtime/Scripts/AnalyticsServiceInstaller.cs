using UnityEngine;
using Zenject;

namespace GRV.AnalyticsModule
{
    [CreateAssetMenu(fileName = "AnalyticsServiceInstaller", menuName = "Installers/AnalyticsServiceInstaller")]
    public class AnalyticsServiceInstaller : ScriptableObjectInstaller<AnalyticsServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CustomAnalyticsService>().AsSingle();
        }
    }
}