///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;

namespace Computron.Clients
{
    public interface IOpenAIProxy
    {
        Task<ChatCompletionMessage[]> Send(string message);
    }
}
