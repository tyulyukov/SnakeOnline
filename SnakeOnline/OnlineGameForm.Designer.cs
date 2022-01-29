
namespace SnakeOnline
{
    partial class OnlineGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineGameForm));
            this.panelGame = new System.Windows.Forms.Panel();
            this.labelYourYdav = new System.Windows.Forms.Label();
            this.panelDefeat = new System.Windows.Forms.Panel();
            this.buttonLeave2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelWin = new System.Windows.Forms.Panel();
            this.buttonLeave = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.panelAppMenu = new System.Windows.Forms.Panel();
            this.buttonMinimizeApp = new System.Windows.Forms.PictureBox();
            this.buttonMaximizeApp = new System.Windows.Forms.PictureBox();
            this.buttonCloseApp = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.PictureBox();
            this.labelPing = new System.Windows.Forms.Label();
            this.panelGame.SuspendLayout();
            this.panelDefeat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave2)).BeginInit();
            this.panelWin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave)).BeginInit();
            this.panelAppMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimizeApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximizeApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCloseApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(193)))), ((int)(((byte)(230)))));
            this.panelGame.Controls.Add(this.labelYourYdav);
            this.panelGame.Location = new System.Drawing.Point(218, 28);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(630, 630);
            this.panelGame.TabIndex = 11;
            this.panelGame.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            // 
            // labelYourYdav
            // 
            this.labelYourYdav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelYourYdav.Font = new System.Drawing.Font("Quicksand", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYourYdav.ForeColor = System.Drawing.Color.White;
            this.labelYourYdav.Location = new System.Drawing.Point(282, 301);
            this.labelYourYdav.Name = "labelYourYdav";
            this.labelYourYdav.Size = new System.Drawing.Size(145, 34);
            this.labelYourYdav.TabIndex = 0;
            this.labelYourYdav.Text = "Your ydav ->";
            // 
            // panelDefeat
            // 
            this.panelDefeat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.panelDefeat.Controls.Add(this.buttonLeave2);
            this.panelDefeat.Controls.Add(this.label2);
            this.panelDefeat.Location = new System.Drawing.Point(226, 462);
            this.panelDefeat.Name = "panelDefeat";
            this.panelDefeat.Size = new System.Drawing.Size(454, 156);
            this.panelDefeat.TabIndex = 15;
            this.panelDefeat.Visible = false;
            // 
            // buttonLeave2
            // 
            this.buttonLeave2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLeave2.Image = global::SnakeOnline.Properties.Resources.exit;
            this.buttonLeave2.Location = new System.Drawing.Point(205, 90);
            this.buttonLeave2.Name = "buttonLeave2";
            this.buttonLeave2.Size = new System.Drawing.Size(45, 45);
            this.buttonLeave2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonLeave2.TabIndex = 11;
            this.buttonLeave2.TabStop = false;
            this.buttonLeave2.Click += new System.EventHandler(this.buttonExit_Click);
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
            // panelWin
            // 
            this.panelWin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.panelWin.Controls.Add(this.buttonLeave);
            this.panelWin.Controls.Add(this.label1);
            this.panelWin.Location = new System.Drawing.Point(229, 296);
            this.panelWin.Name = "panelWin";
            this.panelWin.Size = new System.Drawing.Size(454, 156);
            this.panelWin.TabIndex = 14;
            this.panelWin.Visible = false;
            // 
            // buttonLeave
            // 
            this.buttonLeave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLeave.Image = global::SnakeOnline.Properties.Resources.exit;
            this.buttonLeave.Location = new System.Drawing.Point(205, 90);
            this.buttonLeave.Name = "buttonLeave";
            this.buttonLeave.Size = new System.Drawing.Size(45, 45);
            this.buttonLeave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonLeave.TabIndex = 11;
            this.buttonLeave.TabStop = false;
            this.buttonLeave.Click += new System.EventHandler(this.buttonExit_Click);
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
            this.label1.Text = "You win!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelScore
            // 
            this.labelScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(65)))), ((int)(((byte)(97)))));
            this.labelScore.Font = new System.Drawing.Font("Quicksand", 30F, System.Drawing.FontStyle.Bold);
            this.labelScore.ForeColor = System.Drawing.Color.White;
            this.labelScore.Location = new System.Drawing.Point(848, 30);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(219, 126);
            this.labelScore.TabIndex = 12;
            this.labelScore.Text = "Score: 0";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.panelAppMenu.TabIndex = 9;
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
            // buttonExit
            // 
            this.buttonExit.Image = global::SnakeOnline.Properties.Resources.exit2;
            this.buttonExit.Location = new System.Drawing.Point(8, 37);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(43, 47);
            this.buttonExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonExit.TabIndex = 10;
            this.buttonExit.TabStop = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelPing
            // 
            this.labelPing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(65)))), ((int)(((byte)(97)))));
            this.labelPing.Font = new System.Drawing.Font("Quicksand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPing.ForeColor = System.Drawing.Color.White;
            this.labelPing.Location = new System.Drawing.Point(57, 37);
            this.labelPing.Name = "labelPing";
            this.labelPing.Size = new System.Drawing.Size(160, 29);
            this.labelPing.TabIndex = 16;
            this.labelPing.Text = "latency: -";
            this.labelPing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OnlineGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(65)))), ((int)(((byte)(97)))));
            this.ClientSize = new System.Drawing.Size(1067, 658);
            this.Controls.Add(this.labelPing);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.panelDefeat);
            this.Controls.Add(this.panelWin);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panelAppMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OnlineGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OnlineGameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnlineGameForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnlineGameForm_KeyDown);
            this.panelGame.ResumeLayout(false);
            this.panelDefeat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave2)).EndInit();
            this.panelWin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonLeave)).EndInit();
            this.panelAppMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimizeApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximizeApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCloseApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.PictureBox buttonExit;
        private System.Windows.Forms.Panel panelAppMenu;
        private System.Windows.Forms.PictureBox buttonMinimizeApp;
        private System.Windows.Forms.PictureBox buttonMaximizeApp;
        private System.Windows.Forms.PictureBox buttonCloseApp;
        private System.Windows.Forms.Panel panelDefeat;
        private System.Windows.Forms.PictureBox buttonLeave2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelWin;
        private System.Windows.Forms.PictureBox buttonLeave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPing;
        private System.Windows.Forms.Label labelYourYdav;
    }
}