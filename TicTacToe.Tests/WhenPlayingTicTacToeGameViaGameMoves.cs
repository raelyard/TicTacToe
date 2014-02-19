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
            var game = new Game();
            foreach (var move in moves)
            {
                game.Move(move);
            }
            return game.OutCome;
        }
    }

    public class Game
    {
        private readonly IList<string> _xSpaces;
        private readonly IList<string> _oSpaces;
        private bool _xMovesNext;

        private int OccupiedSpacesCount
        {
            get { return _xSpaces.Count + _oSpaces.Count; }
        }

        public Game()
        {
            _xMovesNext = true;
            _xSpaces = new List<string>();
            _oSpaces = new List<string>();
        }

        public void Move(string space)
        {
            if (_xMovesNext)
            {
                _xSpaces.Add(space);
            }
            else
            {
                _oSpaces.Add(space);
            }
            _xMovesNext = !_xMovesNext;
        }

        public GameResult? OutCome
        {
            get
            {
                if (SideWinsForRow(_xSpaces, "A"))
                {
                    return GameResult.XWins;
                }
                if (SideWinsForRow(_oSpaces, "A"))
                {
                    return GameResult.OWins;
                }
                if (OccupiedSpacesCount == 9)
                {
                    return GameResult.NoWinner;
                }
                return null;
            }
        }

        private bool SideWinsForRow(IEnumerable<string> sideSpaces, string rowIdentifier)
        {
            return sideSpaces.Count(space => space.StartsWith(rowIdentifier)) == 3;
        }
    }

    public enum GameResult
    {
        XWins,
        OWins,
        NoWinner
    }
}
