using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class Tests1
    {
        [Test]
        public void XShouldWinWithEntireTopRow()
        {
            // X X X
            // O O
            // 
            var winner = Outcome("A1", "B1", "A2", "B2", "A3");
            winner.ShouldEqual("X");
        }

        [Test]
        public void OShouldWinWithEntireTopRow()
        {
            // O O O
            // X X
            // X
            var winner = Outcome("B1", "A1", "B2", "A2", "C1", "A3");
            winner.ShouldEqual("O");
        }

        [Test]
        public void XShouldWinWithEntireTopRowWithOtherInitialMove()
        {
            // X X X
            // O O 
            // X O
            var winner = Outcome("C!", "C2", "A1", "B1", "A2", "B2", "A3");
            winner.ShouldEqual("X");
        }

        private string Outcome(params string[] moves)
        {
            var xSpaces = moves.Where((move, index) => index % 2 == 0);
            var oSpaces = moves.Where((move, index) => index % 2 == 1);
            if (SideWinsForRow(xSpaces, "A"))
            {
                return "X";
            }
            if (SideWinsForRow(oSpaces, "A"))
            {
                return "O";
            }
            return null;
        }

        private bool SideWinsForRow(IEnumerable<string> sideSpaces, string rowIdentifier)
        {
            return sideSpaces.Count(space => space.StartsWith(rowIdentifier)) == 3;
        }
    }
}
