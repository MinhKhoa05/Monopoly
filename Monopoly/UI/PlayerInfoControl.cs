using System.Drawing;
using System.Windows.Forms;

namespace Monopoly.UI
{
    public partial class PlayerInfoControl : UserControl
    {
        public Player Player { get; set; }

        private bool _isCurrentPlayer;
        public bool IsCurrentPlayer
        {
            get => _isCurrentPlayer;
            set
            {
                _isCurrentPlayer = value;
                UpdateTurn();
            }
        }

        public PlayerInfoControl() : this(new Player(0, "Default Player", Color.Silver)) { }

        public PlayerInfoControl(Player player)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;

            Player = player;

            UpdatePlayerUI();
        }

        public void UpdatePlayerUI()
        {
            if (Player == null) return;

            labelToken.Text = Player.Token;
            labelToken.ForeColor = Player.Color;
            labelInfo.Text = Player.GetInfo();
        }

        private void UpdateTurn()
        {
            BorderStyle = IsCurrentPlayer ? BorderStyle.FixedSingle : BorderStyle.None;
            labelInfo.Font = new Font(labelInfo.Font, IsCurrentPlayer ? FontStyle.Bold : FontStyle.Regular);
        }
    }
}
