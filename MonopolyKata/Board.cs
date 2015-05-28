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
        private Realtor realtor;

        public Board(Realtor realtor)
        {
            this.realtor = realtor;
            Size = 40;
            board = new Square[Size];
            for (int i = 0; i < Size; i++)
            {
                board[i] = new Square("Property " + i);
            }
            InitializeSquare(0, new GoSquare());
            InitializeSquare(1, new MonopolizableProperty(rentStrategy, "Mediterranean Avenue", realtor, Color.Brown));
            InitializeSquare(3, new MonopolizableProperty(rentStrategy, "Baltic Avenue", realtor, Color.Brown));
            InitializeSquare(4, new IncomeTaxSquare());
            InitializeSquare(5, new RailroadSquare(rentStrategy, "Reading Railroad", realtor));
            InitializeSquare(10, new JailSquare());
            InitializeSquare(12, new UtilitySquare(rentStrategy, "Electric Company", realtor));
            InitializeSquare(15, new RailroadSquare(rentStrategy, "Pennsylvania Railroad", realtor));
            InitializeSquare(25, new RailroadSquare(rentStrategy, "B & O Railroad", realtor));
            InitializeSquare(28, new UtilitySquare(rentStrategy, "Water Works", realtor));
            InitializeSquare(30, new GoToJailSquare());
            InitializeSquare(35, new RailroadSquare(rentStrategy, "Short Line", realtor));
        }

        private void InitializeSquare(int position, Square square)
        {
            board[position] = square;
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

        public virtual bool IsPartOfMonopoly(MonopolizableProperty property)
        {
            Player owner = realtor.GetOwnerOf(property);
            Color color = property.Color;
            int count = board.OfType<MonopolizableProperty>().Where(prop => prop.Color == color).Count(prop => realtor.GetOwnerOf(prop) != owner);
            return count <= 0;
        }
    }
}