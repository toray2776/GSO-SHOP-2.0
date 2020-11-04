using Bedienungshilfe.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedienungshilfe
{
    //public class ProductMenu : Menu
    //{
    //    //public ProductMenu(string title, User user)
    //    //{
    //    //    MenuTitle = title;
    //    //    this.user = user;
    //    //    value = null;
    //    //}

    //    public new void ShowMenu()
    //    {
    //        ConsoleKey _ck;
    //        int _left;
    //        int _pages;
    //        int _count;
    //        int _columncount;
    //        int _leftvalue;
    //        int _lineCount;
    //        if (!CheckItemColumnWidth())
    //        {
    //            throw new Exception("The printable characters per Column is below the minum.");
    //        }
    //        if (Prefix != "")
    //        {
    //            isPrefix = true;
    //            prefixlenght = Prefix.Length + (WhiteSpaceBeforePrefix ? 1 : 0);
    //        }
    //        do
    //        {
    //            Console.BackgroundColor = BackGroundColor;
    //            Console.ForegroundColor = TextColor;
    //            Console.Clear();

    //            //Print Menu
    //            Console.SetCursorPosition(1, 1);
    //            Console.Write(MenuText);
    //            _count = 0;
    //            for (int i = ((page - 1) * pageRows); i < (page * pageRows); i++)
    //            {
    //                _leftvalue = paddingLeftRight;
    //                _columncount = 0;
    //                _lineCount = 0;
    //                if (i < MenuItems.Length)
    //                {
    //                    Console.SetCursorPosition(_leftvalue, 10 + _count);
    //                    if (isPrefix)
    //                    {
    //                        if (i == index)
    //                        {
    //                            if (mark == MenuMark.Prefix || mark == MenuMark.All)
    //                            {
    //                                Console.BackgroundColor = markBackGroundColor;
    //                                Console.ForegroundColor = markTextColor;
    //                            }
    //                        }
    //                        Console.Write(Prefix);
    //                        Console.BackgroundColor = BackGroundColor;
    //                        Console.ForegroundColor = TextColor;
    //                        Console.Write(WhiteSpaceBeforePrefix ? " " : "");
    //                        _leftvalue += prefixlenght;
    //                    }
    //                    if (i == index)
    //                    {
    //                        if (mark == MenuMark.Text || mark == MenuMark.All)
    //                        {
    //                            Console.BackgroundColor = markBackGroundColor;
    //                            Console.ForegroundColor = markTextColor;
    //                        }
    //                    }
    //                    for (int j = 1; j < MenuItems[i].Length; j++)
    //                    {
    //                        if (_columncount >= ItemColumns)
    //                        {
    //                            _columncount = 0;
    //                            _lineCount++;
    //                        }
    //                        if (j == 1 && mark == MenuMark.firstColumn)
    //                        {
    //                            Console.BackgroundColor = BackGroundColor;
    //                            Console.ForegroundColor = TextColor;
    //                        }
    //                        Console.SetCursorPosition(_leftvalue + (_columncount * lastColumnwidth), 4 + _count + _lineCount);
    //                        Console.Write(CheckItemWidth((string)MenuItems[i][j]));
    //                        if (j == 1 && mark == MenuMark.firstColumn)
    //                        {
    //                            Console.BackgroundColor = BackGroundColor;
    //                            Console.ForegroundColor = TextColor;
    //                        }

    //                        _columncount++;
    //                    }
    //                    Console.BackgroundColor = BackGroundColor;
    //                    Console.ForegroundColor = TextColor;
    //                }
    //                else
    //                {
    //                    break;
    //                }
    //                _count += (Console.WindowHeight - (titlebar.height + 3)) / pageRows;
    //            }

    //            //titlebar
    //            if (titlebar.state == States.Default)
    //            {
    //                titlebar.data = new string[3] { MenuTitle, $"Page {page}/{Pages}", $"{user.firstName} {user.lastName}" };
    //            }
    //            titlebar.Show();

    //            //Direction define
    //            _ck = Console.ReadKey(false).Key;
    //            if (_ck == ConsoleKey.DownArrow)
    //            {
    //                index++;
    //                if (index == MenuItems.Length)
    //                {
    //                    index = 0;
    //                }
    //            }
    //            if (_ck == ConsoleKey.UpArrow)
    //            {
    //                index--;
    //                if (index == -1)
    //                {
    //                    index = MenuItems.Length - 1;
    //                }
    //            }

    //            //Page check
    //            _pages = Math.DivRem(index, pageRows, out _left);
    //            page = _left == 0 ? _pages + 1 : _pages + 1;

    //        } while (_ck != ConsoleKey.Enter);
    //        value = (string)MenuItems[index][0];
    //    }
    //}
}
