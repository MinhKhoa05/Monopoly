using System;
using System.Drawing;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class MainForm : Form
    {
        private Panel boardPanel;
        private Panel centerPanel;
        private Button rollDiceButton;
        private Label[] playerLabels;
        private PictureBox dice1PictureBox;
        private PictureBox dice2PictureBox;
        private Panel questionPanel;

        private int currentPlayer = 1;
        private int[] playerMoney = { 0, 18000, 16800, 18000, 19760 }; // Index 0 không dùng
        private int[] playerPosition = { 0, 0, 0, 0, 0 };
        private Random random = new Random();

        // Danh sách các ô đơn giản
        private string[] boardSquares = {
            "START", "Property 1\n$1500", "Chance", "Property 2\n$1000", "Property 3\n$2200",
            "Station\n$1000", "Property 4\n$1600", "Property 5\n$1700", "Property 6\n$1800", "Chance",
            "Property 7\n$1200", "Jail", "Property 8\n$2800", "Property 9\n$1400", "Property 10\n$1000",
            "Station\n$1000", "Property 11\n$1200", "Property 12\n$3000", "Chance", "Property 13\n$1200",
            "Free Park", "Property 14\n$1200", "Chance", "Property 15\n$1400", "Property 16\n$1200",
            "Property 17\n$1200", "Property 18\n$1000", "Property 19\n$1800", "Property 20\n$1000", "Chance",
            "Property 21\n$1200", "Property 22\n$2000", "Property 23\n$3200", "Property 24\n$1500", "Property 25\n$1200",
            "Property 26\n$1600", "Chance", "Property 27\n$1800", "Property 28\n$1500", "Go to Jail"
        };

        private int[] propertyPrices = {
            0, 1500, 0, 1000, 2200, 1000, 1600, 1700, 1800, 0,
            1200, 0, 2800, 1400, 1000, 1000, 1200, 3000, 0, 1200,
            0, 1200, 0, 1400, 1200, 1200, 1000, 1800, 1000, 0,
            1200, 2000, 3200, 1500, 1200, 1600, 0, 1800, 1500, 0
        };

        private Button[] squareButtons;
        private PictureBox[] playerPieces;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Monopoly Game";
            this.Size = new Size(800, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 248, 255);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            CreateBoardPanel();
            CreateCenterPanel();
            CreatePlayerPieces();

            UpdateUI();
        }

        private void CreateBoardPanel()
        {
            boardPanel = new Panel();
            boardPanel.Size = new Size(780, 680);
            boardPanel.Location = new Point(10, 10);
            boardPanel.BackColor = Color.FromArgb(240, 248, 255);
            this.Controls.Add(boardPanel);

            squareButtons = new Button[40];

            // Tạo các ô xung quanh bàn cờ
            for (int i = 0; i < 40; i++)
            {
                Button square = new Button();
                square.Size = new Size(70, 55);
                square.BackColor = GetSquareColor(i);
                square.ForeColor = Color.Black;
                square.Text = boardSquares[i];
                square.Font = new Font("Arial", 7, FontStyle.Bold);
                square.FlatStyle = FlatStyle.Flat;
                square.FlatAppearance.BorderColor = Color.Black;
                square.FlatAppearance.BorderSize = 1;
                square.Tag = i;
                square.TextAlign = ContentAlignment.MiddleCenter;

                // Tính toán vị trí của ô
                Point position = CalculateSquarePosition(i);
                square.Location = position;

                boardPanel.Controls.Add(square);
                squareButtons[i] = square;
            }
        }

        private Color GetSquareColor(int index)
        {
            // Ô đặc biệt
            if (index == 0) return Color.LightGreen; // START
            if (index == 10) return Color.Orange; // JAIL
            if (index == 20) return Color.LightCoral; // FREE PARKING
            if (index == 30) return Color.Red; // GO TO JAIL
            if (index == 2 || index == 9 || index == 18 || index == 29 || index == 22 || index == 36) return Color.LightYellow; // CHANCE
            if (index == 5 || index == 15) return Color.LightBlue; // STATION

            // Ô property thường
            return Color.White;
        }

        private Point CalculateSquarePosition(int index)
        {
            int startX = 50, startY = 50;
            int squareWidth = 70, squareHeight = 55;

            if (index <= 10) // Cạnh dưới
            {
                return new Point(startX + (10 - index) * squareWidth, startY + 550);
            }
            else if (index <= 20) // Cạnh trái
            {
                return new Point(startX, startY + 550 - (index - 10) * squareHeight);
            }
            else if (index <= 30) // Cạnh trên
            {
                return new Point(startX + (index - 20) * squareWidth, startY);
            }
            else // Cạnh phải
            {
                return new Point(startX + 700, startY + (index - 30) * squareHeight);
            }
        }

        private void CreateCenterPanel()
        {
            // Panel chứa xúc xắc ở giữa
            centerPanel = new Panel();
            centerPanel.Size = new Size(300, 200);
            centerPanel.Location = new Point(240, 250);
            centerPanel.BackColor = Color.White;
            centerPanel.BorderStyle = BorderStyle.FixedSingle;
            boardPanel.Controls.Add(centerPanel);

            // Xúc xắc ở giữa
            dice1PictureBox = new PictureBox();
            dice1PictureBox.Size = new Size(40, 40);
            dice1PictureBox.Location = new Point(100, 50);
            dice1PictureBox.BackColor = Color.White;
            dice1PictureBox.BorderStyle = BorderStyle.FixedSingle;
            centerPanel.Controls.Add(dice1PictureBox);

            dice2PictureBox = new PictureBox();
            dice2PictureBox.Size = new Size(40, 40);
            dice2PictureBox.Location = new Point(150, 50);
            dice2PictureBox.BackColor = Color.White;
            dice2PictureBox.BorderStyle = BorderStyle.FixedSingle;
            centerPanel.Controls.Add(dice2PictureBox);

            // Nút tung xúc xắc
            rollDiceButton = new Button();
            rollDiceButton.Text = "ROLL DICE";
            rollDiceButton.Font = new Font("Arial", 10, FontStyle.Bold);
            rollDiceButton.Size = new Size(120, 30);
            rollDiceButton.Location = new Point(90, 110);
            rollDiceButton.BackColor = Color.LightBlue;
            rollDiceButton.FlatStyle = FlatStyle.Flat;
            rollDiceButton.Click += RollDiceButton_Click;
            centerPanel.Controls.Add(rollDiceButton);

            // Panel thông tin người chơi bên trái
            Panel playersPanel = new Panel();
            playersPanel.Size = new Size(150, 300);
            playersPanel.Location = new Point(600, 200);
            playersPanel.BackColor = Color.White;
            playersPanel.BorderStyle = BorderStyle.FixedSingle;
            boardPanel.Controls.Add(playersPanel);

            // Tạo list thông tin người chơi
            playerLabels = new Label[5]; // Index 0 không dùng
            Color[] playerColors = { Color.White, Color.Red, Color.Green, Color.Blue, Color.Orange };

            Label titleLabel = new Label();
            titleLabel.Text = "PLAYERS";
            titleLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            titleLabel.Size = new Size(140, 25);
            titleLabel.Location = new Point(5, 10);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.ForeColor = Color.Black;
            playersPanel.Controls.Add(titleLabel);

            for (int i = 1; i <= 4; i++)
            {
                // Vòng tròn nhỏ đại diện cho người chơi
                Panel playerCircle = new Panel();
                playerCircle.Size = new Size(20, 20);
                playerCircle.BackColor = playerColors[i];
                playerCircle.BorderStyle = BorderStyle.FixedSingle;
                playerCircle.Location = new Point(10, 40 + (i - 1) * 35);
                playersPanel.Controls.Add(playerCircle);

                // Label hiển thị số tiền
                playerLabels[i] = new Label();
                playerLabels[i].Font = new Font("Arial", 10, FontStyle.Bold);
                playerLabels[i].TextAlign = ContentAlignment.MiddleLeft;
                playerLabels[i].ForeColor = Color.Black;
                playerLabels[i].Size = new Size(110, 20);
                playerLabels[i].Location = new Point(35, 40 + (i - 1) * 35);
                playersPanel.Controls.Add(playerLabels[i]);
            }

            // Panel câu hỏi mua nhà đất
            CreateQuestionPanel();

            DrawInitialDice();
        }

        private void CreateQuestionPanel()
        {
            questionPanel = new Panel();
            questionPanel.Size = new Size(250, 80);
            questionPanel.Location = new Point(200, 400);
            questionPanel.BackColor = Color.LightGray;
            questionPanel.BorderStyle = BorderStyle.FixedSingle;
            questionPanel.Visible = false;
            boardPanel.Controls.Add(questionPanel);

            Label questionLabel = new Label();
            questionLabel.Text = "Buy this property?";
            questionLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            questionLabel.Size = new Size(230, 25);
            questionLabel.Location = new Point(10, 10);
            questionLabel.TextAlign = ContentAlignment.MiddleCenter;
            questionPanel.Controls.Add(questionLabel);

            Button noButton = new Button();
            noButton.Text = "No";
            noButton.Size = new Size(60, 25);
            noButton.Location = new Point(50, 45);
            noButton.BackColor = Color.Red;
            noButton.ForeColor = Color.White;
            noButton.FlatStyle = FlatStyle.Flat;
            noButton.Click += (s, e) => { questionPanel.Visible = false; };
            questionPanel.Controls.Add(noButton);

            Button yesButton = new Button();
            yesButton.Text = "Yes";
            yesButton.Size = new Size(60, 25);
            yesButton.Location = new Point(140, 45);
            yesButton.BackColor = Color.Green;
            yesButton.ForeColor = Color.White;
            yesButton.FlatStyle = FlatStyle.Flat;
            yesButton.Click += (s, e) => {
                BuyProperty();
                questionPanel.Visible = false;
            };
            questionPanel.Controls.Add(yesButton);
        }

        private void CreatePlayerPieces()
        {
            playerPieces = new PictureBox[5]; // Index 0 không dùng
            Color[] pieceColors = { Color.White, Color.Red, Color.Green, Color.Blue, Color.Orange };

            for (int i = 1; i <= 4; i++)
            {
                playerPieces[i] = new PictureBox();
                playerPieces[i].Size = new Size(10, 10);
                playerPieces[i].BackColor = pieceColors[i];
                playerPieces[i].BorderStyle = BorderStyle.FixedSingle;
                UpdatePlayerPosition(i, 0);
                boardPanel.Controls.Add(playerPieces[i]);
            }
        }

        private void UpdatePlayerPosition(int playerNumber, int position)
        {
            Point squarePosition = CalculateSquarePosition(position);
            int offsetX = ((playerNumber - 1) % 2) * 12;
            int offsetY = ((playerNumber - 1) / 2) * 12;

            playerPieces[playerNumber].Location = new Point(
                squarePosition.X + 5 + offsetX,
                squarePosition.Y + 5 + offsetY
            );
            playerPosition[playerNumber] = position;
        }

        private void DrawInitialDice()
        {
            DrawDice(dice1PictureBox, 1);
            DrawDice(dice2PictureBox, 1);
        }

        private void DrawDice(PictureBox diceBox, int value)
        {
            Bitmap diceBitmap = new Bitmap(40, 40);
            Graphics g = Graphics.FromImage(diceBitmap);

            g.FillRectangle(Brushes.White, 0, 0, 40, 40);
            g.DrawRectangle(Pens.Black, 0, 0, 39, 39);

            Brush dotBrush = Brushes.Black;
            int dotSize = 4;

            switch (value)
            {
                case 1:
                    g.FillEllipse(dotBrush, 18, 18, dotSize, dotSize);
                    break;
                case 2:
                    g.FillEllipse(dotBrush, 10, 10, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 26, 26, dotSize, dotSize);
                    break;
                case 3:
                    g.FillEllipse(dotBrush, 10, 10, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 18, 18, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 26, 26, dotSize, dotSize);
                    break;
                case 4:
                    g.FillEllipse(dotBrush, 10, 10, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 26, 10, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 10, 26, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 26, 26, dotSize, dotSize);
                    break;
                case 5:
                    g.FillEllipse(dotBrush, 10, 10, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 26, 10, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 18, 18, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 10, 26, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 26, 26, dotSize, dotSize);
                    break;
                case 6:
                    g.FillEllipse(dotBrush, 10, 8, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 26, 8, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 10, 18, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 26, 18, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 10, 28, dotSize, dotSize);
                    g.FillEllipse(dotBrush, 26, 28, dotSize, dotSize);
                    break;
            }

            diceBox.Image = diceBitmap;
        }

        private void RollDiceButton_Click(object sender, EventArgs e)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);

            DrawDice(dice1PictureBox, dice1);
            DrawDice(dice2PictureBox, dice2);

            int totalMove = dice1 + dice2;

            // Di chuyển người chơi
            int oldPosition = playerPosition[currentPlayer];
            playerPosition[currentPlayer] = (playerPosition[currentPlayer] + totalMove) % 40;
            UpdatePlayerPosition(currentPlayer, playerPosition[currentPlayer]);

            // Kiểm tra qua ô xuất phát
            if (oldPosition + totalMove >= 40)
            {
                playerMoney[currentPlayer] += 2000;
                MessageBox.Show($"Player {currentPlayer} passed START! +$2000", "Notice");
            }

            // Kiểm tra có thể mua nhà đất
            int currentPos = playerPosition[currentPlayer];
            if (propertyPrices[currentPos] > 0)
            {
                ShowBuyPropertyQuestion(currentPos);
            }

            // Chuyển lượt
            currentPlayer = currentPlayer == 4 ? 1 : currentPlayer + 1;
            UpdateUI();
        }

        private void ShowBuyPropertyQuestion(int position)
        {
            Label questionLabel = (Label)questionPanel.Controls[0];
            questionLabel.Text = $"Buy for ${propertyPrices[position]}?";
            questionPanel.Visible = true;
        }

        private void BuyProperty()
        {
            int position = playerPosition[currentPlayer];
            int price = propertyPrices[position];

            if (playerMoney[currentPlayer] >= price)
            {
                playerMoney[currentPlayer] -= price;
                MessageBox.Show($"Bought for ${price}!", "Purchase");
            }
            else
            {
                MessageBox.Show("Not enough money!", "Error");
            }
        }

        private void UpdateUI()
        {
            for (int i = 1; i <= 4; i++)
            {
                playerLabels[i].Text = $"P{i}: ${playerMoney[i]}";

                // Highlight người chơi hiện tại
                if (i == currentPlayer)
                {
                    playerLabels[i].Font = new Font("Arial", 10, FontStyle.Bold);
                    playerLabels[i].ForeColor = Color.Red;
                }
                else
                {
                    playerLabels[i].Font = new Font("Arial", 9, FontStyle.Regular);
                    playerLabels[i].ForeColor = Color.Black;
                }
            }
        }
    }
}