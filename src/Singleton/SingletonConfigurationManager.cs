using System.Collections.Concurrent;

namespace DesignPatternChallengeSingleton.Singleton
{
    public class SingletonConfigurationManager
    {
        private static readonly Lazy<SingletonConfigurationManager> _instance =
            new(() => new SingletonConfigurationManager());

        private readonly ConcurrentDictionary<string, string> _settings;
        private bool _isLoaded;
        private readonly object _loadLock = new object();

        private SingletonConfigurationManager()
        {
            _settings = new ConcurrentDictionary<string, string>();
            _isLoaded = false;
            Console.WriteLine(" - Nova instância de ConfigurationManager criada! - ");
        }

        public void LoadConfigurations()
        {
            if (_isLoaded)
            {
                Console.WriteLine("Configurações já carregadas.");
                return;
            }

            lock (_loadLock)
            {
                // Double-check locking
                if (_isLoaded)
                    return;

                Console.WriteLine("Carregando configurações...");

                System.Threading.Thread.Sleep(200);

                _settings["DatabaseConnection"] = "Server=localhost;Database=MyApp;";
                _settings["ApiKey"] = "abc123xyz789";
                _settings["CacheServer"] = "redis://localhost:6379";
                _settings["MaxRetries"] = "3";
                _settings["TimeoutSeconds"] = "30";
                _settings["EnableLogging"] = "true";
                _settings["LogLevel"] = "Information";

                _isLoaded = true;
                Console.WriteLine("Configurações carregadas com sucesso!\n");
            }
        }

        public string GetSetting(string key)
        {
            if (!_isLoaded)
                LoadConfigurations();

            return _settings.TryGetValue(key, out var value) ? value : null;
        }

        public void UpdateSetting(string key, string value)
        {
            _settings[key] = value;
            Console.WriteLine($"Configuração atualizada: {key} = {value}");
        }

        public static SingletonConfigurationManager Instance => _instance.Value;
    }
}
