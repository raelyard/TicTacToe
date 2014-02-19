using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Should;
using TicTacToe.Console.Model;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class WhenPlayingTicTacToeGameViaGameMoves
    {
        private const bool UseUserInterface = true;
        private Process _consoleProcess;

        [Test]
        public void XShouldWinWithEntireTopRow()
        {
            // X X X
            // O O
            // 
            var winner = Outcome("A1", "B1", "A2", "B2", "A3");
            winner.ShouldEqual(GameResult.XWins);
        }

        [Test]
        public void OShouldWinWithEntireTopRow()
        {
            // O O O
            // X X
            // X
            var winner = Outcome("B1", "A1", "B2", "A2", "C1", "A3");
            winner.ShouldEqual(GameResult.OWins);
        }

        [Test]
        public void XShouldWinWithEntireTopRowWithOtherInitialMove()
        {
            // X X X
            // O O 
            // X O
            var winner = Outcome("C!", "C2", "A1", "B1", "A2", "B2", "A3");
            winner.ShouldEqual(GameResult.XWins);
        }

        [Test]
        public void GameShouldFinishInTieWithNoRowsControlled()
        {
            // X X O
            // O O X
            // X O X
            var winner = Outcome("C!", "C2", "A1", "B1", "A2", "B2", "B3", "A3", "C3");
            winner.ShouldEqual(GameResult.NoWinner);
        }

        private GameResult? Outcome(params string[] moves)
        {
            return UseUserInterface ? OutcomeViaUserInterface(moves) : OutcomeViaModel(moves);
        }

        private GameResult? OutcomeViaModel(IEnumerable<string> moves)
        {
            var game = new Game();
            foreach (var move in moves)
            {
                game.Move(move);
            }
            return game.OutCome;
        }

        private GameResult? OutcomeViaUserInterface(IEnumerable<string> moves)
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
