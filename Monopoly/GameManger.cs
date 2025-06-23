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

        public GameManager()
        {
            Players = new Player[]
            {
                new Player("Hồ Nguyễn Minh Khoa", Color.Red),
                new Player("Hồ Nguyễn Minh Tiến", Color.Blue),
                new Player("Hồ Nguyễn Mai Phương", Color.LightGreen),
                new Player("Nguyễn Ngọc Chấn Đông", Color.Orange)
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
        }
    }
}