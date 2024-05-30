using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_v2
{
    public partial class TileButton : Button
    {
        public bool IsSelected { get; set; }
        public bool HasMine { get; set; }
        public bool HasFlag { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        private readonly ITileButtonDelegate _tileButtonDelegate;
        private Color DisabledTextColor { get; set; }

        public TileButton(ITileButtonDelegate tileButtonDelegate,int row, int column, int size, bool isSelected = false, bool hasMine = false, bool hasFlag = false)
        {
            _tileButtonDelegate = tileButtonDelegate;
            IsSelected = isSelected;
            HasMine = hasMine; 
            HasFlag = hasFlag;
            Location = new Point(row * size, column * size);
            Width = size;
            Height = size;
            Font = new Font("Segoe UI Emoji", 14);
            BackColor = Color.White;
            Row = row;
            Column = column;

            MouseUp += HandleOnMouseUp;
        }

        private Color GetColor(int code)
        {
            switch (code)
            {
                case (int)ColorCode.One:
                    return Color.Red;
                case (int)ColorCode.Two:
                    return Color.Orange;
                case (int)ColorCode.Three:
                    return Color.Yellow;
                case (int)ColorCode.Four:
                    return Color.Green;
                case (int)ColorCode.Five:
                    return Color.Blue;
                case (int)ColorCode.Six:
                    return Color.Indigo;
                case (int)ColorCode.Seven:
                    return Color.Violet;
                case (int)ColorCode.Eight:
                    return Color.Black;
                default:
                    throw new ArgumentOutOfRangeException(nameof(code), code, "Invalid color code");
            }
        }

        private void HandleOnMouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                HandleClickLeft();
            } 
            else if(e.Button == MouseButtons.Right)
            {
                HandleClickRight();
            }
        }

        private void HandleClickLeft()
        {
            if (IsSelected)
                return;

            IsSelected = true;

            if (!HasFlag)
            {
                if (HasMine)
                {
                    _tileButtonDelegate.OpenMine();
                }
                else
                {
                    _tileButtonDelegate.OpenTile(Row, Column);
                }
            }
        }

        private void HandleClickRight()
        {
            if (IsSelected)
                return;

            _tileButtonDelegate.AddFlag(Row, Column);
        }

        public void SetButtonLabelText(int mineCount)
        {
            DisabledTextColor = GetColor(mineCount);
            Text = mineCount.ToString();
        }

        public void SetFlag()
        {
            if (IsSelected)
                return;

            if (!HasFlag) {
                HasFlag = true;
                ChangeBackgroundColor(Color.Green);
            }
            else
            {
                HasFlag = false;
                ChangeBackgroundColor(Color.White);
            }
        }

        public void ChangeBackgroundColor(Color color)
        {
            BackColor = color;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (!this.Enabled)
            {
                TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, DisabledTextColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
