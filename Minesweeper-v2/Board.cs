using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_v2
{
    public partial class Board : Form, ITileButtonDelegate
    {
        private int BoardWidth { get; set; }
        private int BoardHeight { get; set; }
        private int MineCount { get; set; }

        private const int ButtonSize = 40;

        private TileButton[,] TileButtons;

        private Panel BoardPanel = new();

        private int FlagCount;

        private int TileCount;

        public Board(int width, int height, int mineCount)
        {
            InitializeComponent();
            BoardWidth = width;
            BoardHeight = height;
            MineCount = mineCount;
            Width = width * ButtonSize + 50;
            Height = height * ButtonSize + 212;

            TileButtons = new TileButton[BoardWidth, BoardHeight];

            TileCount = (BoardWidth * BoardHeight) - mineCount;

            InitializeBoard();
        }

        private void InitializeBoard()
        {
            FlagCount = MineCount - 1;
            SetFlagLabel(MineCount - 1);
            Controls.Add(MakePanel());
            CreateButtons();
        }

        private Panel MakePanel()
        {
            BoardPanel.BorderStyle = BorderStyle.FixedSingle;
            BoardPanel.Width = ClientSize.Width - 32;
            BoardPanel.Height = ClientSize.Height - 170;
            BoardPanel.Left = (ClientSize.Width - BoardPanel.Width) / 2;
            BoardPanel.Top = (ClientSize.Height - BoardPanel.Height) / 20;
            return BoardPanel;
        }

        private void CreateButtons()
        {
            for (int i = 0; i < BoardWidth; i++)
            {
                for (int j = 0; j < BoardHeight; j++)
                {
                    var button = new TileButton(this, i, j, ButtonSize);
                    TileButtons[i, j] = button;
                    BoardPanel.Controls.Add(button);
                }
            }

            CreateRandomMines();
        }

        private void CreateRandomMines()
        {
            int counter = 0;
            Random random = new();

            while (counter < MineCount)
            {
                int i = random.Next(0, BoardWidth - 1);
                int j = random.Next(0, BoardHeight - 1);

                var button = TileButtons[i, j];
                if (!button.HasMine)
                {
                    button.HasMine = true;
                    counter++;
                }
            }
        }

        public void AddFlag(int row, int column)
        {
            var button = TileButtons[row, column];

            if (!button.HasFlag)
            {
                if (FlagCount >= 1)
                {
                    FlagCount--;
                    button.SetFlag();
                }
            }
            else
            {
                FlagCount++;
                button.SetFlag();
            }
            SetFlagLabel(FlagCount);
        }

        public void OpenMine()
        {
            GameOver("Kaybettiniz");
        }

        private void GameOver(string message)
        {
            DialogResult result = MessageBox.Show($"{message}\n" + "Tekrar oynamak ister misiniz ?", "Oyun Bitti", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Controls.Remove(BoardPanel);

                foreach (var button in TileButtons)
                {
                    BoardPanel.Controls.Remove(button);
                }

                InitializeBoard();
            }
            else
            {
                Application.Exit();
            }
        }

        public void OpenTile(int row, int column)
        {
            FloodFill(row, column);
            HasPlayerWon();
        }

        private void HasPlayerWon()
        {
            int counter = 0;
            foreach (var button in TileButtons)
            {
                if (button.IsSelected)
                    counter++;
            }

            if (counter == TileCount)
            {
                GameOver("Tebrikler ! Oyunu kazandınız");
            }
        }

        private int CountNearbyMines(int row, int col)
        {
            int count = 0;
            for (int i = Math.Max(0, row - 1); i <= Math.Min(row + 1, BoardWidth - 1); i++)
            {
                for (int j = Math.Max(0, col - 1); j <= Math.Min(col + 1, BoardHeight - 1); j++)
                {
                    if (TileButtons[i, j].HasMine)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private void FloodFill(int x, int y)
        {
            // Eğer koordinatlar tahtanın dışında ise işlemi sonlandır.
            if (x < 0 || x >= BoardWidth || y < 0 || y >= BoardHeight)
            {
                return;
            }

            var button = TileButtons[x, y]; 

            button.IsSelected = true; // Butonun seçildiğini işaretle.
            button.Enabled = false;
            int mineCount = CountNearbyMines(x, y); // Butonun etrafındaki mayın sayısını hesapla.

            button.ChangeBackgroundColor(Color.LightGray);

            if (mineCount == 0) // Eğer tuğlanın etrafında mayın yoksa
            {
                Queue<(int, int)> queue = new Queue<(int, int)>(); // Kuyruk oluştur.
                queue.Enqueue((x, y)); // Bulunduğumuz koordinatları kuyruğa ekle.

                // Kuyruk boşalana kadar devam et.
                while (queue.Count > 0)
                {
                    // Kuyruktan bir sonraki koordinatı al.
                    var (currentX, currentY) = queue.Dequeue();

                    // Sekiz yönde (etrafındaki) gez.
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            int newX = currentX + dx; // Yeni x koordinatını hesapla.
                            int newY = currentY + dy; // Yeni y koordinatını hesapla.

                            // Yeni koordinatlar tahta içindeyse devam et.
                            if (newX >= 0 && newX < BoardWidth && newY >= 0 && newY < BoardHeight)
                            {
                                var neighborButton = TileButtons[newX, newY]; // Yeni tuğlayı al.

                                // Eğer tuğla daha önce seçilmediyse
                                if (!neighborButton.IsSelected)
                                {
                                    neighborButton.IsSelected = true; // Tuğlayı seçildi olarak işaretle.

                                    int neighborMineCount = CountNearbyMines(newX, newY); // Yeni tuğlanın etrafındaki mayın sayısını hesapla.

                                    if (neighborMineCount != 0) 
                                    {
                                        neighborButton.SetButtonLabelText(neighborMineCount);
                                    }
                                    
                                    neighborButton.ChangeBackgroundColor(Color.LightGray);

                                    neighborButton.Enabled = false;

                                    if (neighborMineCount == 0) // Eğer yeni tuğlanın etrafında mayın yoksa
                                    {
                                        queue.Enqueue((newX, newY)); // Yeni tuğlayı kuyruğa ekle.
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                button.SetButtonLabelText(mineCount);
            }
        }
        
        private void SetFlagLabel(int flagCount)
        {
            flagLabel.Text = "Bayrak:" + flagCount.ToString();
        }
    }
}
