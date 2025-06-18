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

        public void UpdateUI()
        {
            //_player.Money = money;
            _colorBox.BackColor = _player.Color;
            _nameLabel.Text = $"{_player.Name} - {_player.Money}$";
        }

        public void PlayerTurned()
        {
            // Logic to handle when the player takes their turn, if needed
            // For example, you might want to update the UI or perform some actions
            //_colorBox.BorderStyle = BorderStyle.Fixed3D; // Highlight the player panel
            this.BorderStyle = BorderStyle.FixedSingle; // Highlight the player panel
            _nameLabel.Font = new Font(_nameLabel.Font, FontStyle.Bold); // Make the name bold
        }

        public void PlayerFinishedTurn()
        {
            // Logic to handle when the player finishes their turn, if needed
            // For example, you might want to reset the UI or perform some actions
            //_colorBox.BorderStyle = BorderStyle.FixedSingle; // Reset the border style
            this.BorderStyle = BorderStyle.None; // Reset the player panel highlight
            _nameLabel.Font = new Font(_nameLabel.Font, FontStyle.Regular); // Reset the font style
        }
    }
}
