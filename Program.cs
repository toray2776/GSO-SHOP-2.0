using System;
using System.Collections.Generic;
using System.Threading;
using BCrypt.Net;
using Bedienungshilfe.Entity;

namespace Bedienungshilfe
{
    class Program
    {
        static void Main(string[] args)
        {
            LogInArea logInArea = new LogInArea();
            User user;
            Dashboard dashboard;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;

            using (var db = new ShopContext())
            {
                db.Database.EnsureCreated();

                db.SaveChanges();

                //user = new User();
                //user.firstName = "Max";
                //user.lastName = "Mustermann";
                //user.userName = "Mustermann";
                //ShoppingCart shoppingCart = new ShoppingCart();
                //List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();
                //shoppingCarts.Add(shoppingCart);
                //user.shoppingCarts = shoppingCarts;
                //db.Add(shoppingCart);
                //user.password = BCrypt.Net.BCrypt.HashPassword("Mustermann");
                //db.Add(user);
                //db.SaveChanges();
            }

            user = logInArea.Login();

            dashboard = new Dashboard(user);
            dashboard.Show();

            //for testing
            bool loggedin = true;

            do
            {
                Console.Clear();

                loggedin = !loggedin;

                UserInput _username = new UserInput();
                _username.Text = "Username";
                _username.Show();
                //Console.WriteLine(_username.value);
                //Console.ReadKey(true);

                UserInput _password = new UserInput();
                _password.Text = "Password";
                _password.ShowInput = false;
                _password.Show();
                //Console.WriteLine(_password.value);
                //Console.ReadKey(true);

                Loader loginLoader = new Loader(() =>
                {
                    //logging in
                    Thread.Sleep(1000);
                });
                loginLoader.Text = "Wir loggen Sie ein";
                loginLoader.Execute();

                if (!loggedin)
                {
                    /*Alert alert = new Alert();
                    alert.Buttons = AlertButtons.Ok;
                    alert.Text = "Der Benutzername oder das Kennwort ist falsch. Bitte überprüfen Sie Ihre eingaben.";
                    alert.Show();*/
                }
            } while (!loggedin);

            //Menu menu = new Menu("Main Menü");
            //menu.addMenuItem("Shop132");
            //menu.addMenuItem("Sho123p123");
            //menu.addMenuItem("Shop1231132");
            //menu.addMenuItem("Sho312fsp123");
            //menu.addMenuItem("S13123hop132");
            //menu.addMenuItem("Shosdfsdfp123");
            //menu.addMenuItem("Shosdfsdfp132");
            //menu.addMenuItem("Shosdfp123");
            //menu.addMenuItem("Shsdfsdfop132");
            //menu.addMenuItem("Shosdfsdfp123");
            //menu.addMenuItem("Shosdfsdfp132");
            //menu.MenuText = "Das ist der Menü Text";
            //menu.Prefix = "-";
            //menu.WhiteSpaceBeforePrefix = true;
            //menu.mark = MenuMark.Prefix;
            //menu.ShowMenu();
            //Console.WriteLine(menu.value);
            //Console.ReadLine();
        }
    }
}
