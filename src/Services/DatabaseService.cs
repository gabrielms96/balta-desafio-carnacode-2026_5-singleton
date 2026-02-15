using DesignPatternChallengeSingleton.Singleton;

namespace DesignPatternChallengeSingleton.Services
{
    public class DatabaseService
    {
        private readonly SingletonConfigurationManager _config;

        public DatabaseService()
        {
            _config = SingletonConfigurationManager.Instance;
        }

        public void Connect()
        {
            var connectionString = _config.GetSetting("DatabaseConnection");
            Console.WriteLine($"[DatabaseService] Conectando ao banco: {connectionString}");
        }
    }
}
