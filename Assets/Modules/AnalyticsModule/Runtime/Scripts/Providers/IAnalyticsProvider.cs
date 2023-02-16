namespace GRV.AnalyticsModule
{
    public interface IAnalyticsProvider
    {
        public void Initialize(bool isLoggingInitializingProviders);
        public void SendEvent(string eventKey);
    }
}