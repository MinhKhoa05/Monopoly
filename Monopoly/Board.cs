using System.Windows.Forms;
using Monopoly.UI;
using Monopoly.Events;

namespace Monopoly
{
    public class Board
    {
        public BaseTileControl[] TileControls { get; private set; }

        public Board()
        {
            InitializeTiles();
        }

        private void InitializeTiles()
        {
            var configs = TileData.GetTiles();
            TileControls = new BaseTileControl[configs.Length];

            for (int i = 0; i < configs.Length; i++)
            {
                var config = configs[i];

                TileControls[i] = config.IsSpecial
                    ? TileFactory.CreateSpecialTile(config.Name, config.Color, config.Symbol)
                    : TileFactory.CreatePropertyTile(config.Name, config.Color, config.Price, config.Rent);
            }
        }

        public void PlacePlayersAtStart(Player[] players)
        {
            foreach (var player in players)
            {
                player.PlayerMoved += OnPlayerMoved;
                TileControls[0].ShowToken(player);
            }
        }

        private void OnPlayerMoved(object sender, PlayerMovedEventArgs e)
        {
            var player = (Player)sender;

            TileControls[e.OldPosition].HideToken(player);
            TileControls[e.NewPosition].ShowToken(player);

            if (e.PassedGo)
            {
                MessageBox.Show($"{player.Name} đã đi qua ô GO và nhận {GameConfig.PassGoBonus}$");
            }

            TileControls[e.NewPosition].OnEnter(player);
        }
    }
}
