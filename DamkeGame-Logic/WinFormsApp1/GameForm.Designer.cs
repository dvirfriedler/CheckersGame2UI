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
            this.BoardPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // BoardPanel
            // 
            this.BoardPanel.ColumnCount = 2;
            this.BoardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BoardPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BoardPanel.Location = new System.Drawing.Point(205, 204);
            this.BoardPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.RowCount = 2;
            this.BoardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BoardPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BoardPanel.Size = new System.Drawing.Size(700, 700);
            this.BoardPanel.TabIndex = 0;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 929);
            this.Controls.Add(this.BoardPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.AutoSizeChanged += new System.EventHandler(this.GameForm_AutoSizeChanged);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Resize += new System.EventHandler(this.GameForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel BoardPanel;
    }
}