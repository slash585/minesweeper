namespace Minesweeper_v2
{
    partial class Board
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flagLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // flagLabel
            // 
            flagLabel.AutoSize = true;
            flagLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            flagLabel.Location = new System.Drawing.Point(0, 415);
            flagLabel.Margin = new System.Windows.Forms.Padding(3, 0, 10, 10);
            flagLabel.Name = "flagLabel";
            flagLabel.Padding = new System.Windows.Forms.Padding(10);
            flagLabel.Size = new System.Drawing.Size(65, 35);
            flagLabel.TabIndex = 0;
            flagLabel.Text = "Bayrak:";
            // 
            // Board
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(flagLabel);
            Name = "Board";
            Text = "Board";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label flagLabel;
    }
}