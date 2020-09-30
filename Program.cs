using System;
using System.Threading;

namespace Bedienungshilfe
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();

            InputUI _username = new InputUI();
            _username.Text = "Username";
            _username.Show();
            Console.WriteLine(_username.value);
            Console.ReadKey(true);

            InputUI _password = new InputUI();
            _password.Text = "Password";
            _password.ShowInput = false;
            _password.Show();
            Console.WriteLine(_password.value);
            Console.ReadKey(true);

            Menu menu = new Menu("Titel");

            menu.ItemColumns = 3;

            menu.mark = MenuMark.Prefix;

            menu.Prefix = "-";

            menu.MenuText = "Wilkommen auf der Startseite! Von hier aus kommst du überall hin.";

            menu.addMenuItem("Shop", "1");
            menu.addMenuItem("Einkaufswagen", "2");
            menu.addMenuItem("Profil", "3");

            menu.ShowMenu();

            Console.Clear();

            Console.WriteLine(menu.value);


            Console.ReadKey();

            Alert alert = new Alert();

            alert.Buttons = AlertButtons.OkCancel;

            alert.Text = "Hallo León, ich bin Leon, das hier ist eine Testnachricht, ich muss diese Nachricht so lang wie möglich bekommen, und weiß nicht mehr was ich schreiben soll.";
            alert.padding = 2;
            alert.Show();

            Console.Clear();

            Console.WriteLine(alert.value);

            Console.ReadKey();

            Loader loader = new Loader(() =>
            {
                Thread.Sleep(5000);
            });

            loader.Execute();

            Console.ReadKey(false);
        }
    }
}
