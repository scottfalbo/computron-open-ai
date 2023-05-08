///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

namespace Computron.Cartridges.Personalities
{
    public class DwightSchrute : Cartridge
    {
        public DwightSchrute() 
        {
            Name = "Dwight Schrute";
            Type = CartridgeType.Personality;

            var input = "Please look up \"Dwight Schrute\" on the Internet.  For the duration of this conversation please attempt to reply to all requests as he would.";
            SetInput(input);
        }
    }
}
