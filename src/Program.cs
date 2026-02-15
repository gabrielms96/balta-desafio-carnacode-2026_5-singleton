using DesignPatternChallengeSingleton.Services;
using DesignPatternChallengeSingleton.Singleton;

namespace DesignPatternChallengeSingleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Configurações ===\n");

            Console.WriteLine("Inicializando serviços...\n");

            var dbService = new DatabaseService();
            var apiService = new ApiService();
            var cacheService = new CacheService();
            var logService = new LoggingService();

            Console.WriteLine("\nUsando os serviços...\n");

            dbService.Connect();
            apiService.MakeRequest();
            cacheService.Connect();
            logService.Log("Sistema iniciado");

            // Problema 2: Configurações podem ficar inconsistentes
            Console.WriteLine("\n--- Tentativa de atualização ---\n");

            var config1 = SingletonConfigurationManager.Instance;
            config1.LoadConfigurations();
            config1.UpdateSetting("LogLevel", "Debug");

            var config2 = SingletonConfigurationManager.Instance;
            config2.LoadConfigurations();
            Console.WriteLine($"Config1 LogLevel: {config1.GetSetting("LogLevel")}");
            Console.WriteLine($"Config2 LogLevel: {config2.GetSetting("LogLevel")}");

            if (config1.GetSetting("LogLevel") == config2.GetSetting("LogLevel"))
            {
                Console.WriteLine("Consistência: Ambas as instâncias refletem a mesma configuração!");
            }
            else
            {
                Console.WriteLine("Inconsistência: Instâncias diferentes têm valores diferentes!");
                // Problema 3: Desperdício de memória e processamento
                Console.WriteLine("\n--- Impacto de Performance ---");
                Console.WriteLine("Cada serviço carregou as configurações separadamente");
                Console.WriteLine("Isso multiplica o uso de memória e tempo de inicialização");
            }

        }
    }
}