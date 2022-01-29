
namespace SnakeOnline
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.panelAppMenu = new System.Windows.Forms.Panel();
            this.buttonMinimizeApp = new System.Windows.Forms.PictureBox();
            this.buttonMaximizeApp = new System.Windows.Forms.PictureBox();
            this.buttonCloseApp = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.labelExit = new System.Windows.Forms.Label();
            this.labelSinglePlayer = new System.Windows.Forms.Label();
            this.labelMultiPlayer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxYdav = new System.Windows.Forms.PictureBox();
            this.panelAppMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimizeApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximizeApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCloseApp)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYdav)).BeginInit();
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
            this.panelAppMenu.TabIndex = 4;
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
            this.buttonMaximizeApp.MouseEnter += new System.EventHandler(this.buttonMinOrMax_MouseEnter);
            this.buttonMaximizeApp.MouseLeave += new System.EventHandler(this.buttonMinOrMax_MouseLeave);
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
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Quicksand", 95F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(207, 54);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(457, 155);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Snake";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelMenu.Controls.Add(this.labelExit);
            this.panelMenu.Controls.Add(this.labelSinglePlayer);
            this.panelMenu.Controls.Add(this.labelMultiPlayer);
            this.panelMenu.Location = new System.Drawing.Point(0, 216);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(397, 440);
            this.panelMenu.TabIndex = 8;
            // 
            // labelExit
            // 
            this.labelExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelExit.Font = new System.Drawing.Font("Quicksand Medium", 25F, System.Drawing.FontStyle.Bold);
            this.labelExit.Location = new System.Drawing.Point(0, 116);
            this.labelExit.Name = "labelExit";
            this.labelExit.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelExit.Size = new System.Drawing.Size(397, 58);
            this.labelExit.TabIndex = 11;
            this.labelExit.Text = "Exit";
            this.labelExit.Click += new System.EventHandler(this.labelExit_Click);
            this.labelExit.MouseEnter += new System.EventHandler(this.MainMenuButton_MouseEnter);
            this.labelExit.MouseLeave += new System.EventHandler(this.MainMenuButton_MouseLeave);
            // 
            // labelSinglePlayer
            // 
            this.labelSinglePlayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSinglePlayer.Font = new System.Drawing.Font("Quicksand Medium", 25F, System.Drawing.FontStyle.Bold);
            this.labelSinglePlayer.Location = new System.Drawing.Point(0, 58);
            this.labelSinglePlayer.Name = "labelSinglePlayer";
            this.labelSinglePlayer.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelSinglePlayer.Size = new System.Drawing.Size(397, 58);
            this.labelSinglePlayer.TabIndex = 9;
            this.labelSinglePlayer.Text = "Single player";
            this.labelSinglePlayer.Click += new System.EventHandler(this.labelSinglePlayer_Click);
            this.labelSinglePlayer.MouseEnter += new System.EventHandler(this.MainMenuButton_MouseEnter);
            this.labelSinglePlayer.MouseLeave += new System.EventHandler(this.MainMenuButton_MouseLeave);
            // 
            // labelMultiPlayer
            // 
            this.labelMultiPlayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMultiPlayer.Font = new System.Drawing.Font("Quicksand Medium", 25F, System.Drawing.FontStyle.Bold);
            this.labelMultiPlayer.Location = new System.Drawing.Point(0, 0);
            this.labelMultiPlayer.Name = "labelMultiPlayer";
            this.labelMultiPlayer.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelMultiPlayer.Size = new System.Drawing.Size(397, 58);
            this.labelMultiPlayer.TabIndex = 8;
            this.labelMultiPlayer.Text = "Multi player";
            this.labelMultiPlayer.Click += new System.EventHandler(this.labelMultiPlayer_Click);
            this.labelMultiPlayer.MouseEnter += new System.EventHandler(this.MainMenuButton_MouseEnter);
            this.labelMultiPlayer.MouseLeave += new System.EventHandler(this.MainMenuButton_MouseLeave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Quicksand Light", 95.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(608, -21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 180);
            this.label1.TabIndex = 9;
            this.label1.Text = "ydav";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(233, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 10);
            this.panel1.TabIndex = 10;
            // 
            // pictureBoxYdav
            // 
            this.pictureBoxYdav.Image = global::SnakeOnline.Properties.Resources.snake;
            this.pictureBoxYdav.Location = new System.Drawing.Point(947, 54);
            this.pictureBoxYdav.Name = "pictureBoxYdav";
            this.pictureBoxYdav.Size = new System.Drawing.Size(59, 54);
            this.pictureBoxYdav.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxYdav.TabIndex = 11;
            this.pictureBoxYdav.TabStop = false;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(65)))), ((int)(((byte)(97)))));
            this.ClientSize = new System.Drawing.Size(1067, 658);
            this.Controls.Add(this.pictureBoxYdav);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelAppMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("Quicksand", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ydav";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainMenu_KeyDown);
            this.panelAppMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimizeApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximizeApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCloseApp)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYdav)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAppMenu;
        private System.Windows.Forms.PictureBox buttonMinimizeApp;
        private System.Windows.Forms.PictureBox buttonMaximizeApp;
        private System.Windows.Forms.PictureBox buttonCloseApp;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label labelSinglePlayer;
        private System.Windows.Forms.Label labelMultiPlayer;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxYdav;
    }
}

