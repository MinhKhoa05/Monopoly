using System;
using System.Drawing;
using Monopoly.Tiles;

namespace Monopoly
{
    public class GameManager
    {
        public Player[] Players { get; }
        public Board Board { get; }
        public Dice[] Dices { get; }

        public int CurrentPlayerIndex { get; private set; } = 0;
        public Player CurrentPlayer => Players[CurrentPlayerIndex];

        public GameManager()
        {
            Players = new Player[]
            {
                new Player(0, "Minh Khoa", Color.Red),
                new Player(1, "Minh Tiến", Color.Blue),
                new Player(2, "Mai Phương", Color.Green),
                new Player(3, "Chấn Đông", Color.Orange)
            };

            Dices = new Dice[] { new Dice(), new Dice() };
            Board = new Board();

            Board.PlacePlayersAtStart(Players);
        }

        public void NextPlayerTurn()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Length;
        }

        public void ExecutePlayerTurn()
        {
            int totalMove = Dices[0].Value + Dices[1].Value;
            CurrentPlayer.Move(totalMove);
        }
    }
}
