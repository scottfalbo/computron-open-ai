///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using CompuCore.Cartridges;
using CompuCore.Clients;
using CompuCore.Configuration;
using System.Diagnostics;

namespace CompuCore
{
    public class Computron : IComputronAdapter
    {
        private IOpenAIProxy _client { get; set; }

        private Cartridge? _cartridge { get; set; }

        private Computron(OpenAISettings settings)
        {
            _client = new OpenAIProxy(settings.ApiKey, settings.OrganizationId);
            _cartridge = null;
        }

        public static Computron Run(OpenAISettings settings) => new Computron(settings);

        public async Task<List<string>> Send(string input)
        {
            var responses = new List<string>();

            try
            {
                var results = await _client.Send(input ?? "");

                foreach (var item in results)
                {
                    responses.Add(item.Content);
                }

                return responses;
            }
            catch (Exception ex)
            {
                throw new Exception("Computron has experienced an error.", ex);
            }
        }

        public void AddCartridge(Cartridge cartridge)=> _cartridge = cartridge;

        public void ReplaceCartridge(Cartridge cartridge) => _cartridge = cartridge;

        public void RemoveCartridge() => _cartridge = null;

        private async Task<bool> TryCartridge()
        {
            if (_cartridge != null)
            {
                var input = _cartridge.ReadCartridge();
                await _client.Send(input);
                return true;
            }

            return false;
        }

        public async Task<bool> Initialize()
        {
            return await TryCartridge();
        }
    }
}
