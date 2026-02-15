using DesignPatternChallengeSingleton.Singleton;

namespace DesignPatternChallengeSingleton.Services
{
    public class ApiService
    {
        private readonly SingletonConfigurationManager _config;

        public ApiService()
        {
            _config = SingletonConfigurationManager.Instance;
        }

        public void MakeRequest()
        {
            var apiKey = _config.GetSetting("ApiKey");
            Console.WriteLine($"[ApiService] Fazendo requisição com API Key: {apiKey}");
        }
    }
}
