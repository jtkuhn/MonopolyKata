namespace MonopolyKata.Cards
{
    public class LazyLoadCardDealer
    {
        private CardDealer dealer;
        private Board _board;

        public int chanceSize { get
        {
            if (dealer == null) Init(); 
            return dealer.chanceSize; } 
        }

        public int communityChestSize { get
        {
            if (dealer == null) Init();
            return dealer.communityChestSize; } 
        }

        public Board Board
        {
            set { _board = value; }
        }

        private Banker banker;
        private JailWarden jailWarden;

        public LazyLoadCardDealer(Banker banker, JailWarden jailWarden)
        {
            this.banker = banker;
            this.jailWarden = jailWarden;
        }

        private void Init()
        {
            dealer = new CardDealer(banker, jailWarden, _board);
        }

        public virtual Card DrawNextChanceCard()
        {
            if (dealer == null) Init();
            return dealer.DrawNextChanceCard();
        }

        public Card DrawNextCommunityChestCard()
        {
            if (dealer == null) Init();
            return dealer.DrawNextCommunityChestCard();
        }

        public void SetOwnerOfChanceJailCard(Player player)
        {
            if (dealer == null) Init();
            dealer.SetOwnerOfChanceJailCard(player);
        }

        public void SetOwnerOfCommunityChestJailCard(Player player)
        {
            if (dealer == null) Init();
            dealer.SetOwnerOfCommunityChestJailCard(player);
        }

        public virtual bool OwnsAGetOutOfJailCard(Player player)
        {
            if (dealer == null) Init();
            return dealer.OwnsAGetOutOfJailCard(player);
        }

        public void UsesAGetOutOfJailCard(Player player)
        {
            if (dealer == null) Init();
            dealer.UsesAGetOutOfJailCard(player);
        }

        public virtual void AddCardToChancePile(Card card)
        {
            if (dealer == null) Init();
            dealer.AddCardToChancePile(card);
        }

        public void AddCardToCommunityChestPile(Card card)
        {
            if (dealer == null) Init();
            dealer.AddCardToCommunityChestPile(card);
        }
    }
}
