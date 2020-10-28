using System;
namespace Bedienungshilfe
{
    public enum AlertButtons
    {
        YesNo,
        Ok,
        Cancel,
        OkCancel
    }

    public class Alert
    {
        public string value { get; private set; }
        public string Text = "";
        public string TitleBar = "Error";
        public int padding = 1;
        public char Outline = '#';
        public bool DrawOutline = true;
        public bool DrawTitleBar = true;
        public AlertButtons Buttons = AlertButtons.Ok;
        public ConsoleColor ForeGround = ConsoleColor.Red;

        private object[][] options;
        private int index = 0;

        public Alert()
        {
            CheckOptions();
            value = null;
        }

        public bool Show()
        {
            ConsoleKey _ck;
            CheckOptions();

            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                if (DrawOutline)
                {
                DrawingOutline();
                }
                WriteText();
                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(getXposition(i, (string)options[i][1]), Console.WindowHeight - (padding + 1 + (DrawOutline ? 1 : 0)));
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    Console.Write((string)options[i][1]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                _ck = Console.ReadKey(false).Key;

                if(_ck == ConsoleKey.RightArrow)
                {
                    index++;
                    if(index == options.Length)
                    {
                        index = 0;
                    }
                }
                if(_ck == ConsoleKey.LeftArrow)
                {
                    index--;
                    if(index == -1)
                    {
                        index = options.Length - 1;
                    }
                }
            } while (_ck != ConsoleKey.Enter);
            value = options[index][0].ToString();
            return (bool)options[index][0];
        }

        private void WriteText()
        {
            int _MaxLineWidth;
            int _left;
            int _top;
            int _charCount;
            int _lineCount;
            string[] _text;
            _text = Text.Split(" ");
            _left = padding + (DrawOutline ? 1 : 0);
            _top = padding + (DrawTitleBar ? 3 : 0);
            _MaxLineWidth = Console.WindowWidth - ((padding * 2) + (DrawOutline ? 2 : 0)) - 2;
            Console.SetCursorPosition(_left, _top);
            _charCount = 0;
            _lineCount = 0;
            for (int i = 0; i < _text.Length; i++)
            {
                if(_charCount + _text[i].Length < _MaxLineWidth)
                {
                    _charCount += _text[i].Length + 1;
                    Console.Write(_text[i] + " ");
                }
                else
                {
                    _lineCount++;
                    _charCount = 0;
                    Console.SetCursorPosition(_left, _top + _lineCount);
                }
            }
        }

        private void CheckOptions()
        {
            switch (Buttons)
            {
                case AlertButtons.Ok:
                    options = new object[1][];
                    options[0] = new object[2];
                    options[0][0] = true;
                    options[0][1] = "Okay";
                    break;

                case AlertButtons.Cancel:
                    options = new object[1][];
                    options[0] = new object[2];
                    options[0][0] = false;
                    options[0][1] = "Cancel";
                    break;

                case AlertButtons.OkCancel:
                    options = new object[2][];
                    options[0] = new object[2];
                    options[0][0] = true;
                    options[0][1] = "Okay";
                    options[1] = new object[2];
                    options[1][0] = false;
                    options[1][1] = "Cancel";
                    break;

                case AlertButtons.YesNo:
                    options = new object[2][];
                    options[0] = new object[2];
                    options[0][0] = true;
                    options[0][1] = "Yes";
                    options[1] = new object[2];
                    options[1][0] = false;
                    options[1][1] = "No";
                    break;

                default:
                    break;
            }
        }

        private void DrawingOutline()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                if(i == 0 || i == Console.WindowHeight - 1 || (DrawTitleBar && i == 2))
                {
                    for (int j = 0; j < Console.WindowWidth; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(Outline);
                    }
                }
                else if(DrawTitleBar && i == 1)
                {
                    int _positionX;
                    int _maxWidth;
                    _maxWidth = Console.WindowWidth - 2;
                    _positionX = (_maxWidth - TitleBar.Length) / 2;
                    Console.SetCursorPosition(_positionX, i);
                    Console.Write(TitleBar);
                    Console.SetCursorPosition(0, i);
                    Console.Write(Outline);
                    Console.SetCursorPosition(Console.WindowWidth - 1, i);
                    Console.Write(Outline);
                }
                else
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(Outline);
                    Console.SetCursorPosition(Console.WindowWidth, i);
                    Console.Write(Outline);
                }
            }
        }

        private int getXposition(int _index, string _value)
        {
            int _fields = options.Length;
            int _border;
            int _fullwidth;
            int _piece;
            int _piecemiddle;
            _border = (DrawOutline ? 2 : 0) + padding * 2;
            _fullwidth = Console.WindowWidth;
            _fullwidth -= _border;
            _piece = _fullwidth / _fields;
            _piecemiddle = (_piece - _value.Length) / 2;
            return _piecemiddle + ( _piece * _index) + _border;
        }
    }
}
