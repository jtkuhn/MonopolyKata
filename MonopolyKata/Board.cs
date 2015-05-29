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
        private RentStrategyFactory rsFactory;
        private Realtor realtor;
        private JailWarden jailWarden;

        public Board(Realtor realtor, JailWarden warden, DiceRoller diceRoller)
        {
            jailWarden = warden;
            jailWarden.SetPositionOfJail(10);
            rsFactory = new RentStrategyFactory();
            this.realtor = realtor;
            Size = 40;
            board = new Square[Size];
            for (int i = 0; i < Size; i++)
            {
                board[i] = new Square("Property " + i);
            }
            InitializeSquare(0, new GoSquare());
            InitializeSquare(1, new MonopolizableProperty(rsFactory.CreateMonopolizableStrategy(this), "Mediterranean Avenue", realtor, Color.Brown));
            InitializeSquare(3, new MonopolizableProperty(rsFactory.CreateMonopolizableStrategy(this), "Baltic Avenue", realtor, Color.Brown));
            InitializeSquare(4, new IncomeTaxSquare());
            InitializeSquare(5, new RailroadSquare(rsFactory.CreateRailroadStrategy(realtor), "Reading Railroad", realtor));
            InitializeSquare(6, new MonopolizableProperty(rsFactory.CreateMonopolizableStrategy(this), "Oriental Avenue", realtor, Color.LightBlue));
            InitializeSquare(8, new MonopolizableProperty(rsFactory.CreateMonopolizableStrategy(this), "Vermont Avenue", realtor, Color.LightBlue));
            InitializeSquare(9, new MonopolizableProperty(rsFactory.CreateMonopolizableStrategy(this), "Connecticut Avenue", realtor, Color.LightBlue));
            InitializeSquare(10, new JailSquare());
            InitializeSquare(12, new UtilitySquare(rsFactory.CreateUtilityStrategy(diceRoller, realtor), "Electric Company", realtor));
            InitializeSquare(15, new RailroadSquare(rsFactory.CreateRailroadStrategy(realtor), "Pennsylvania Railroad", realtor));
            InitializeSquare(25, new RailroadSquare(rsFactory.CreateRailroadStrategy(realtor), "B & O Railroad", realtor));
            InitializeSquare(28, new UtilitySquare(rsFactory.CreateUtilityStrategy(diceRoller, realtor), "Water Works", realtor));
            InitializeSquare(30, new GoToJailSquare(jailWarden));
            InitializeSquare(35, new RailroadSquare(rsFactory.CreateRailroadStrategy(realtor), "Short Line", realtor));
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

        public void MovePlayer(Player player, int distance)
        {
            for (int i = 1; i < distance; i++)
            {
                PlayerPassesBy(player, player.Position + i);
            }
            player.Position = PlayerLandsOn(player, player.Position + distance);
        }
    }
}