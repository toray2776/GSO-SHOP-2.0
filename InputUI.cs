using System;
namespace Bedienungshilfe
{
    public class InputUI
    {
        public string value { get; private set; } = null;
        public string Text { get; set; } = "Input";
        public int padding { get; set; } = 1;
        public bool ShowColon { get; set; } = true;
        public bool ShowInput { get; set; } = true;

        public InputUI()
        {
        }

        public void Show()
        {
            int _cursorx;
            int _cursory;
            _cursorx = Console.CursorLeft;
            _cursory = Console.CursorTop;

            Console.SetCursorPosition(padding, _cursory + padding);

            Console.Write(Text);
            if (ShowColon)
            {
                Console.Write(":");
            }
            Console.Write(" ");
            if (ShowInput)
            {
                value = Console.ReadLine();
            }
            else
            {
                while (true)
                {
                    var _key = Console.ReadKey(true);
                    if (_key.Key == ConsoleKey.Enter)
                        break;
                    value += _key.KeyChar;
                }
            }
        }
    }
}
