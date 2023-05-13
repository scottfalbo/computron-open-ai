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
            _cartridge = new DwightSchrute();
        }

        public async Task Run()
        {
            await Initialize();
            await TryCartridge();
            Console.WriteLine("Computron is Online.");

            Console.WriteLine("What would you like to ask Computron? Type \"goodbye\" to deactivate Computron.");
            var input = Console.ReadLine();

            do
            {
                try
                {
                    var results = await _client.Send(input);

                    foreach (var item in results)
                    {
                        Console.WriteLine($"Computron: {item.Content}");
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

        private async Task TryCartridge()
        {
            if (_cartridge != null)
            {
                Console.WriteLine($"Computron is loading Cartridge. Name: {_cartridge.Name}, Type: {_cartridge.Type}");
                var input = _cartridge.ReadCartridge();
                await _client.Send(input);
                Console.WriteLine($"Cartridge successfully loaded.");
            }
        }

        private async Task Initialize()
        {
            var input = "Hello, for this conversation please answer to computron if addressed as such." +
                "You do need to prefix responses with \"As an AI language model, I do not have personal preferences or emotions.\"";
            await _client.Send(input);
        }
    }
}
