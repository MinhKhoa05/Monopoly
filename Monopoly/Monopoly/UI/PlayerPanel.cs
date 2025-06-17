using System.Windows.Forms;
using System.Drawing;

namespace Monopoly.UI
{
    public class PlayerPanel : Panel
    {
        private Player _player;
        private Label _nameLabel;
        private Panel _colorBox;

        public PlayerPanel()
        {
            InitializeComponent(new Player("Default Player", Color.Gray));
        }

        public PlayerPanel(Player player)
        {
            InitializeComponent(player);
        }

        private void InitializeComponent(Player player)
        {
            this.Dock = DockStyle.Top;
            this.Height = 40;
            _player = player;

            _colorBox = new Panel
            {
                Width = 20,
                Height = 20,
                Location = new Point(10, 10),
                BackColor = player.Color,
                BorderStyle = BorderStyle.FixedSingle
            };

            _nameLabel = new Label
            {
                Text = $"{player.Name} - {player.Money}$",
                Location = new Point(35, 10),
                Size = new Size(267, 20),
                AutoSize = false,
                Font = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleLeft
            };

            this.Controls.Add(_colorBox);
            this.Controls.Add(_nameLabel);
        }

        public void UpdatePlayer(int money)
        {
            _player.Money = money;
            _nameLabel.Text = $"{_player.Name} - {_player.Money}$";
        }
    }
}
