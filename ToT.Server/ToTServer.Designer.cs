namespace ToT.Server
{
    partial class totServerForm
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
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGame = new System.Windows.Forms.TabPage();
            this.btnPlay = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupClientSettings = new System.Windows.Forms.GroupBox();
            this.btnBrowseClientPath = new System.Windows.Forms.Button();
            this.lblClientPath = new System.Windows.Forms.Label();
            this.txtClientPath = new System.Windows.Forms.TextBox();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.groupWorldSettings = new System.Windows.Forms.GroupBox();
            this.cboGameMode = new System.Windows.Forms.ComboBox();
            this.lblWorld = new System.Windows.Forms.Label();
            this.cboWorld = new System.Windows.Forms.ComboBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupStats = new System.Windows.Forms.GroupBox();
            this.tabToolkit = new System.Windows.Forms.TabPage();
            this.txtWorldName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabGame.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupClientSettings.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.groupWorldSettings.SuspendLayout();
            this.groupStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(6, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 13);
            label1.TabIndex = 0;
            label1.Text = "Players: 0";
            // 
            // textBox1
            // 
            textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            textBox1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox1.Location = new System.Drawing.Point(3, 21);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBox1.Size = new System.Drawing.Size(798, 625);
            textBox1.TabIndex = 1;
            // 
            // timer1
            // 
            timer1.Interval = 16;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGame);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabServer);
            this.tabControl1.Controls.Add(this.tabToolkit);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1144, 675);
            this.tabControl1.TabIndex = 2;
            // 
            // tabGame
            // 
            this.tabGame.Controls.Add(this.btnPlay);
            this.tabGame.Location = new System.Drawing.Point(4, 22);
            this.tabGame.Name = "tabGame";
            this.tabGame.Padding = new System.Windows.Forms.Padding(3);
            this.tabGame.Size = new System.Drawing.Size(1136, 649);
            this.tabGame.TabIndex = 0;
            this.tabGame.Text = "Game";
            this.tabGame.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Miramonte", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(1001, 581);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(129, 65);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupClientSettings);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1136, 649);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupClientSettings
            // 
            this.groupClientSettings.Controls.Add(this.btnBrowseClientPath);
            this.groupClientSettings.Controls.Add(this.lblClientPath);
            this.groupClientSettings.Controls.Add(this.txtClientPath);
            this.groupClientSettings.Location = new System.Drawing.Point(6, 6);
            this.groupClientSettings.Name = "groupClientSettings";
            this.groupClientSettings.Size = new System.Drawing.Size(510, 129);
            this.groupClientSettings.TabIndex = 0;
            this.groupClientSettings.TabStop = false;
            this.groupClientSettings.Text = "Client";
            // 
            // btnBrowseClientPath
            // 
            this.btnBrowseClientPath.Location = new System.Drawing.Point(480, 17);
            this.btnBrowseClientPath.Name = "btnBrowseClientPath";
            this.btnBrowseClientPath.Size = new System.Drawing.Size(24, 23);
            this.btnBrowseClientPath.TabIndex = 2;
            this.btnBrowseClientPath.Text = "...";
            this.btnBrowseClientPath.UseVisualStyleBackColor = true;
            // 
            // lblClientPath
            // 
            this.lblClientPath.AutoSize = true;
            this.lblClientPath.Location = new System.Drawing.Point(6, 22);
            this.lblClientPath.Name = "lblClientPath";
            this.lblClientPath.Size = new System.Drawing.Size(58, 13);
            this.lblClientPath.TabIndex = 1;
            this.lblClientPath.Text = "Client Path";
            // 
            // txtClientPath
            // 
            this.txtClientPath.Location = new System.Drawing.Point(70, 19);
            this.txtClientPath.Name = "txtClientPath";
            this.txtClientPath.Size = new System.Drawing.Size(404, 20);
            this.txtClientPath.TabIndex = 0;
            this.txtClientPath.Text = "C:\\Prog\\ToT\\ToT\\bin\\Windows\\x86\\Debug\\ToT.exe";
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.groupWorldSettings);
            this.tabServer.Controls.Add(this.lblWorld);
            this.tabServer.Controls.Add(this.cboWorld);
            this.tabServer.Controls.Add(this.btnStartServer);
            this.tabServer.Controls.Add(this.label2);
            this.tabServer.Controls.Add(this.groupStats);
            this.tabServer.Controls.Add(textBox1);
            this.tabServer.Location = new System.Drawing.Point(4, 22);
            this.tabServer.Name = "tabServer";
            this.tabServer.Size = new System.Drawing.Size(1136, 649);
            this.tabServer.TabIndex = 2;
            this.tabServer.Text = "Server";
            this.tabServer.UseVisualStyleBackColor = true;
            // 
            // groupWorldSettings
            // 
            this.groupWorldSettings.Controls.Add(this.label4);
            this.groupWorldSettings.Controls.Add(this.txtWorldName);
            this.groupWorldSettings.Controls.Add(this.label3);
            this.groupWorldSettings.Controls.Add(this.cboGameMode);
            this.groupWorldSettings.Location = new System.Drawing.Point(807, 48);
            this.groupWorldSettings.Name = "groupWorldSettings";
            this.groupWorldSettings.Size = new System.Drawing.Size(326, 299);
            this.groupWorldSettings.TabIndex = 9;
            this.groupWorldSettings.TabStop = false;
            this.groupWorldSettings.Text = "World Settings";
            // 
            // cboGameMode
            // 
            this.cboGameMode.FormattingEnabled = true;
            this.cboGameMode.Location = new System.Drawing.Point(6, 78);
            this.cboGameMode.Name = "cboGameMode";
            this.cboGameMode.Size = new System.Drawing.Size(311, 21);
            this.cboGameMode.TabIndex = 5;
            // 
            // lblWorld
            // 
            this.lblWorld.AutoSize = true;
            this.lblWorld.Location = new System.Drawing.Point(807, 5);
            this.lblWorld.Name = "lblWorld";
            this.lblWorld.Size = new System.Drawing.Size(35, 13);
            this.lblWorld.TabIndex = 8;
            this.lblWorld.Text = "World";
            // 
            // cboWorld
            // 
            this.cboWorld.FormattingEnabled = true;
            this.cboWorld.Location = new System.Drawing.Point(807, 21);
            this.cboWorld.Name = "cboWorld";
            this.cboWorld.Size = new System.Drawing.Size(326, 21);
            this.cboWorld.TabIndex = 7;
            this.cboWorld.SelectedIndexChanged += new System.EventHandler(this.cboWorld_SelectedIndexChanged);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Font = new System.Drawing.Font("Miramonte", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartServer.Location = new System.Drawing.Point(807, 353);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(129, 65);
            this.btnStartServer.TabIndex = 4;
            this.btnStartServer.Text = "Start";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server Log";
            // 
            // groupStats
            // 
            this.groupStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupStats.Controls.Add(label1);
            this.groupStats.Location = new System.Drawing.Point(807, 424);
            this.groupStats.Name = "groupStats";
            this.groupStats.Size = new System.Drawing.Size(326, 222);
            this.groupStats.TabIndex = 2;
            this.groupStats.TabStop = false;
            this.groupStats.Text = "Statistics";
            // 
            // tabToolkit
            // 
            this.tabToolkit.Location = new System.Drawing.Point(4, 22);
            this.tabToolkit.Name = "tabToolkit";
            this.tabToolkit.Size = new System.Drawing.Size(1136, 649);
            this.tabToolkit.TabIndex = 3;
            this.tabToolkit.Text = "Tool Kit";
            this.tabToolkit.UseVisualStyleBackColor = true;
            // 
            // txtWorldName
            // 
            this.txtWorldName.Location = new System.Drawing.Point(6, 39);
            this.txtWorldName.Name = "txtWorldName";
            this.txtWorldName.Size = new System.Drawing.Size(311, 20);
            this.txtWorldName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Game Mode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "World Name";
            // 
            // totServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 699);
            this.Controls.Add(this.tabControl1);
            this.Name = "totServerForm";
            this.Text = "Tales of Tiles Launcher";
            this.Load += new System.EventHandler(this.totServerForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGame.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupClientSettings.ResumeLayout(false);
            this.groupClientSettings.PerformLayout();
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            this.groupWorldSettings.ResumeLayout(false);
            this.groupWorldSettings.PerformLayout();
            this.groupStats.ResumeLayout(false);
            this.groupStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGame;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupStats;
        private System.Windows.Forms.TabPage tabToolkit;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.GroupBox groupClientSettings;
        private System.Windows.Forms.Button btnBrowseClientPath;
        private System.Windows.Forms.Label lblClientPath;
        private System.Windows.Forms.TextBox txtClientPath;
        private System.Windows.Forms.ComboBox cboGameMode;
        private System.Windows.Forms.GroupBox groupWorldSettings;
        private System.Windows.Forms.Label lblWorld;
        private System.Windows.Forms.ComboBox cboWorld;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWorldName;
        private System.Windows.Forms.Label label3;
        public static System.Windows.Forms.Label label1;
        public static System.Windows.Forms.TextBox textBox1;
        public static System.Windows.Forms.Timer timer1;



    }
}

