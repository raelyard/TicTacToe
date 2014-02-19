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

        private string Outcome(params string[] moves)
        {
            return "X";
        }
    }
}
