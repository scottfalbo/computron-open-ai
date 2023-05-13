///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using CompuCore;
using CompuCore.Configuration;
using Microsoft.Extensions.Configuration;

namespace Computron
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets(System.Reflection.Assembly.GetExecutingAssembly());

            var configuration = builder.Build();

            var computron = ConfigureClient.InitializeComputron(
                configuration["ApiKey"], 
                configuration["OrganizationId"]);
            Console.WriteLine("Computron Initialized.\n");

            await computron.Run();
        }
    }
}