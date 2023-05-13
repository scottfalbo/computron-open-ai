///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

namespace CompuCore.Configuration
{
    public class ConfigureClient
    {
        public static ComputronAdapter InitializeComputron(OpenAISettings openAISettings)
        {
            var computronAdapter = new ComputronAdapter(openAISettings);

            return computronAdapter;
        }

        public static ComputronAdapter InitializeComputron(string apiKey, string orgId)
        {
            var openAISettings = new OpenAISettings(apiKey, orgId);

            var computronAdapter = new ComputronAdapter(openAISettings);

            return computronAdapter;
        }
    }
}
