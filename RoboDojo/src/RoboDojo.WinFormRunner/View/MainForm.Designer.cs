using System.Windows.Forms;

namespace RoboDojo.WinFormRunner.View
{
    partial class MainForm
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
            this._btnStartBattle = new System.Windows.Forms.Button();
            this._btnEndBattle = new System.Windows.Forms.Button();
            this._btnLoadRobot = new System.Windows.Forms.Button();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._battleGrid = new RoboDojo.WinFormRunner.View.BattleGrid();
            this._battleField = new RoboDojo.WinFormRunner.View.BattleField();
            this.SuspendLayout();
            // 
            // _btnStartBattle
            // 
            this._btnStartBattle.Location = new System.Drawing.Point(12, 12);
            this._btnStartBattle.Name = "_btnStartBattle";
            this._btnStartBattle.Size = new System.Drawing.Size(75, 23);
            this._btnStartBattle.TabIndex = 3;
            this._btnStartBattle.Text = "Start Battle";
            this._btnStartBattle.UseVisualStyleBackColor = true;
            this._btnStartBattle.Click += new System.EventHandler(this._btnStartBattle_Click);
            // 
            // _btnEndBattle
            // 
            this._btnEndBattle.Location = new System.Drawing.Point(94, 11);
            this._btnEndBattle.Name = "_btnEndBattle";
            this._btnEndBattle.Size = new System.Drawing.Size(75, 23);
            this._btnEndBattle.TabIndex = 4;
            this._btnEndBattle.Text = "Stop Battle";
            this._btnEndBattle.UseVisualStyleBackColor = true;
            this._btnEndBattle.Click += new System.EventHandler(this._btnEndBattle_Click);
            // 
            // _btnLoadRobot
            // 
            this._btnLoadRobot.Location = new System.Drawing.Point(696, 11);
            this._btnLoadRobot.Name = "_btnLoadRobot";
            this._btnLoadRobot.Size = new System.Drawing.Size(75, 23);
            this._btnLoadRobot.TabIndex = 6;
            this._btnLoadRobot.Text = "Load Robot";
            this._btnLoadRobot.UseVisualStyleBackColor = true;
            this._btnLoadRobot.Click += new System.EventHandler(this._btnLoadRobot_Click);
            // 
            // _battleGrid
            // 
            this._battleGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._battleGrid.AutoSize = true;
            this._battleGrid.Location = new System.Drawing.Point(-1, 394);
            this._battleGrid.Name = "_battleGrid";
            this._battleGrid.RobotBindingList = null;
            this._battleGrid.Size = new System.Drawing.Size(790, 174);
            this._battleGrid.TabIndex = 5;
            // 
            // _battleField
            // 
            this._battleField.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._battleField.BackColor = System.Drawing.Color.White;
            this._battleField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._battleField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._battleField.Location = new System.Drawing.Point(12, 41);
            this._battleField.Name = "_battleField";
            this._battleField.Size = new System.Drawing.Size(759, 347);
            this._battleField.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this._btnLoadRobot);
            this.Controls.Add(this._battleGrid);
            this.Controls.Add(this._btnEndBattle);
            this.Controls.Add(this._btnStartBattle);
            this.Controls.Add(this._battleField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "RoboDojo Battlefield";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BattleField _battleField;
        private Button _btnStartBattle;
        private Button _btnEndBattle;
        private BattleGrid _battleGrid;
        private Button _btnLoadRobot;
        private OpenFileDialog _openFileDialog;
        
        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(this, message);
        }
    }
}