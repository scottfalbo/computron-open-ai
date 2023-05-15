///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using CompuCore;
using CompuCore.Configuration;

namespace CompuTests
{
    [TestClass]
    public class ComputronTests
    {
        private readonly IComputron _computron;

        public ComputronTests()
        {
            var openAISettings = new OpenAISettings("test-apikey", "test-org-id");
            _computron = Computron.Run(openAISettings);
        }

        [TestMethod]
        public void Computron_IsNotNull()
        {
            Assert.IsNotNull(_computron);
        }

        [TestMethod]
        public void Initializes_NullCartridge()
        {

        }
    }
}
