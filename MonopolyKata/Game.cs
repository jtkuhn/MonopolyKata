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

        public void PlayOneTurnForAllPlayers()
        {
            foreach (Player currentPlayer in players)
            {
                PlayOneTurn(currentPlayer);
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

        public void PlayOneTurn(Player player)
        {
            if (jailWarden.IsInJail(player)) PlayOneTurnInJail(player);
            else PlayOneTurnOnBoard(player);
        }

        public void PlayOneTurnOnBoard(Player player)
        {
            diceRoller.GetNextRoll();
            board.MovePlayer(player, diceRoller.GetLastRoll());
            int doubles = 1;
            while (diceRoller.WasDoubles() && !jailWarden.IsInJail(player))
            {
                diceRoller.GetNextRoll();
                if (diceRoller.WasDoubles()) doubles++;

                if (doubles == 3) jailWarden.MovePlayerToJail(player);
                else board.MovePlayer(player, diceRoller.GetLastRoll());
            }
        }

        public void PlayOneTurnInJail(Player player)
        {
            diceRoller.GetNextRoll();

            if (diceRoller.WasDoubles())
            {
                jailWarden.GetsOutOfJail(player);
                board.MovePlayer(player, diceRoller.GetLastRoll());
            }
            else
            {
                jailWarden.FailsToEscapeWithDoubles(player);

                if (jailWarden.TurnsInJail(player) > 3)
                {
                    player.Money -= 50;
                    jailWarden.GetsOutOfJail(player);
                    board.MovePlayer(player, diceRoller.GetLastRoll());
                }
            }
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

        public void Pay50ToGetOutOfJail(Player player)
        {
            if (jailWarden.IsInJail(player))
            {
                player.Money -= 50;
                jailWarden.GetsOutOfJail(player);
            }
        }

        public void SetDiceRoller(DiceRoller diceRoller)
        {
            this.diceRoller = diceRoller;
        }

        public JailWarden GetJailWarden()
        {
            return jailWarden;
        }
    }
}
