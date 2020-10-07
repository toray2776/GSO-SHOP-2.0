using System;
namespace Bedienungshilfe
{
    public enum MenuMark
    {
        All,
        Text,
        Prefix,
        firstColumn
    }

    public enum Location
    {
        Top,
        Bottom
    }

    public enum States
    {
        Default,
        Custom
    }

    public enum ShowPosition
    {
        //Muss noch eingebunden werden
        Full,
        Inline,

    }

    public class Menu
    {
        public string MenuText;
        public string Prefix = "";
        public string ItemSeperator = "";
        public string MenuTitle { get; private set; }
        public object[][] MenuItems;
        public string value { get; private set; }
        public int pageRows = 6;
        public int ItemColumns = 4;
        public int paddingLeftRight = 3;
        public int Pages { get; private set; }
        public int MaxHeight = 0;
        public int MaxWidth = 0;
        public bool WhiteSpaceBeforePrefix = true;
        public bool WhiteSpaceAroundSeperator = false;
        public MenuMark mark = MenuMark.Text;
        public Titlebar titlebar = new Titlebar();
        public ConsoleColor BackGroundColor = ConsoleColor.Black;
        public ConsoleColor TextColor = ConsoleColor.White;
        public ConsoleColor markBackGroundColor = ConsoleColor.Blue;
        public ConsoleColor markTextColor = ConsoleColor.White;

        private int lastColumnwidth = 0;
        private int page = 1;
        private int index;
        private int prefixlenght;
        private bool isPrefix = false;

        //TODO: - Seperator
        //      - Mac Fenstergröße ändern
        //      - Doku schreiben
        //      - Max Height Max Width

        public Menu(string _title)
        {
            MenuTitle = _title;
            value = null;
        }

        #region Add one Menu Item
        /// <summary>
        /// Adding one Menu Item
        /// </summary>
        /// <param name="_text">The Text, thats displayed, and the return value</param>
        public void addMenuItem(string _text)
        {
            if (MenuItems == null)
            {
                MenuItems = new string[0][];
            }
            Array.Resize(ref MenuItems, MenuItems.Length + 1);
            MenuItems[MenuItems.Length - 1] = new string[2];
            MenuItems[MenuItems.Length - 1][1] = _text;
            MenuItems[MenuItems.Length - 1][0] = _text;
            UpdatepageNumber();
        }

        /// <summary>
        /// Adding one Menu Item
        /// </summary>
        /// <param name="_text">The Text, thats displayed</param>
        /// <param name="_value">The Returnvalue</param>
        public void addMenuItem(string _text, string _value)
        {
            if (MenuItems == null)
            {
                MenuItems = new string[0][];
            }
            Array.Resize(ref MenuItems, MenuItems.Length + 1);
            MenuItems[MenuItems.Length - 1] = new string[2];
            MenuItems[MenuItems.Length - 1][1] = _text;
            MenuItems[MenuItems.Length - 1][0] = _value;
            UpdatepageNumber();
        }

        /// <summary>
        /// Adding one Menu Item with x Columns
        /// </summary>
        /// <param name="_text">Array of Columns, index 0 is the Value</param>
        public void addMenuItem(string[] _text)
        {
            if (MenuItems == null)
            {
                MenuItems = new string[0][];
            }
            Array.Resize(ref MenuItems, MenuItems.Length + 1);
            MenuItems[MenuItems.Length - 1] = new string[_text.Length + 1];
            MenuItems[MenuItems.Length - 1][0] = _text[0];
            for (int i = 1; i < _text.Length + 1; i++)
            {
                MenuItems[MenuItems.Length - 1][i] = _text[i - 1];
            }
            UpdatepageNumber();
        }

        /// <summary>
        /// Adding one Menu Item with x Columns
        /// </summary>
        /// <param name="_text">Array of Columns</param>
        /// <param name="_value">The Menu Item value</param>
        public void addMenuItem(string[] _text, string _value)
        {
            if (MenuItems == null)
            {
                MenuItems = new string[0][];
            }
            Array.Resize(ref MenuItems, MenuItems.Length + 1);
            MenuItems[MenuItems.Length - 1] = new string[_text.Length + 1];
            MenuItems[MenuItems.Length - 1][0] = _value;
            for (int i = 1; i < _text.Length + 1; i++)
            {
                MenuItems[MenuItems.Length - 1][i] = _text[i - 1];
            }
            UpdatepageNumber();
        }
        #endregion

