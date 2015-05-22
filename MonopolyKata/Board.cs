namespace MonopolyKata
{
    public class Board
    {
        private Property[] board;
        public int Size { get; set; }

        public Board(int size = 40)
        {
            Size = size;
            board  = new Property[size];
            for (int i = 0; i < size; i++)
            {
                board[i] = new Property("Property " + i);
            }
            board[0] = new GoSquare();
            board[4] = new IncomeTaxSquare();
            board[5] = new RailroadSquare("Reading Railroad");
            board[10] = new JailSquare();
            board[15] = new RailroadSquare("Pennsylvania Railroad");
            board[25] = new RailroadSquare("B & O Railroad");
            board[30] = new GoToJailSquare();
            board[35] = new RailroadSquare("Short Line");
        }

        public Property GetPropertyAt(int index)
        {
            return board[index];
        }

        public void SetPropertyAt(int index, Property property)
        {
            board[index] = property;
        }
        public void PlayerPassesBy(Player player, int position)
        {
            GetPropertyAt(position%Size).IsPassedBy(player);
        }

        public int PlayerLandsOn(Player player, int position)
        {
            int newPosition = position%Size;
            GetPropertyAt(newPosition).IsLandedOn(player);
            return newPosition;
        }

        public int GetNumberOfRailroads(Player player)
        {
            int count = 0;
            foreach (Property prop in board)
            {
                if (prop.GetType() == typeof (RailroadSquare))
                {
                    if (prop.owner == player) count++;
                }
            }
            return count;
        }
    }
}