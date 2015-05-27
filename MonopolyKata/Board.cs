using System.Linq;
using MonopolyKata.PropertySquares;
using MonopolyKata.PropertySquares.Properties;
using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata
{
    public class Board
    {
        private Square[] board;
        public int Size { get; set; }
        private IRentStrategy rentStrategy;

        public Board()
        {
            Size = 40;
            board = new Square[Size];
            for (int i = 0; i < Size; i++)
            {
                board[i] = new Square("Property " + i);
            }
            board[0] = new GoSquare();
            board[1] = new MonopolizableProperty(rentStrategy, "Mediterranean Avenue", Color.Brown);
            board[3] = new MonopolizableProperty(rentStrategy, "Baltic Avenue", Color.Brown);
            board[4] = new IncomeTaxSquare();
            board[5] = new RailroadSquare(rentStrategy, "Reading Railroad");
            board[10] = new JailSquare();
            board[12] = new UtilitySquare(rentStrategy, "Electric Company");
            board[15] = new RailroadSquare(rentStrategy, "Pennsylvania Railroad");
            board[25] = new RailroadSquare(rentStrategy, "B & O Railroad");
            board[28] = new UtilitySquare(rentStrategy, "Water Works");
            board[30] = new GoToJailSquare();
            board[35] = new RailroadSquare(rentStrategy, "Short Line");
        }

        public Square GetSquareAt(int index)
        {
            return board[index];
        }
        
        public void PlayerPassesBy(Player player, int position)
        {
            GetSquareAt(position%Size).IsPassedBy(player);
        }

        public int PlayerLandsOn(Player player, int position)
        {
            int newPosition = position%Size;
            GetSquareAt(newPosition).IsLandedOn(player);
            return newPosition;
        }

        public virtual int GetNumberOfRailroads(Player player)
        {
            return board.OfType<RailroadSquare>().Count(prop => prop.owner == player);
        }

        public virtual int GetNumberOfOwnedUtilities()
        {
            return board.OfType<UtilitySquare>().Count(prop => prop.owner != null);
        }

        public bool IsPartOfMonopoly(MonopolizableProperty property)
        {
            Player owner = property.owner;
            int count = board.OfType<MonopolizableProperty>().Count(prop => prop.owner != owner);
            return count <= 0;
        }
    }
}