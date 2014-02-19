using System.Diagnostics;
using Should;
using TicTacToe.Console.Model;

namespace TicTacToe.Tests
{
    public class WhenPlayerTicTacToeGameViaConsoleUserInterface : WhenPlayingTicTacToeGameViaGameMovesBase
    {
        protected override GameResult? Outcome(params string[] moves)
        {
            ExecuteApplication();
            foreach (var move in moves)
            {
                ExecuteConsoleInput(move);
            }
            return ParseConsoleOutputAsGameResult();
        }

        private void ExecuteApplication()
        {
            _consoleProcess = new Process
            {
                StartInfo =
                    new ProcessStartInfo
                    {
                        FileName = @"..\..\..\TicTacToe.Console\bin\Debug\TicTacToe.Console.exe",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true
                    }
            };

            _consoleProcess.Start();
        }

        private string ReadConsoleOutput()
        {
            return _consoleProcess.StandardOutput.ReadLine();
        }

        private void ExecuteConsoleInput(string move)
        {
            System.Console.WriteLine(_consoleProcess.StandardOutput.ReadLine());
            _consoleProcess.StandardInput.WriteLine(move);
        }

        private GameResult? ParseConsoleOutputAsGameResult()
        {
            var outputline = ReadConsoleOutput();
            System.Console.WriteLine(outputline);
            outputline.ShouldEqual("The game is over, dude");
            outputline = ReadConsoleOutput();
            System.Console.WriteLine(outputline);
            if (outputline == "X Wins")
            {
                return GameResult.XWins;
            }
            if (outputline == "O Wins")
            {
                return GameResult.OWins;
            }
            if (outputline == "You have kissed your sister")
            {
                return GameResult.NoWinner;
            }
            return null;
        }
    }
}
