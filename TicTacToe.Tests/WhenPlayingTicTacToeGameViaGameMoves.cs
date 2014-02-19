using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class WhenPlayingTicTacToeGameViaGameMoves
    {
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
            var xSpaces = moves.Where((move, index) => index % 2 == 0);
            var oSpaces = moves.Where((move, index) => index % 2 == 1);
            if (SideWinsForRow(xSpaces, "A"))
            {
                return GameResult.XWins;
            }
            if (SideWinsForRow(oSpaces, "A"))
            {
                return GameResult.OWins;
            }
            if (moves.Length == 9)
            {
                return GameResult.NoWinner;
            }
            return null;
        }

        private bool SideWinsForRow(IEnumerable<string> sideSpaces, string rowIdentifier)
        {
            return sideSpaces.Count(space => space.StartsWith(rowIdentifier)) == 3;
        }

        private enum GameResult
        {
            XWins,
            OWins,
            NoWinner
        }
    }
}
