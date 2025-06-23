using System;

namespace Monopoly
{
    public class PlayerMove : EventArgs
    {
        public Player Player { get; private set; }
        public int From { get; private set; }
        public int To { get; private set; }

        public PlayerMove(Player player, int from, int to)
        {
            Player = player;
            From = from;
            To = to;
        }
    }
}
