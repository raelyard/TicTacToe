using System.Linq;
using System.Net;
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
            var winner = Outcome("A1", "B1", "A2", "B2", "A3");
            winner.ShouldEqual("X");
        }

        [Test]
        public void OShouldWinWithEntireTopRow()
        {
            var winner = Outcome("B1", "A1", "B2", "A2", "C1", "A3");
            winner.ShouldEqual("O");
        }

        [Test]
        public void XShouldWinWithEntireTopRowWithOtherInitialMove()
        {
            var winner = Outcome("C!", "C2", "A1", "B1", "A2", "B2", "A3");
            winner.ShouldEqual("X");
        }

        private string Outcome(params string[] moves)
        {
            var xSpaces = moves.Where((move, index) => index % 2 == 0);
            var oSpaces = moves.Where((move, index) => index % 2 == 1);
            if (xSpaces.Count(space => space.StartsWith("A")) == 3)
            {
                return "X";
            }
            if (oSpaces.Count(space => space.StartsWith("A")) == 3)
            {
                return "O";
            }
            return null;
        }
    }
}
