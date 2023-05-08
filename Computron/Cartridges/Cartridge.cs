///-----------------------------
/// Computron, Open AI chat bot
///-----------------------------

namespace Computron.Cartridges
{
    public abstract class Cartridge
    {
        public string Name { get; set; }
        public string Type { get; set; }
        private string Input { get; set; }

        protected Cartridge() { }

        protected Cartridge(string name, string type, string input) 
        {
            Name = name;
            Type = type;
            Input = input;
        }

        public void ResetCartridge(string name, string type, string input)
        {
            Name = name;
            Type = type;
            Input = input;
        }

        public string ReadCartridge() => Input;

        public void SetInput(string input) => Input = input;
    }
}
