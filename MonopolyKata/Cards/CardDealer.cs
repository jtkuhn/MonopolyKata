using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace MonopolyKata.Cards
{
    public class CardDealer
    {
        private Banker banker;
        private JailWarden jailWarden;
        private Board board;
        private List<Card> chanceCards;
        private List<Card> communityChestCards;
        public int chanceSize { get { return chanceCards.Count; } }
        public int communityChestSize { get { return communityChestCards.Count; } }
        private Dictionary<String, Player> getOutOfJailDictionary; 


        public CardDealer(Banker banker, JailWarden jailWarden, Board board)
        {
            this.banker = banker;
            this.jailWarden = jailWarden;
            this.board = board;
            chanceCards = new List<Card>();
            communityChestCards = new List<Card>();
            getOutOfJailDictionary = new Dictionary<String, Player>();

            InitializeCards();
        }

        public virtual Card DrawNextChanceCard()
        {
            Card cardToRemove = chanceCards[0];
            chanceCards.RemoveAt(0);
            return cardToRemove;
        }

        public void SetOwnerOfChanceJailCard(Player player)
        {
            getOutOfJailDictionary["chance"] = player;
        }

        public void SetOwnerOfCommunityChestJailCard(Player player)
        {
            getOutOfJailDictionary["community chest"] = player;
        }

        public virtual bool OwnsAGetOutOfJailCard(Player player)
        {
            return getOutOfJailDictionary.ContainsValue(player);
        }

        public void UsesAGetOutOfJailCard(Player player)
        {
            if (getOutOfJailDictionary.ContainsKey("community chest"))
            {
                if (getOutOfJailDictionary["community chest"] == player)
                {
                    getOutOfJailDictionary["community chest"] = null;
                    AddCardToCommunityChestPile(new GetOutOfJailCard());
                }
                else
                {
                    getOutOfJailDictionary["chance"] = null;
                    AddCardToChancePile(new GetOutOfJailCard());
                }
            }
            else
            {
                getOutOfJailDictionary["chance"] = null;
                AddCardToChancePile(new GetOutOfJailCard());
            }
        }

        public Card DrawNextCommunityChestCard()
        {
            Card cardToRemove = communityChestCards[0];
            communityChestCards.RemoveAt(0);
            return cardToRemove;
        }

        public virtual void AddCardToChancePile(Card card)
        {
            chanceCards.Add(card);
        }

        public void AddCardToCommunityChestPile(Card card)
        {
            communityChestCards.Add(card);
        }

        private void InitializeCards()
        {
            //For all the cards in the chance pile
            String[] chanceMoveCardNames = {"Advance to Go: Collect 200 Dollars", "Advance to Illinois Avenue", "Advance to St. Charles Place", "Take a Trip to Reading Railroad", "Take a Walk on the Boardwalk"};
            int[] chanceMoveCardPositions = {board.GetIndexOf("Go"), 24, 11, board.GetIndexOf("Reading Railroad"), 39};
            for (int i = 0; i < 5; i++)
            {
                AddCardToChancePile(new MovePlayerCard(chanceMoveCardNames[i], board, chanceMoveCardPositions[i]));
            }
            AddCardToChancePile(new PayPlayerMoneyCard("Bank Pays You Dividend of $50", banker, 50));
            AddCardToChancePile(new PayPlayerMoneyCard("Your Building and Loan Matures - Collect $150", banker, 150));
            AddCardToChancePile(new SendPlayerToJailCard("Go Directly To Jail", jailWarden));
            AddCardToChancePile(new TakeMoneyFromPlayerCard("Pay Poor Tax of $15", banker, 15));
            AddCardToChancePile(new PayPlayerMoneyCard("You Have Won a Crossword Competition - Collect $100", banker, 100));
            AddCardToChancePile(new GetOutOfJailCard());

            ShufflePile(chanceCards);


            //for all the cards in the community chest pile
            AddCardToCommunityChestPile(new MovePlayerCard("Advance to Go: Collect 200 Dollars", board, board.GetIndexOf("Go")));
            AddCardToCommunityChestPile(new PayPlayerMoneyCard("Bank Error in Your Favor - Collect $200", banker, 200));
            AddCardToCommunityChestPile(new TakeMoneyFromPlayerCard("Doctor's Fees - Pay $50", banker, 50));
            AddCardToCommunityChestPile(new PayPlayerMoneyCard("From Sale of Stock You Get $50", banker, 50));
            AddCardToCommunityChestPile(new SendPlayerToJailCard("go Directly To Jail", jailWarden));
            AddCardToCommunityChestPile(new PayPlayerMoneyCard("Holiday Fund Matures - Receive $100", banker, 100));
            AddCardToCommunityChestPile(new PayPlayerMoneyCard("Income Tax Refund - Collect $20", banker, 20));
            AddCardToCommunityChestPile(new PayPlayerMoneyCard("Life Insurace Matures - Collect $100", banker, 100));
            AddCardToCommunityChestPile(new TakeMoneyFromPlayerCard("Pay Hospital Fees of $100", banker, 100));
            AddCardToCommunityChestPile(new TakeMoneyFromPlayerCard("Pay School Fees of $150", banker, 150));
            AddCardToCommunityChestPile(new PayPlayerMoneyCard("Receive $25 Consultancy Fee", banker, 25));
            AddCardToCommunityChestPile(new PayPlayerMoneyCard("You Have Won Second Prize in a Beauty Contest - Collect $10", banker, 10));
            AddCardToCommunityChestPile(new PayPlayerMoneyCard("You Inherit $100", banker, 100));
            AddCardToCommunityChestPile(new GetOutOfJailCard());

            ShufflePile(communityChestCards);
        }

        private void ShufflePile(IList<Card> list)
        {
            Random rand = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
