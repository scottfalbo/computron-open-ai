///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using Microsoft.Extensions.Configuration;

namespace Computron
{
    public class Program
    {
        private static IComputron _computron;

        static async Task Main(string[] args)
        {
            InitializeComputron();

            Console.WriteLine("Computron");

            await RunComputron();
        }

        private static async Task RunComputron()
        {
            Console.WriteLine("What would you like from Computron?");
            var input = Console.ReadLine();

            do
            {
                try
                {
                    var results = await _computron.Send(input);

                    foreach (var item in results)
                    {
                        Console.WriteLine($"{item.Role}: {item.Content}");
                    }

                    Console.WriteLine("What else can Computron answer?");
                    input = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Computron has experienced an error");
                    Console.WriteLine(ex.ToString());
                    input = "goodbye";
                }

            }
            while (input != "goodbye");
        }

        private static void InitializeComputron()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets(System.Reflection.Assembly.GetExecutingAssembly());

            // Build the configuration
            var configuration = builder.Build();
            var apiKep = configuration["ApiKey"];
            var organizationId = configuration["OrganizationId"];

            _computron = new Computron(apiKep, organizationId);
        }
    }
}