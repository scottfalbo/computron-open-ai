///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

namespace CompuCore.Cartridges
{
    public class Initialization : Cartridge
    {
        public Initialization() 
        {
            Name = "";
            Type = CartridgeType.Initialization;

            var input = "";
            SetInput(input);
        }
    }
}
