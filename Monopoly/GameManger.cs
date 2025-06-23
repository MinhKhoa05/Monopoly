using System;
using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly
{
    public class GameManager
    {
        public Player[] Players { get; private set; }
        public Board Board { get; private set; } = new Board();
        public int CurrentPlayerIndex { get; set; } = 0; // Index of the current player
        public Dice[] Dices { get; private set; }
        public event EventHandler<PlayerMoveEvent> PlayerMove;

        public GameManager()
        {
            Players = new Player[]
            {
                new Player("Minh Khoa", Color.Red),
                new Player("Minh Tiến", Color.Blue),
                new Player("Mai Phương", Color.LightGreen),
                new Player("Chấn Đông", Color.Orange)
            };

            Dices = new Dice[2] { new Dice(), new Dice() };
        }

        public void RollDices()
        {
            foreach (var dice in Dices)
            {
                dice.Roll();
            }
        }

        public void NextPlayer()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Length;
        }

        public void PlayerTurn()
        {
            Player currentPlayer = Players[CurrentPlayerIndex];
            RollDices();
            int from = currentPlayer.Position;
            int totalMove = Dices[0].Value + Dices[1].Value;
            currentPlayer.Move(totalMove);
            
            int to = currentPlayer.Position;
            //ITile currentTile = Board.GetTileAt(currentPlayer.Position);
            //currentTile.OnEnter(currentPlayer);

            PlayerMove?.Invoke(this, new PlayerMoveEvent(from, to, currentPlayer));
            //NextPlayer();
        }
    }

    public class PlayerMoveEvent : EventArgs
    {
        public int From { get; private set; }
        public int To { get; private set; }
        public Player Player { get; private set; }

        public PlayerMoveEvent(int from, int to, Player player)
        {
            From = from;
            To = to;
            Player = player;
        }
    }
}