using System.Collections.Generic;

namespace MonopolyKata
{
    public class JailWarden
    {
        private int positionOfJail;
        private Dictionary<Player, int> timeInJail;

        public JailWarden()
        {
            timeInJail = new Dictionary<Player, int>();
        }

        public void SetPositionOfJail(int position)
        {
            positionOfJail = position;
        }

        public virtual void MovePlayerToJail(Player player)
        {
            player.Position = positionOfJail;
            timeInJail[player] = 1;
        }

        public bool IsInJail(Player player)
        {
            if(timeInJail.ContainsKey(player)) return (timeInJail[player] > 0);
            return false;
        }

        public int TurnsInJail(Player player)
        {
            return timeInJail.ContainsKey(player) ? timeInJail[player] : 0;
        }

        public void FailsToEscapeWithDoubles(Player player)
        {
            timeInJail[player]++;
        }

        public void GetsOutOfJail(Player player)
        {
            timeInJail[player] = 0;
        }
    }
}
