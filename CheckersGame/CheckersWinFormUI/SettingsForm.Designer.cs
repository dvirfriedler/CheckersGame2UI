﻿namespace CheckersWinFormUI
{
    partial class SettingsForm
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
            this.StartGameButton = new System.Windows.Forms.Button();
            this.TowPlayersCheckBox = new System.Windows.Forms.CheckBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.SecondNameTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.BoradSizeGroupBox = new System.Windows.Forms.GroupBox();
            this.Size10CheckBox = new System.Windows.Forms.CheckBox();
            this.Size8CheckBox = new System.Windows.Forms.CheckBox();
            this.Size6CheckBox = new System.Windows.Forms.CheckBox();
            this.BoradSizeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartGameButton
            // 
            this.StartGameButton.Enabled = false;
            this.StartGameButton.Location = new System.Drawing.Point(31, 518);
            this.StartGameButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(361, 104);
            this.StartGameButton.TabIndex = 0;
            this.StartGameButton.Text = "Start";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // TowPlayersCheckBox
            // 
            this.TowPlayersCheckBox.AutoSize = true;
            this.TowPlayersCheckBox.Location = new System.Drawing.Point(31, 109);
            this.TowPlayersCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TowPlayersCheckBox.Name = "TowPlayersCheckBox";
            this.TowPlayersCheckBox.Size = new System.Drawing.Size(169, 36);
            this.TowPlayersCheckBox.TabIndex = 1;
            this.TowPlayersCheckBox.Text = "Tow Players";
            this.TowPlayersCheckBox.UseVisualStyleBackColor = true;
            this.TowPlayersCheckBox.CheckedChanged += new System.EventHandler(this.TowPlayersCheckBox_CheckedChanged);
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(31, 182);
            this.FirstNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(370, 39);
            this.FirstNameTextBox.TabIndex = 2;
            this.FirstNameTextBox.Text = "First player name";
            this.FirstNameTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SecondNameTextBox
            // 
            this.SecondNameTextBox.Enabled = false;
            this.SecondNameTextBox.Location = new System.Drawing.Point(31, 268);
            this.SecondNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SecondNameTextBox.Name = "SecondNameTextBox";
            this.SecondNameTextBox.Size = new System.Drawing.Size(370, 39);
            this.SecondNameTextBox.TabIndex = 3;
            this.SecondNameTextBox.Text = "Second player name";
            this.SecondNameTextBox.TextChanged += new System.EventHandler(this.SecondNameTextBox_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Location = new System.Drawing.Point(0, 44);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1154, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip2.Size = new System.Drawing.Size(1154, 44);
            this.menuStrip2.TabIndex = 5;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // BoradSizeGroupBox
            // 
            this.BoradSizeGroupBox.Controls.Add(this.Size10CheckBox);
            this.BoradSizeGroupBox.Controls.Add(this.Size8CheckBox);
            this.BoradSizeGroupBox.Controls.Add(this.Size6CheckBox);
            this.BoradSizeGroupBox.Location = new System.Drawing.Point(542, 137);
            this.BoradSizeGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BoradSizeGroupBox.Name = "BoradSizeGroupBox";
            this.BoradSizeGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BoradSizeGroupBox.Size = new System.Drawing.Size(323, 191);
            this.BoradSizeGroupBox.TabIndex = 6;
            this.BoradSizeGroupBox.TabStop = false;
            this.BoradSizeGroupBox.Text = "Borad Size";
            this.BoradSizeGroupBox.Enter += new System.EventHandler(this.BoradSizeGroupBox_Enter);
            // 
            // Size10CheckBox
            // 
            this.Size10CheckBox.AutoSize = true;
            this.Size10CheckBox.Location = new System.Drawing.Point(3, 131);
            this.Size10CheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Size10CheckBox.Name = "Size10CheckBox";
            this.Size10CheckBox.Size = new System.Drawing.Size(72, 36);
            this.Size10CheckBox.TabIndex = 8;
            this.Size10CheckBox.Text = "10";
            this.Size10CheckBox.UseVisualStyleBackColor = true;
            this.Size10CheckBox.CheckedChanged += new System.EventHandler(this.Size10CheckBox_CheckedChanged);
            // 
            // Size8CheckBox
            // 
            this.Size8CheckBox.AutoSize = true;
            this.Size8CheckBox.Location = new System.Drawing.Point(3, 79);
            this.Size8CheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Size8CheckBox.Name = "Size8CheckBox";
            this.Size8CheckBox.Size = new System.Drawing.Size(59, 36);
            this.Size8CheckBox.TabIndex = 7;
            this.Size8CheckBox.Text = "8";
            this.Size8CheckBox.UseVisualStyleBackColor = true;
            this.Size8CheckBox.CheckedChanged += new System.EventHandler(this.Size8CheckBox_CheckedChanged);
            // 
            // Size6CheckBox
            // 
            this.Size6CheckBox.AutoSize = true;
            this.Size6CheckBox.Location = new System.Drawing.Point(3, 35);
            this.Size6CheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Size6CheckBox.Name = "Size6CheckBox";
            this.Size6CheckBox.Size = new System.Drawing.Size(59, 36);
            this.Size6CheckBox.TabIndex = 0;
            this.Size6CheckBox.Text = "6";
            this.Size6CheckBox.UseVisualStyleBackColor = true;
            this.Size6CheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 824);
            this.Controls.Add(this.BoradSizeGroupBox);
            this.Controls.Add(this.SecondNameTextBox);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.TowPlayersCheckBox);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.BoradSizeGroupBox.ResumeLayout(false);
            this.BoradSizeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.CheckBox TowPlayersCheckBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox SecondNameTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        protected internal System.Windows.Forms.GroupBox BoradSizeGroupBox;
        private System.Windows.Forms.CheckBox Size10CheckBox;
        private System.Windows.Forms.CheckBox Size8CheckBox;
        private System.Windows.Forms.CheckBox Size6CheckBox;
    }
}

