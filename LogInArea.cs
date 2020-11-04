using Bedienungshilfe.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Bedienungshilfe
{
    public class LogInArea
    {
        private UserAccess userAccess;

        public LogInArea()
        {
            this.userAccess = new UserAccess();
        }

        public User Login()
        {
            do
            {
                Console.Clear();

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
                    Thread.Sleep(1000);
                });
                loginLoader.Text = "Wir loggen Sie ein";
                loginLoader.Execute();

                try
                {
                    return this.userAccess.LogIn(_username.value, _password.value);
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong.");
                }
            } while (true);
        }
    }
}
