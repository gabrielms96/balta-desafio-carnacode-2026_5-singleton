using DesignPatternChallengeSingleton.Singleton;

namespace DesignPatternChallengeSingleton.Services
{
    public class LoggingService
    {
        private readonly SingletonConfigurationManager _config;

        public LoggingService()
        {
            _config = SingletonConfigurationManager.Instance;
        }

        public void Log(string message)
        {
            var logLevel = _config.GetSetting("LogLevel");
            Console.WriteLine($"[LoggingService] [{logLevel}] {message}");
        }
    }
}
