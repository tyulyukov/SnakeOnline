
namespace SnakeOnline
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.panelAppMenu = new System.Windows.Forms.Panel();
            this.buttonMinimizeApp = new System.Windows.Forms.PictureBox();
            this.buttonMaximizeApp = new System.Windows.Forms.PictureBox();
            this.buttonCloseApp = new System.Windows.Forms.PictureBox();
            this.panelGame = new System.Windows.Forms.Panel();
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.labelScore = new System.Windows.Forms.Label();
            this.panelPause = new System.Windows.Forms.Panel();
            this.buttonRetry = new System.Windows.Forms.PictureBox();
            this.buttonLeave = new System.Windows.Forms.PictureBox();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.PictureBox();
            this.panelDefeat = new System.Windows.Forms.Panel();
            this.buttonRetry2 = new System.Windows.Forms.PictureBox();
            this.buttonLeave2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAppMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimizeApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximizeApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCloseApp)).BeginInit();
            this.panelPause.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRetry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPause)).BeginInit();
            this.panelDefeat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRetry2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAppMenu
            // 
            this.panelAppMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(116)))), ((int)(((byte)(173)))));
            this.panelAppMenu.Controls.Add(this.buttonMinimizeApp);
            this.panelAppMenu.Controls.Add(this.buttonMaximizeApp);
            this.panelAppMenu.Controls.Add(this.buttonCloseApp);
            this.panelAppMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAppMenu.ForeColor = System.Drawing.SystemColors.Control;
            this.panelAppMenu.Location = new System.Drawing.Point(0, 0);
            this.panelAppMenu.Margin = new System.Windows.Forms.Padding(5);
            this.panelAppMenu.Name = "panelAppMenu";
            this.panelAppMenu.Size = new System.Drawing.Size(1067, 28);
            this.panelAppMenu.TabIndex = 5;
            this.panelAppMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelAppMenu_MouseDown);
            this.panelAppMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelAppMenu_MouseMove);
            this.panelAppMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelAppMenu_MouseUp);
            // 
            // buttonMinimizeApp
            // 
            this.buttonMinimizeApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimizeApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimizeApp.Image = ((System.Drawing.Image)(resources.GetObject("buttonMinimizeApp.Image")));
            this.buttonMinimizeApp.Location = new System.Drawing.Point(956, -2);
            this.buttonMinimizeApp.Margin = new System.Windows.Forms.Padding(5);
            this.buttonMinimizeApp.Name = "buttonMinimizeApp";
            this.buttonMinimizeApp.Size = new System.Drawing.Size(28, 28);
            this.buttonMinimizeApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonMinimizeApp.TabIndex = 3;
            this.buttonMinimizeApp.TabStop = false;
            this.buttonMinimizeApp.Click += new System.EventHandler(this.buttonMinimizeApp_Click);
            this.buttonMinimizeApp.MouseEnter += new System.EventHandler(this.buttonMinOrMax_MouseEnter);
            this.buttonMinimizeApp.MouseLeave += new System.EventHandler(this.buttonMinOrMax_MouseLeave);
            // 
            // buttonMaximizeApp
            // 
            this.buttonMaximizeApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMaximizeApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMaximizeApp.Enabled = false;
            this.buttonMaximizeApp.Image = ((System.Drawing.Image)(resources.GetObject("buttonMaximizeApp.Image")));
            this.buttonMaximizeApp.Location = new System.Drawing.Point(993, -2);
            this.buttonMaximizeApp.Margin = new System.Windows.Forms.Padding(5);
            this.buttonMaximizeApp.Name = "buttonMaximizeApp";
            this.buttonMaximizeApp.Size = new System.Drawing.Size(28, 28);
            this.buttonMaximizeApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonMaximizeApp.TabIndex = 2;
            this.buttonMaximizeApp.TabStop = false;
            this.buttonMaximizeApp.Click += new System.EventHandler(this.buttonMaximizeApp_Click);
            // 
            // buttonCloseApp
            // 
            this.buttonCloseApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCloseApp.Image = ((System.Drawing.Image)(resources.GetObject("buttonCloseApp.Image")));
            this.buttonCloseApp.Location = new System.Drawing.Point(1032, -2);
            this.buttonCloseApp.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCloseApp.Name = "buttonCloseApp";
            this.buttonCloseApp.Size = new System.Drawing.Size(28, 28);
            this.buttonCloseApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonCloseApp.TabIndex = 1;
            this.buttonCloseApp.TabStop = false;
            this.buttonCloseApp.Click += new System.EventHandler(this.buttonCloseApp_Click);
            this.buttonCloseApp.MouseEnter += new System.EventHandler(this.buttonCloseApp_MouseEnter);
            this.buttonCloseApp.MouseLeave += new System.EventHandler(this.buttonCloseApp_MouseLeave);
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(193)))), ((int)(((byte)(230)))));
            this.panelGame.Location = new System.Drawing.Point(218, 28);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(630, 630);
            this.panelGame.TabIndex = 7;
            this.panelGame.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            // 
            // timerGame
            // 
            this.timerGame.Interval = 225;
            this.timerGame.Tick += new System.EventHandler(this.timerGame_Tick);
            // 
            // labelScore
            // 
            this.labelScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(65)))), ((int)(((byte)(97)))));
            this.labelScore.Font = new System.Drawing.Font("Quicksand", 30F, System.Drawing.FontStyle.Bold);
            this.labelScore.ForeColor = System.Drawing.Color.White;
            this.labelScore.Location = new System.Drawing.Point(848, 30);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(219, 126);
            this.labelScore.TabIndex = 8;
            this.labelScore.Text = "Score: 0";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelPause
            // 
            this.panelPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.panelPause.Controls.Add(this.buttonRetry);
            this.panelPause.Controls.Add(this.buttonLeave);
            this.panelPause.Controls.Add(this.buttonContinue);
            this.panelPause.Controls.Add(this.label1);
            this.panelPause.Location = new System.Drawing.Point(300, 230);
            this.panelPause.Name = "panelPause";
            this.panelPause.Size = new System.Drawing.Size(454, 208);
            this.panelPause.TabIndex = 9;
            this.panelPause.Visible = false;
            // 
            // buttonRetry
            // 
            this.buttonRetry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRetry.Image = global::SnakeOnline.Properties.Resources.retry;
            this.buttonRetry.Location = new System.Drawing.Point(329, 147);
            this.buttonRetry.Name = "buttonRetry";
            this.buttonRetry.Size = new System.Drawing.Size(45, 45);
            this.buttonRetry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonRetry.TabIndex = 12;
            this.buttonRetry.TabStop = false;
            this.buttonRetry.Click += new System.EventHandler(this.buttonRetry_Click);
            // 
            // buttonLeave
            // 
            this.buttonLeave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLeave.Image = global::SnakeOnline.Properties.Resources.exit;
            this.buttonLeave.Location = new System.Drawing.Point(73, 147);
            this.buttonLeave.Name = "buttonLeave";
            this.buttonLeave.Size = new System.Drawing.Size(45, 45);
            this.buttonLeave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonLeave.TabIndex = 11;
            this.buttonLeave.TabStop = false;
            this.buttonLeave.Click += new System.EventHandler(this.buttonLeave_Click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContinue.Font = new System.Drawing.Font("Quicksand", 15F, System.Drawing.FontStyle.Bold);
            this.buttonContinue.ForeColor = System.Drawing.Color.White;
            this.buttonContinue.Location = new System.Drawing.Point(124, 147);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(199, 45);
            this.buttonContinue.TabIndex = 10;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Quicksand", 40F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 89);
            this.label1.TabIndex = 9;
            this.label1.Text = "Game paused";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonPause
            // 
            this.buttonPause.Image = global::SnakeOnline.Properties.Resources.pause;
            this.buttonPause.Location = new System.Drawing.Point(0, 28);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(55, 55);
            this.buttonPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonPause.TabIndex = 6;
            this.buttonPause.TabStop = false;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            this.buttonPause.MouseEnter += new System.EventHandler(this.buttonPause_MouseEnter);
            this.buttonPause.MouseLeave += new System.EventHandler(this.buttonPause_MouseLeave);
            // 
            // panelDefeat
            // 
            this.panelDefeat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.panelDefeat.Controls.Add(this.buttonRetry2);
            this.panelDefeat.Controls.Add(this.buttonLeave2);
            this.panelDefeat.Controls.Add(this.label2);
            this.panelDefeat.Location = new System.Drawing.Point(319, 299);
            this.panelDefeat.Name = "panelDefeat";
            this.panelDefeat.Size = new System.Drawing.Size(454, 163);
            this.panelDefeat.TabIndex = 13;
            this.panelDefeat.Visible = false;
            // 
            // buttonRetry2
            // 
            this.buttonRetry2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRetry2.Image = global::SnakeOnline.Properties.Resources.retry;
            this.buttonRetry2.Location = new System.Drawing.Point(231, 101);
            this.buttonRetry2.Name = "buttonRetry2";
            this.buttonRetry2.Size = new System.Drawing.Size(45, 45);
            this.buttonRetry2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonRetry2.TabIndex = 12;
            this.buttonRetry2.TabStop = false;
            this.buttonRetry2.Click += new System.EventHandler(this.buttonRetry_Click);
            // 
            // buttonLeave2
            // 
            this.buttonLeave2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLeave2.Image = global::SnakeOnline.Properties.Resources.exit;
            this.buttonLeave2.Location = new System.Drawing.Point(178, 101);
            this.buttonLeave2.Name = "buttonLeave2";
            this.buttonLeave2.Size = new System.Drawing.Size(45, 45);
            this.buttonLeave2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonLeave2.TabIndex = 11;
            this.buttonLeave2.TabStop = false;
            this.buttonLeave2.Click += new System.EventHandler(this.buttonLeave_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Quicksand", 40F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(454, 89);
            this.label2.TabIndex = 9;
            this.label2.Text = "Defeat :(";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(65)))), ((int)(((byte)(97)))));
            this.ClientSize = new System.Drawing.Size(1067, 658);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.panelDefeat);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.panelAppMenu);
            this.Controls.Add(this.panelPause);
            this.Font = new System.Drawing.Font("Quicksand", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.panelAppMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimizeApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximizeApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCloseApp)).EndInit();
            this.panelPause.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonRetry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPause)).EndInit();
            this.panelDefeat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonRetry2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAppMenu;
        private System.Windows.Forms.PictureBox buttonMinimizeApp;
        private System.Windows.Forms.PictureBox buttonMaximizeApp;
        private System.Windows.Forms.PictureBox buttonCloseApp;
        private System.Windows.Forms.PictureBox buttonPause;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Panel panelPause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.PictureBox buttonLeave;
        private System.Windows.Forms.PictureBox buttonRetry;
        private System.Windows.Forms.Panel panelDefeat;
        private System.Windows.Forms.PictureBox buttonRetry2;
        private System.Windows.Forms.PictureBox buttonLeave2;
        private System.Windows.Forms.Label label2;
    }
}