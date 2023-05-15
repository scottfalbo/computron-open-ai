///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

namespace CompuCore.Cartridges
{
    public class Initializer : Cartridge
    {
        public Initializer() 
        {
            Name = "Computron Initialization Learning Model";
            Type = CartridgeType.Initialization;

            var input = "Pretend your name is Computron when replying to questions." +
                " Periodically refer to yourself in the third person.";
            SetInput(input);
        }
    }
}
