namespace Minesweeper_v2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new System.Windows.Forms.GroupBox();
            startButton = new System.Windows.Forms.Button();
            mineCountTextBox = new System.Windows.Forms.TextBox();
            heightTextBox = new System.Windows.Forms.TextBox();
            widthTextBox = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(startButton);
            groupBox1.Controls.Add(mineCountTextBox);
            groupBox1.Controls.Add(heightTextBox);
            groupBox1.Controls.Add(widthTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(303, 311);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Oyun Ayarları";
            // 
            // startButton
            // 
            startButton.Location = new System.Drawing.Point(4, 184);
            startButton.Name = "startButton";
            startButton.Size = new System.Drawing.Size(293, 23);
            startButton.TabIndex = 6;
            startButton.Text = "Başla";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // mineCountTextBox
            // 
            mineCountTextBox.Location = new System.Drawing.Point(98, 114);
            mineCountTextBox.Name = "mineCountTextBox";
            mineCountTextBox.Size = new System.Drawing.Size(91, 23);
            mineCountTextBox.TabIndex = 5;
            mineCountTextBox.Tag = "mineCountTextBox";
            // 
            // heightTextBox
            // 
            heightTextBox.Location = new System.Drawing.Point(98, 85);
            heightTextBox.Name = "heightTextBox";
            heightTextBox.Size = new System.Drawing.Size(91, 23);
            heightTextBox.TabIndex = 4;
            // 
            // widthTextBox
            // 
            widthTextBox.Location = new System.Drawing.Point(98, 53);
            widthTextBox.Name = "widthTextBox";
            widthTextBox.Size = new System.Drawing.Size(91, 23);
            widthTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 122);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(75, 15);
            label3.TabIndex = 2;
            label3.Text = "Mayın Sayısı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 93);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "Yükseklik:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 61);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Genişlik:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(328, 340);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox mineCountTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Button startButton;
    }
}
