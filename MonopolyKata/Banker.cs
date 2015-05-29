using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Banker
    {
        public Banker()
        {
            
        }

        public void TakeMoneyFromPlayer(Player player, int amountToTake)
        {
            player.Money -= amountToTake;
        }

        public void GiveMoneyToPlayer(Player player, int amountToGive)
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
