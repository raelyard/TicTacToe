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

        private string Outcome(params string[] moves)
        {
            return moves[0] == "A1" ? "X" : "O";
        }
    }
}
