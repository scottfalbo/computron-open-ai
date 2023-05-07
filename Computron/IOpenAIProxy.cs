///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;

namespace Computron
{
    public interface IOpenAIProxy
    {
        Task<ChatCompletionMessage[]> Send(string message);
    }
}
