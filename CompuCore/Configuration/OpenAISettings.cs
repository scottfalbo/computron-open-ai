///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

namespace CompuCore.Configuration
{
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
