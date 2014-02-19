using TicTacToe.Console.Model;

namespace TicTacToe.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            while (!game.OutCome.HasValue)
            {
                System.Console.WriteLine("Make your move, chump:");
                var move = System.Console.ReadLine();
                game.Move(move);
            }
            System.Console.WriteLine("The game is over, dude");
            System.Console.WriteLine(game.OutCome == GameResult.XWins ? "X Wins" : game.OutCome == GameResult.OWins ? "O Wins" : "You have kissed your sister");
        }
    }
}
