using DesignPatternChallengeSingleton.Singleton;

namespace DesignPatternChallengeSingleton.Services
{
    public class CacheService
    {
        private readonly SingletonConfigurationManager _config;

        public CacheService()
        {
            _config = SingletonConfigurationManager.Instance;
        }

        public void Connect()
        {
            var cacheServer = _config.GetSetting("CacheServer");
            Console.WriteLine($"[CacheService] Conectando ao cache: {cacheServer}");
        }
    }
}
