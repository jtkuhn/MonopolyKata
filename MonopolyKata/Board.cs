using System;
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
        private Banker banker;

        public Board(Realtor realtor, JailWarden warden, Banker banker, DiceRoller diceRoller)
        {
            this.banker = banker;
            jailWarden = warden;
            jailWarden.SetPositionOfJail(10);
            this.realtor = realtor;
            rsFactory = new RentStrategyFactory(realtor);
            Size = 40;
            board = new Square[Size];
            for (int i = 0; i < Size; i++)
            {
                board[i] = new Square("Property " + i);
            }
            InitializeSquare(0, new GoSquare(banker));
            InitializeSquare(1, new MonopolizableProperty(rsFactory.CreateMonopolizableStrategy(this), banker, "Mediterranean Avenue", realtor, Color.Brown));
            InitializeSquare(3, new MonopolizableProperty(rsFactory.CreateMonopolizableStrategy(this), banker, "Baltic Avenue", realtor, Color.Brown));
            InitializeSquare(4, new IncomeTaxSquare(banker));
            InitializeSquare(5, new RailroadSquare(rsFactory.CreateRailroadStrategy(), banker, "Reading Railroad", realtor));
            InitializeSquare(6, new MonopolizableProperty(rsFactory.CreateMonopolizableStrategy(this), banker, "Oriental Avenue", realtor, Color.LightBlue));
            InitializeSquare(8, new MonopolizableProperty(rsFactory.CreateMonopolizableStrategy(this), banker, "Vermont Avenue", realtor, Color.LightBlue));
            InitializeSquare(9, new MonopolizableProperty(rsFactory.CreateMonopolizableStrategy(this), banker, "Connecticut Avenue", realtor, Color.LightBlue));
            InitializeSquare(10, new JailSquare());
            InitializeSquare(12, new UtilitySquare(rsFactory.CreateUtilityStrategy(diceRoller), banker, "Electric Company", realtor));
            InitializeSquare(15, new RailroadSquare(rsFactory.CreateRailroadStrategy(), banker, "Pennsylvania Railroad", realtor));
            InitializeSquare(25, new RailroadSquare(rsFactory.CreateRailroadStrategy(), banker, "B & O Railroad", realtor));
            InitializeSquare(28, new UtilitySquare(rsFactory.CreateUtilityStrategy(diceRoller), banker, "Water Works", realtor));
            InitializeSquare(30, new GoToJailSquare(jailWarden));
            InitializeSquare(35, new RailroadSquare(rsFactory.CreateRailroadStrategy(), banker, "Short Line", realtor));
            InitializeSquare(38, new LuxuryTaxSquare(banker));
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

        public virtual void MovePlayer(Player player, int distance)
        {
            for (int i = 1; i < distance; i++)
            {
                PlayerPassesBy(player, player.Position + i);
            }
            player.Position = PlayerLandsOn(player, player.Position + distance);
        }

        public int GetIndexOf(String name)
        {
            for (int i = 0; i < Size; i++)
            {
                if (name == board[i].Name) return i;
            }
            return -1;
        }
    }
}