        /// <summary>
        /// Shows the Menu and waits for User Input.
        /// It will block the Thread until User presses Return.
        /// </summary>
        public void ShowMenu()
        {
            ConsoleKey _ck;
            int _left;
            int _pages;
            int _count;
            int _columncount;
            int _leftvalue;
            int _lineCount;
            if (!CheckItemColumnWidth())
            {
                throw new Exception("The printable characters per Column is below the minum.");
            }
            if (Prefix != "")
            {
                isPrefix = true;
                prefixlenght = Prefix.Length + (WhiteSpaceBeforePrefix ? 1 : 0);
            }
            do
            {
                Console.BackgroundColor = BackGroundColor;
                Console.ForegroundColor = TextColor;
                Console.Clear();

                //Print Menu
                Console.SetCursorPosition(1, 1);
                Console.Write(MenuText);
                _count = 0;
                for (int i = ((page - 1) * pageRows); i < (page * pageRows); i++)
                {
                    _leftvalue = paddingLeftRight;
                    _columncount = 0;
                    _lineCount = 0;
                    if (i < MenuItems.Length)
                    {
                        Console.SetCursorPosition(_leftvalue, 4 + _count);
                        if(isPrefix)
                        {
                            if(i == index) {
                                if (mark == MenuMark.Prefix || mark == MenuMark.All)
                                {
                                    Console.BackgroundColor = markBackGroundColor;
                                    Console.ForegroundColor = markTextColor;
                                }
                            }
                            Console.Write(Prefix);
                            Console.BackgroundColor = BackGroundColor;
                            Console.ForegroundColor = TextColor;
                            Console.Write(WhiteSpaceBeforePrefix ? " " : "");
                            _leftvalue += prefixlenght;
                        }
                        if (i == index)
                        {
                            if(mark == MenuMark.Text || mark == MenuMark.All)
                            {
                                Console.BackgroundColor = markBackGroundColor;
                                Console.ForegroundColor = markTextColor;
                            }
                        }
                        for (int j = 1; j < MenuItems[i].Length; j++)
                        {
                            if (_columncount >= ItemColumns)
                            {
                                _columncount = 0;
                                _lineCount++;
                            }
                            if(j == 1 && mark == MenuMark.firstColumn)
                            {
                                Console.BackgroundColor = BackGroundColor;
                                Console.ForegroundColor = TextColor;
                            }
                            Console.SetCursorPosition(_leftvalue + (_columncount * lastColumnwidth), 4 + _count + _lineCount);
                            Console.Write(CheckItemWidth((string)MenuItems[i][j]));
                            if (j == 1 && mark == MenuMark.firstColumn)
                            {
                                Console.BackgroundColor = BackGroundColor;
                                Console.ForegroundColor = TextColor;
                            }

                            _columncount++;
                        }
                        Console.BackgroundColor = BackGroundColor;
                        Console.ForegroundColor = TextColor;
                    } else
                    {
                        break;
                    }
                    _count += (Console.WindowHeight - (titlebar.height + 3)) / pageRows;
                }

                //titlebar
                if(titlebar.state == States.Default)
                {
                    titlebar.data = new string[3] { MenuTitle, $"Page {page}/{Pages}", $"Vorname Nachname" };
                }
                titlebar.Show();

                //Direction define
                _ck = Console.ReadKey(false).Key;
                if(_ck == ConsoleKey.DownArrow)
                {
                    index++;
                    if(index == MenuItems.Length)
                    {
                        index = 0;
                    }
                }
                if(_ck == ConsoleKey.UpArrow)
                {
                    index--;
                    if(index == -1)
                    {
                        index = MenuItems.Length - 1;
                    }
                }

                //Page check
                _pages = Math.DivRem(index, pageRows, out _left);
                page = _left == 0 ? _pages + 1 : _pages + 1;

            } while (_ck != ConsoleKey.Enter);
            value = (string)MenuItems[index][0];
        }

        private void UpdatepageNumber()
        {
            int _left;
            int _pages = Math.DivRem(MenuItems.Length, pageRows, out _left);
            Pages = _left == 0 ? _pages : _pages + 1;
        }

        private bool CheckItemColumnWidth()
        {
            int _ColumnWidth;
            _ColumnWidth = (Console.WindowWidth - (paddingLeftRight * 2)) / ItemColumns;
            lastColumnwidth = _ColumnWidth;
            if(_ColumnWidth > 7)
            {
                return true;
            }
            return false;
        }

        private string CheckItemWidth(string _item)
        {
            if(_item.Length <= lastColumnwidth)
            {
                return _item;
            }
            return _item.Substring(0, lastColumnwidth - 3) + "...";
        }

        public class Titlebar
        {
            public bool enabled = true;
            public int padding = 2;
            public int height = 0;
            public int Columns { get; private set; }
            public string[] data { get; set; }
            public Location Location = Location.Bottom;
            public States state = States.Default;

            private int lastColumnWidth;

            public Titlebar()
            {
                ChangeColumn(3);
                SetHeight();
            }

            public Titlebar(int _columns)
            {
                ChangeColumn(_columns);
                SetHeight();
            }

            public void ChangeColumn(int _number)
            {
                if ((Console.WindowWidth - padding * 2) / _number < 7)
                {
                    //TODO Handle Error
                    return;
                }
                if (_number < 1)
                {
                    //TODO Handle Error
                    return;
                }
                Columns = _number;
                data = new string[Columns];
                lastColumnWidth = (Console.WindowWidth - padding * 2) / _number;
            }

            public void Show()
            {
                if (!enabled)
                {
                    return;
                }
                int _top;

                if(Location == Location.Bottom)
                {
                    _top = Console.WindowHeight - padding;
                }
                else
                {
                    _top = padding;
                }
                Console.SetCursorPosition(padding, _top);

                for (int i = 0; i < Columns; i++)
                {
                    if(data[i] != null)
                    {
                        Console.SetCursorPosition(padding + (i * lastColumnWidth) + (lastColumnWidth - CheckString(data[i]).Length) / 2, _top);
                        Console.Write(CheckString(data[i]));
                    }
                }
            }

            private string CheckString(string _check)
            {
                if(_check.Length <= lastColumnWidth)
                {
                    return _check;
                }
                return _check.Substring(0, lastColumnWidth - 3) + "...";
            }

            private void SetHeight()
            {
                height = padding * 2 + 1;
            }
        }
    }
}
