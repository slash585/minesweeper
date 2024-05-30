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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(widthTextBox.Text, out int width) && int.TryParse(heightTextBox.Text, out int height) && int.TryParse(mineCountTextBox.Text, out int mineCount)) 
            {
                if (mineCount > width * height)
                {
                    ShowMessage("Mayın sayısı oyun alanından büyük olamaz");
                }
                else if (mineCount == 0 || width == 0 || height == 0)
                {
                    ShowMessage("Girilen değerler 0 dan büyük olmalıdır");
                }
                else
                {
                    Board board = new Board(width, height, mineCount);
                    board.Show();
                    Hide();
                }
            }
            else
            {
                ShowMessage("Lütfen sayısal değerler giriniz !");
            }
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
