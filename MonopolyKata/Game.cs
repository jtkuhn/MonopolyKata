using System;
using System.Collections.Generic;
using MonopolyKata.PropertySquares.Rent;

namespace MonopolyKata
{
    public class Game
    {
        public Player[] players;
        private DiceRoller diceRoller = new DiceRoller();
        private readonly Board board;
        
        public Board Board
        {
            get { return board; }
        }
        
        public Game(int numberOfPlayers)
        {
            BoardFactory bd = new BoardFactory();
            board = bd.Create();

            players = new Player[numberOfPlayers];
            RandomlyOrderPlayers(board);
        }

        public void PlayOneTurn()
        {
            foreach (Player currentPlayer in players)
            {
                int dice = diceRoller.GetNextRoll();
                currentPlayer.Move(dice);
            }
        }

        private void RandomlyOrderPlayers(Board board)
        { 
            for (int j = 0; j < players.Length; j++)
            {
                players[j] = new Player("Player " + j, board);
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
