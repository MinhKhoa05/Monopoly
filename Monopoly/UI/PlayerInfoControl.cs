using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.UI
{
    public partial class PlayerInfoControl : UserControl
    {
        public Player Player { get; set; }

        public PlayerInfoControl()
        {
            InitializeComponent();
        }

        public PlayerInfoControl(Player player) : this()
        {
            Player = player;
            UpdateUI();
        }

        public void UpdateUI()
        {
            if (Player == null) return;
            
            labelToken.Text = Player.Token;
            labelToken.ForeColor = Player.Color;
            labelInfo.Text = Player.GetInfo();
        }
    }
}
