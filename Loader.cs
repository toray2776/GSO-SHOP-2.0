using System;
using System.Threading;
namespace Bedienungshilfe
{
    public class Loader
    {
        public Action action;
        public bool ShowLoadingScreen = true;
        public string Text = "Loading";

        public Loader(Action _action)
        {
            action = _action;
        }

        public void Execute()
        {
            Thread ExecuteThread = new Thread(executeAction);
            ExecuteThread.Start();
            if (ShowLoadingScreen)
            {
                loadingScreen(ExecuteThread);
            }
        }

        private void executeAction()
        {
            action();
        }

        private void loadingScreen(Thread _thread)
        {
            Console.Clear();
            ConsoleSpinner spinner = new ConsoleSpinner();
            spinner.Delay = 300;
            do
            {
                spinner.Turn(Text, 4);
            } while (_thread.IsAlive);
        }
    }

    public class ConsoleSpinner {

        static string[,] sequence = null;

        public int Delay { get; set; } = 200;

        int totalSequences = 0;
        int counter;

        public ConsoleSpinner()
        {
            counter = 0;
            sequence = new string[,] {
                { "/", "-", "\\", "|" },
                { ".", "o", "0", "o" },
                { "+", "x","+","x" },
                { "V", "<", "^", ">" },
                { ".   ", "..  ", "... ", "...." },
                { "=>   ", "==>  ", "===> ", "====>" },
                { " .oO", ".oO ", "oO .", "O .o"},
                { "OoO", "oOo", "OoO", "oOo"}
            };

            totalSequences = sequence.GetLength(0);
        }

        /// <summary>
        /// Executes one Step
        /// </summary>
        /// <param name="displayMsg">The Message thats Displayed</param>
        /// <param name="sequenceCode"> 0 | 1 | 2 | 3 | 4 | 5 </param>
        public void Turn(string displayMsg = "", int sequenceCode = 0)
        {
            int _left;
            int _top;
            counter++;

            Thread.Sleep(Delay);

            sequenceCode = sequenceCode > totalSequences - 1 ? 0 : sequenceCode;

            int counterValue = counter % 4;

            _left = (Console.WindowWidth - displayMsg.Length) / 2;
            _top = Console.WindowHeight / 2 - 1;
            Console.SetCursorPosition(_left, _top);
            Console.Write(displayMsg);

            _left = (Console.WindowWidth - sequence[sequenceCode, counterValue].Length) / 2;
            _top = Console.WindowHeight / 2 + 1;
            Console.SetCursorPosition(_left, _top);
            Console.Write(sequence[sequenceCode, counterValue]);
        }
    }

}
