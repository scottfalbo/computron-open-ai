///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

using CompuCore.Cartridges;

namespace CompuCore
{
    internal interface IComputronAdapter
    {
        public Task<List<string>> Send(string input);

        public Task<bool> Initialize();

        public void AddCartridge(Cartridge cartridge);

        public void ReplaceCartridge(Cartridge cartridge);

        public void RemoveCartridge();
    }
}
