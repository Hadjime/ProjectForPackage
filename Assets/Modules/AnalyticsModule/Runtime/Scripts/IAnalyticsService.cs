namespace GRV.AnalyticsModule
{
    public interface IAnalyticsService
    {
        bool IsLoggingSendEvents { get; set; }
        void SendEvent(string eventName);
    }
}