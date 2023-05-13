///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------


namespace Computron.Cartridges
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
