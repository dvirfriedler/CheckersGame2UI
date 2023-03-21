namespace DmakaWinFormUITest
{
    partial class GameForm
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
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.ScorePlayer1Label = new System.Windows.Forms.Label();
            this.ScorePlayer2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BoardPanel
            // 
            this.BoardPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BoardPanel.Location = new System.Drawing.Point(0, 91);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(900, 900);
            this.BoardPanel.TabIndex = 0;
            this.BoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BoardPanel_Paint);
            // 
            // ScorePlayer1Label
            // 
            this.ScorePlayer1Label.AutoSize = true;
            this.ScorePlayer1Label.Location = new System.Drawing.Point(12, 28);
            this.ScorePlayer1Label.Name = "ScorePlayer1Label";
            this.ScorePlayer1Label.Size = new System.Drawing.Size(206, 32);
            this.ScorePlayer1Label.TabIndex = 1;
            this.ScorePlayer1Label.Text = "ScorePlayer1Label";
            // 
            // ScorePlayer2Label
            // 
            this.ScorePlayer2Label.AutoSize = true;
            this.ScorePlayer2Label.Location = new System.Drawing.Point(264, 28);
            this.ScorePlayer2Label.Name = "ScorePlayer2Label";
            this.ScorePlayer2Label.Size = new System.Drawing.Size(206, 32);
            this.ScorePlayer2Label.TabIndex = 2;
            this.ScorePlayer2Label.Text = "ScorePlayer2Label";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 995);
            this.Controls.Add(this.ScorePlayer2Label);
            this.Controls.Add(this.ScorePlayer1Label);
            this.Controls.Add(this.BoardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel BoardPanel;
        private Label ScorePlayer1Label;
        private Label ScorePlayer2Label;
    }
}