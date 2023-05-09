///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using Microsoft.Extensions.Configuration;

namespace Computron
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var computron = InitializeComputron();
            Console.WriteLine("Computron Initialized.\n");
            await computron.Run();
        }

        private static Computron InitializeComputron()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets(System.Reflection.Assembly.GetExecutingAssembly());

            var configuration = builder.Build();
            var openAISettings = new OpenAISettings(configuration["ApiKey"], configuration["OrganizationId"]);
            var computron = new Computron(openAISettings);

            return computron;
        }
    }

    public class OpenAISettings
    {
        public string ApiKey { get; set; }
        public string OrganizationId { get; set; }

        public OpenAISettings(string apiKey, string organizationId)
        {
            ApiKey = apiKey;
            OrganizationId = organizationId;
        }
    }
}