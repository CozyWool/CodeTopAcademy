using System.Globalization;

namespace DIContaintersWebApp.Services;

public class TimerService : ITimerService
{
    public string GetTime()
    {
        return DateTime.Now.ToString("HH:mm:ss:ffff");
    }
}