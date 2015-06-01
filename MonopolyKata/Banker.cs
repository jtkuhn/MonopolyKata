namespace MonopolyKata
{
    public class Banker
    {
        public Banker()
        {
            
        }

        public virtual void TakeMoneyFromPlayer(Player player, int amountToTake)
        {
            player.Money -= amountToTake;
        }

        public virtual void GiveMoneyToPlayer(Player player, int amountToGive)
        {
            player.Money += amountToGive;
        }

        public void TransferMoney(Player receiver, Player giver, int amountToTransfer)
        {
            giver.Money -= amountToTransfer;
            receiver.Money += amountToTransfer;
        }
    }
}
