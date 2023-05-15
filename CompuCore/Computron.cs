///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using CompuCore.Cartridges;
using CompuCore.Clients;
using CompuCore.Configuration;
using CompuCore.Models;
using System.Diagnostics;

namespace CompuCore
{
    public class Computron : IComputron
    {
        private IOpenAIProxy _client { get; set; }

        private Cartridge? _cartridge { get; set; }

        private bool _isInitialized = false;

        private Computron(OpenAISettings settings)
        {
            _client = new OpenAIProxy(settings.ApiKey, settings.OrganizationId);
            _cartridge = null;
        }

        public static Computron Run(OpenAISettings settings) => new(settings);

        public async Task<List<string>> Send(string input)
        { 
            var responses = new List<string>();

            if (!_isInitialized)
            {
                var notInitialized = "Computron must be Initialized before making requests";
                responses.Add(notInitialized);
            }
            else if (string.IsNullOrWhiteSpace(input))
            {
                var invalidInput = "No reponse ,the input was either null or white space.";
                responses.Add(invalidInput);
            }
            else
            {
                try
                {
                    var results = await _client.Send(input ?? "");

                    foreach (var item in results)
                    {
                        responses.Add(item.Content);
                    }
                }
                catch (Exception ex)
                {
                    var error = $"Computron has experienced an error. \n{ex}";
                    responses.Add(error);
                }
            }

            return responses;
        }

        public void AddCartridge(Cartridge cartridge)=> _cartridge = cartridge;

        public void ReplaceCartridge(Cartridge cartridge) => _cartridge = cartridge;

        public void RemoveCartridge() => _cartridge = null;

        private async Task<bool> TryCartridge()
        {
            var result = false;

            if (_cartridge != null)
            {
                var input = _cartridge.ReadCartridge();
                await _client.Send(input);
                result = true;
            }

            return result;
        }

        public async Task<ComputronValidation> Initialize()
        {
            var response = new ComputronValidation();

            try
            {
                var initializer = new Initializer();

                await _client.Send(initializer.ReadCartridge());

                var loadingMessage = "No Cartridge present.";
                if (_cartridge != null)
                {
                    var isLoaded = await TryCartridge();
                    loadingMessage = isLoaded ? $"Cartridge Name: {_cartridge.Name} has been loaded."
                        : $"But Cartridge Name: {_cartridge.Name} has failed to load.";
                }

                response.IsSuccess = true;
                response.Message = "Computron has been Initialized.";
            }
            catch (Exception ex)
            {
                response.Message = $"Initialization Error :{ex}";
            }

            return response;
        }
    }
}
