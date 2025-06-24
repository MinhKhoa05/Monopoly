using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Events
{
    public class PlayerMovedEventArgs : EventArgs
    {
        public int OldPosition { get; }
        public int NewPosition { get; }
        public bool PassedGo { get; }

        public PlayerMovedEventArgs(int oldPos, int newPos, bool passedGo)
        {
            OldPosition = oldPos;
            NewPosition = newPos;
            PassedGo = passedGo;
        }
    }

    public class PlayerMoneyChangedEventArgs : EventArgs
    {
        public int NewMoney { get; }

        public PlayerMoneyChangedEventArgs(int newMoney)
        {
            NewMoney = newMoney;
        }
    }


    public class TileActionEventArgs : EventArgs
    {
        public string Message { get; }
        public bool RequiresConfirm { get; }
        public bool Confirmed { get; set; }

        public TileActionEventArgs(string message, bool requiresConfirm = false)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            RequiresConfirm = requiresConfirm;
            Confirmed = false;
        }
    }
}
