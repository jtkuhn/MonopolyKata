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
            board[10] = new JailSquare();
            board[30] = new GoToJailSquare();
        }

        public Property GetPropertyAt(int index)
        {
            return board[index];
        }
    }
}