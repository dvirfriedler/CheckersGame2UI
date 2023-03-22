namespace CheckersWinFormUI
{
    partial class FinishGameForm
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
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Image = global::CheckersWinFormUI.Properties.Resources.newGameButton2;
            this.buttonNewGame.Location = new System.Drawing.Point(124, 341);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(364, 86);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.UseVisualStyleBackColor = true;
            // 
            // FinishGameFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CheckersWinFormUI.Properties.Resources.GameOverPhoto;
            this.ClientSize = new System.Drawing.Size(631, 465);
            this.Controls.Add(this.buttonNewGame);
            this.Name = "FinishGameFormcs";
            this.Text = "FinishGameFormcs";
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonNewGame;
    }
}