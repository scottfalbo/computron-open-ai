///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using CompuCore.Cartridges;
using CompuCore.Models;

namespace CompuCore
{
    public interface IComputron
    {
        public Task<List<string>> Send(string input);

        public Task<ComputronValidation> Initialize();

        public void AddCartridge(Cartridge cartridge);

        public void ReplaceCartridge(Cartridge cartridge);

        public void RemoveCartridge();
    }
}
