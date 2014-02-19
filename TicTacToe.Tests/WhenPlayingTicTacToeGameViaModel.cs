using NUnit.Framework;
using TicTacToe.Console.Model;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class WhenPlayingTicTacToeGameViaModel : WhenPlayingTicTacToeGameViaGameMovesBase
    {
        protected override GameResult? Outcome(params string[] moves)
        {
            var game = new Game();
            foreach (var move in moves)
            {
                game.Move(move);
            }
            return game.OutCome;
        }
    }
}
