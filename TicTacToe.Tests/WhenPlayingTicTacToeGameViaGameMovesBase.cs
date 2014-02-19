using System.Diagnostics;
using NUnit.Framework;
using Should;
using TicTacToe.Console.Model;

namespace TicTacToe.Tests
{
    [TestFixture]
    public abstract class WhenPlayingTicTacToeGameViaGameMovesBase
    {
        protected Process _consoleProcess;

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

        protected abstract GameResult? Outcome(params string[] moves);
    }
}
