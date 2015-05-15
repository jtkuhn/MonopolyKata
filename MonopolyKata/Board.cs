namespace MonopolyKata
{
    public class Board
    {
        private Property[] board;
        public int size;

        public Board(int size = 40)
        {
            board  = new Property[size];
            for (int i = 0; i < size; i++)
            {
                board[i] = new Property("Property " + i);
            }
            board[0] = new GoSquare();
            board[10] = new JailSquare();
            board[30] = new GoToJailSquare();
        }

        public Property GetPropertyAt(int index)
        {
            return board[index];
        }
    }
}