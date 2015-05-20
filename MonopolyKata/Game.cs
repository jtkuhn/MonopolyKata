﻿using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class Game
    {
        public Player[] players;
        private Random rand = new Random();
        private Realtor realtor;

        private readonly Board board;
        
        public Board Board
        {
            get { return board; }
        }
        
        public Game(int numberOfPlayers)
        {
            players = new Player[numberOfPlayers];
            RandomlyOrderPlayers();

            BoardFactory bd = new BoardFactory();
            board = bd.Create();
        }

        public void PlayOneTurn()
        {
            foreach (Player currentPlayer in players)
            {
                int die1 = rand.Next(1, 7);
                int die2 = rand.Next(1, 7);
                currentPlayer.Move(board, die1 + die2);
            }
        }

        private void RandomlyOrderPlayers()
        {
            for (int j = 0; j < players.Length; j++)
            {
                players[j] = new Player("Player " + j);
            }
            Shuffle(players);
        }

        private void Shuffle(IList<Player> list)
        {
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