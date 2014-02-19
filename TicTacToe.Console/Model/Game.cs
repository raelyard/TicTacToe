using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Console.Model
{
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
