///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using Computron.Cartridges;
using Computron.Cartridges.Personalities;
using Computron.Clients;
using Computron.UserInterface;

namespace Computron
{
    public class Computron
    {
        private IOpenAIProxy _client { get; set; }

        private Cartridge _cartridge { get; set; }

        public Computron(OpenAISettings settings)
        {
            _client = new OpenAIProxy(settings.ApiKey, settings.OrganizationId);
            _cartridge = null;
        }

        public async Task Run()
        {
            Console.WriteLine("Computron is Online.");
            Console.WriteLine("What would you like to ask Computron? Type \"goodbye\" to return to the Main Menu.");
            var input = Console.ReadLine();

            do
            {
                try
                {
                    var results = await _client.Send(input);

                    foreach (var item in results)
                    {
                        Console.WriteLine($"{item.Role}: {item.Content}");
                    }

                    Console.WriteLine("What else can Computron answer?");
                    input = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Computron has experienced an error.");
                    Console.WriteLine(ex.ToString());
                    input = "goodbye";
                }
            } while (input != "goodbye");

        }

        public void AddCartridge(Cartridge cartridge)=> _cartridge = cartridge;

        public void ReplaceCartridge(Cartridge cartridge) => _cartridge = cartridge;

        public void RemoveCartridge() => _cartridge = null;
    }
}
