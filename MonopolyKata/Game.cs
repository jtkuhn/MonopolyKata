using System;
using System.Collections.Generic;
using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata
{
    public class Game
    {
        public Player[] players;
        private DiceRoller diceRoller;
        private readonly Board board;
        private Realtor realtor;
        private JailWarden jailWarden;
        
        public Board Board
        {
            get { return board; }
        }
        
        public Game(int numberOfPlayers)
        {
            diceRoller = new DiceRoller();
            realtor = new Realtor();
            jailWarden = new JailWarden();
            board = new Board(realtor, jailWarden);

            players = new Player[numberOfPlayers];
            RandomlyOrderPlayers(board);
        }

        public void PlayOneTurn()
        {
            foreach (Player currentPlayer in players)
            {
                int dice = diceRoller.GetNextRoll();
                board.MovePlayer(currentPlayer, dice);
            }
        }

        private void RandomlyOrderPlayers(Board board)
        { 
            for (int j = 0; j < players.Length; j++)
            {
                players[j] = new Player("Player " + j);
            }
            Shuffle(players);
        }

        private void Shuffle(IList<Player> list)
        {
            Random rand = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Player value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
