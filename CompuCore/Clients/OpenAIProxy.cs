///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using Standard.AI.OpenAI.Clients.OpenAIs;
using Standard.AI.OpenAI.Models.Configurations;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;

namespace CompuCore.Clients
{
    public class OpenAIProxy : IOpenAIProxy
    {
        private readonly OpenAIClient _client;

        private readonly List<ChatCompletionMessage> _messages;

        public OpenAIProxy(string apiKey, string organizationId)
        {
            var config = new OpenAIConfigurations
            {
                ApiKey = apiKey,
                OrganizationId = organizationId
            };

            _client = new OpenAIClient(config);

            _messages = new List<ChatCompletionMessage>();
        }

        private void StackMessages(params ChatCompletionMessage[] messages)
        {
            _messages.AddRange(messages);
        }

        private static ChatCompletionMessage[] ToCompletionMessage(ChatCompletionChoice[] choices)
        {
            return choices.Select(x => x.Message).ToArray();
        }

        public Task<ChatCompletionMessage[]> Send(string message)
        {
            var chatMessage = new ChatCompletionMessage()
            {
                Content = message,
                Role = "user"
            };

            return SendMessage(chatMessage);
        }

        private async Task<ChatCompletionMessage[]> SendMessage(ChatCompletionMessage message)
        {
            StackMessages(message);

            var chatCompletion = new ChatCompletion
            {
                Request = new ChatCompletionRequest
                {
                    Model = "gpt-3.5-turbo",
                    Messages = _messages.ToArray(),
                    Temperature = 0.2,
                    MaxTokens = 800
                }
            };

            var result = await _client.ChatCompletions.SendChatCompletionAsync(chatCompletion);

            var choices = result.Response.Choices;

            var responseMessages = ToCompletionMessage(choices);

            StackMessages(responseMessages);

            return responseMessages;
        }
    }
}
