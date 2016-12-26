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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(totServerForm));
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
            this.btnSaveWorld = new System.Windows.Forms.Button();
            this.groupWorldSettings = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTemplate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWorldName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboGameMode = new System.Windows.Forms.ComboBox();
            this.lblWorld = new System.Windows.Forms.Label();
            this.cboWorld = new System.Windows.Forms.ComboBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupStats = new System.Windows.Forms.GroupBox();
            this.tabToolkit = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNewTemplate = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSaveTemplate = new System.Windows.Forms.ToolStripButton();
            this.tabTKItems = new System.Windows.Forms.TabControl();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.splitItems = new System.Windows.Forms.SplitContainer();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnImgSelect = new System.Windows.Forms.Button();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtItemImage = new System.Windows.Forms.TextBox();
            this.dgItemProps = new System.Windows.Forms.DataGridView();
            this.pictureItem = new System.Windows.Forms.PictureBox();
            this.gridItems = new System.Windows.Forms.PropertyGrid();
            this.tabNPCs = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRemoveNPC = new System.Windows.Forms.Button();
            this.dgNPCs = new System.Windows.Forms.DataGridView();
            this.btnAddNPC = new System.Windows.Forms.Button();
            this.btnBrowseImageNPC = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtImageNPC = new System.Windows.Forms.TextBox();
            this.dgNPCProps = new System.Windows.Forms.DataGridView();
            this.pictureNPC = new System.Windows.Forms.PictureBox();
            this.gridNPC = new System.Windows.Forms.PropertyGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBrowseTemplate = new System.Windows.Forms.Button();
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabGame.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupClientSettings.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.groupWorldSettings.SuspendLayout();
            this.groupStats.SuspendLayout();
            this.tabToolkit.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabTKItems.SuspendLayout();
            this.tabItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitItems)).BeginInit();
            this.splitItems.Panel1.SuspendLayout();
            this.splitItems.Panel2.SuspendLayout();
            this.splitItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemProps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureItem)).BeginInit();
            this.tabNPCs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNPCs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNPCProps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNPC)).BeginInit();
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
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.tabServer.Controls.Add(this.btnSaveWorld);
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
            // btnSaveWorld
            // 
            this.btnSaveWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveWorld.Font = new System.Drawing.Font("Miramonte", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveWorld.Location = new System.Drawing.Point(1004, 353);
            this.btnSaveWorld.Name = "btnSaveWorld";
            this.btnSaveWorld.Size = new System.Drawing.Size(129, 65);
            this.btnSaveWorld.TabIndex = 10;
            this.btnSaveWorld.Text = "Save";
            this.btnSaveWorld.UseVisualStyleBackColor = true;
            this.btnSaveWorld.Click += new System.EventHandler(this.btnSaveWorld_Click);
            // 
            // groupWorldSettings
            // 
            this.groupWorldSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupWorldSettings.Controls.Add(this.label6);
            this.groupWorldSettings.Controls.Add(this.cboTemplate);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Template";
            // 
            // cboTemplate
            // 
            this.cboTemplate.FormattingEnabled = true;
            this.cboTemplate.Location = new System.Drawing.Point(6, 120);
            this.cboTemplate.Name = "cboTemplate";
            this.cboTemplate.Size = new System.Drawing.Size(311, 21);
            this.cboTemplate.TabIndex = 9;
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
            this.lblWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorld.AutoSize = true;
            this.lblWorld.Location = new System.Drawing.Point(807, 5);
            this.lblWorld.Name = "lblWorld";
            this.lblWorld.Size = new System.Drawing.Size(35, 13);
            this.lblWorld.TabIndex = 8;
            this.lblWorld.Text = "World";
            // 
            // cboWorld
            // 
            this.cboWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWorld.FormattingEnabled = true;
            this.cboWorld.Location = new System.Drawing.Point(807, 21);
            this.cboWorld.Name = "cboWorld";
            this.cboWorld.Size = new System.Drawing.Size(326, 21);
            this.cboWorld.TabIndex = 7;
            this.cboWorld.SelectedIndexChanged += new System.EventHandler(this.cboWorld_SelectedIndexChanged);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.tabToolkit.Controls.Add(this.toolStrip1);
            this.tabToolkit.Controls.Add(this.tabTKItems);
            this.tabToolkit.Controls.Add(this.label5);
            this.tabToolkit.Controls.Add(this.btnBrowseTemplate);
            this.tabToolkit.Controls.Add(this.txtTemplatePath);
            this.tabToolkit.Location = new System.Drawing.Point(4, 22);
            this.tabToolkit.Name = "tabToolkit";
            this.tabToolkit.Size = new System.Drawing.Size(1136, 649);
            this.tabToolkit.TabIndex = 3;
            this.tabToolkit.Text = "Tool Kit";
            this.tabToolkit.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNewTemplate,
            this.toolStripBtnSaveTemplate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1136, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnNewTemplate
            // 
            this.toolStripBtnNewTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnNewTemplate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnNewTemplate.Image")));
            this.toolStripBtnNewTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNewTemplate.Name = "toolStripBtnNewTemplate";
            this.toolStripBtnNewTemplate.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnNewTemplate.Text = "New Template";
            this.toolStripBtnNewTemplate.Click += new System.EventHandler(this.toolStripBtnNewTemplate_Click);
            // 
            // toolStripBtnSaveTemplate
            // 
            this.toolStripBtnSaveTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSaveTemplate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSaveTemplate.Image")));
            this.toolStripBtnSaveTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSaveTemplate.Name = "toolStripBtnSaveTemplate";
            this.toolStripBtnSaveTemplate.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnSaveTemplate.Text = "toolStripButton2";
            this.toolStripBtnSaveTemplate.Click += new System.EventHandler(this.toolStripBtnSaveTemplate_Click);
            // 
            // tabTKItems
            // 
            this.tabTKItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTKItems.Controls.Add(this.tabItems);
            this.tabTKItems.Controls.Add(this.tabNPCs);
            this.tabTKItems.Location = new System.Drawing.Point(4, 72);
            this.tabTKItems.Name = "tabTKItems";
            this.tabTKItems.SelectedIndex = 0;
            this.tabTKItems.Size = new System.Drawing.Size(1132, 574);
            this.tabTKItems.TabIndex = 5;
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.splitItems);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(1124, 548);
            this.tabItems.TabIndex = 0;
            this.tabItems.Text = "Items";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // splitItems
            // 
            this.splitItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitItems.Location = new System.Drawing.Point(6, 6);
            this.splitItems.Name = "splitItems";
            // 
            // splitItems.Panel1
            // 
            this.splitItems.Panel1.Controls.Add(this.btnRemoveItem);
            this.splitItems.Panel1.Controls.Add(this.dgItems);
            this.splitItems.Panel1.Controls.Add(this.btnAddItem);
            // 
            // splitItems.Panel2
            // 
            this.splitItems.Panel2.Controls.Add(this.btnImgSelect);
            this.splitItems.Panel2.Controls.Add(this.lblImage);
            this.splitItems.Panel2.Controls.Add(this.txtItemImage);
            this.splitItems.Panel2.Controls.Add(this.dgItemProps);
            this.splitItems.Panel2.Controls.Add(this.pictureItem);
            this.splitItems.Panel2.Controls.Add(this.gridItems);
            this.splitItems.Size = new System.Drawing.Size(1112, 536);
            this.splitItems.SplitterDistance = 360;
            this.splitItems.TabIndex = 4;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(28, 3);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(19, 23);
            this.btnRemoveItem.TabIndex = 3;
            this.btnRemoveItem.Text = "-";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.AllowUserToDeleteRows = false;
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Location = new System.Drawing.Point(3, 32);
            this.dgItems.MultiSelect = false;
            this.dgItems.Name = "dgItems";
            this.dgItems.ReadOnly = true;
            this.dgItems.Size = new System.Drawing.Size(354, 501);
            this.dgItems.TabIndex = 2;
            this.dgItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellClick);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(3, 3);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(19, 23);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "+";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnImgSelect
            // 
            this.btnImgSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImgSelect.Location = new System.Drawing.Point(721, 3);
            this.btnImgSelect.Name = "btnImgSelect";
            this.btnImgSelect.Size = new System.Drawing.Size(24, 23);
            this.btnImgSelect.TabIndex = 6;
            this.btnImgSelect.Text = "...";
            this.btnImgSelect.UseVisualStyleBackColor = true;
            this.btnImgSelect.Click += new System.EventHandler(this.btnImgSelect_Click);
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(391, 8);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(42, 13);
            this.lblImage.TabIndex = 5;
            this.lblImage.Text = "Image :";
            // 
            // txtItemImage
            // 
            this.txtItemImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemImage.Location = new System.Drawing.Point(439, 5);
            this.txtItemImage.Name = "txtItemImage";
            this.txtItemImage.ReadOnly = true;
            this.txtItemImage.Size = new System.Drawing.Size(276, 20);
            this.txtItemImage.TabIndex = 4;
            this.txtItemImage.TextChanged += new System.EventHandler(this.txtItemImage_TextChanged);
            // 
            // dgItemProps
            // 
            this.dgItemProps.AllowUserToOrderColumns = true;
            this.dgItemProps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgItemProps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemProps.Location = new System.Drawing.Point(3, 294);
            this.dgItemProps.MultiSelect = false;
            this.dgItemProps.Name = "dgItemProps";
            this.dgItemProps.Size = new System.Drawing.Size(382, 239);
            this.dgItemProps.TabIndex = 3;
            // 
            // pictureItem
            // 
            this.pictureItem.Location = new System.Drawing.Point(391, 29);
            this.pictureItem.Name = "pictureItem";
            this.pictureItem.Size = new System.Drawing.Size(354, 504);
            this.pictureItem.TabIndex = 1;
            this.pictureItem.TabStop = false;
            // 
            // gridItems
            // 
            this.gridItems.Location = new System.Drawing.Point(3, 3);
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(382, 285);
            this.gridItems.TabIndex = 0;
            // 
            // tabNPCs
            // 
            this.tabNPCs.Controls.Add(this.splitContainer1);
            this.tabNPCs.Location = new System.Drawing.Point(4, 22);
            this.tabNPCs.Name = "tabNPCs";
            this.tabNPCs.Padding = new System.Windows.Forms.Padding(3);
            this.tabNPCs.Size = new System.Drawing.Size(1124, 548);
            this.tabNPCs.TabIndex = 1;
            this.tabNPCs.Text = "NPCs";
            this.tabNPCs.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRemoveNPC);
            this.splitContainer1.Panel1.Controls.Add(this.dgNPCs);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddNPC);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnBrowseImageNPC);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.txtImageNPC);
            this.splitContainer1.Panel2.Controls.Add(this.dgNPCProps);
            this.splitContainer1.Panel2.Controls.Add(this.pictureNPC);
            this.splitContainer1.Panel2.Controls.Add(this.gridNPC);
            this.splitContainer1.Size = new System.Drawing.Size(1112, 536);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 5;
            // 
            // btnRemoveNPC
            // 
            this.btnRemoveNPC.Location = new System.Drawing.Point(28, 3);
            this.btnRemoveNPC.Name = "btnRemoveNPC";
            this.btnRemoveNPC.Size = new System.Drawing.Size(19, 23);
            this.btnRemoveNPC.TabIndex = 3;
            this.btnRemoveNPC.Text = "-";
            this.btnRemoveNPC.UseVisualStyleBackColor = true;
            // 
            // dgNPCs
            // 
            this.dgNPCs.AllowUserToAddRows = false;
            this.dgNPCs.AllowUserToDeleteRows = false;
            this.dgNPCs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNPCs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNPCs.Location = new System.Drawing.Point(3, 32);
            this.dgNPCs.MultiSelect = false;
            this.dgNPCs.Name = "dgNPCs";
            this.dgNPCs.ReadOnly = true;
            this.dgNPCs.Size = new System.Drawing.Size(354, 501);
            this.dgNPCs.TabIndex = 2;
            this.dgNPCs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNPCs_CellClick);
            // 
            // btnAddNPC
            // 
            this.btnAddNPC.Location = new System.Drawing.Point(3, 3);
            this.btnAddNPC.Name = "btnAddNPC";
            this.btnAddNPC.Size = new System.Drawing.Size(19, 23);
            this.btnAddNPC.TabIndex = 1;
            this.btnAddNPC.Text = "+";
            this.btnAddNPC.UseVisualStyleBackColor = true;
            this.btnAddNPC.Click += new System.EventHandler(this.btnAddNPC_Click);
            // 
            // btnBrowseImageNPC
            // 
            this.btnBrowseImageNPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseImageNPC.Location = new System.Drawing.Point(721, 3);
            this.btnBrowseImageNPC.Name = "btnBrowseImageNPC";
            this.btnBrowseImageNPC.Size = new System.Drawing.Size(24, 23);
            this.btnBrowseImageNPC.TabIndex = 6;
            this.btnBrowseImageNPC.Text = "...";
            this.btnBrowseImageNPC.UseVisualStyleBackColor = true;
            this.btnBrowseImageNPC.Click += new System.EventHandler(this.btnBrowseImageNPC_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(391, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Image :";
            // 
            // txtImageNPC
            // 
            this.txtImageNPC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageNPC.Location = new System.Drawing.Point(439, 5);
            this.txtImageNPC.Name = "txtImageNPC";
            this.txtImageNPC.ReadOnly = true;
            this.txtImageNPC.Size = new System.Drawing.Size(276, 20);
            this.txtImageNPC.TabIndex = 4;
            this.txtImageNPC.TextChanged += new System.EventHandler(this.txtImageNPC_TextChanged);
            // 
            // dgNPCProps
            // 
            this.dgNPCProps.AllowUserToOrderColumns = true;
            this.dgNPCProps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgNPCProps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNPCProps.Location = new System.Drawing.Point(3, 294);
            this.dgNPCProps.MultiSelect = false;
            this.dgNPCProps.Name = "dgNPCProps";
            this.dgNPCProps.Size = new System.Drawing.Size(382, 239);
            this.dgNPCProps.TabIndex = 3;
            // 
            // pictureNPC
            // 
            this.pictureNPC.Location = new System.Drawing.Point(391, 29);
            this.pictureNPC.Name = "pictureNPC";
            this.pictureNPC.Size = new System.Drawing.Size(354, 504);
            this.pictureNPC.TabIndex = 1;
            this.pictureNPC.TabStop = false;
            // 
            // gridNPC
            // 
            this.gridNPC.Location = new System.Drawing.Point(3, 3);
            this.gridNPC.Name = "gridNPC";
            this.gridNPC.Size = new System.Drawing.Size(382, 285);
            this.gridNPC.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Template :";
            // 
            // btnBrowseTemplate
            // 
            this.btnBrowseTemplate.Location = new System.Drawing.Point(1045, 43);
            this.btnBrowseTemplate.Name = "btnBrowseTemplate";
            this.btnBrowseTemplate.Size = new System.Drawing.Size(88, 23);
            this.btnBrowseTemplate.TabIndex = 2;
            this.btnBrowseTemplate.Text = "Browse";
            this.btnBrowseTemplate.UseVisualStyleBackColor = true;
            this.btnBrowseTemplate.Click += new System.EventHandler(this.btnBrowseTemplate_Click);
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.Location = new System.Drawing.Point(5, 45);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.Size = new System.Drawing.Size(1034, 20);
            this.txtTemplatePath.TabIndex = 1;
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
            this.tabToolkit.ResumeLayout(false);
            this.tabToolkit.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabTKItems.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            this.splitItems.Panel1.ResumeLayout(false);
            this.splitItems.Panel2.ResumeLayout(false);
            this.splitItems.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitItems)).EndInit();
            this.splitItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemProps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureItem)).EndInit();
            this.tabNPCs.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgNPCs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNPCProps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNPC)).EndInit();
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
        private System.Windows.Forms.Button btnSaveWorld;
        private System.Windows.Forms.TabControl tabTKItems;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.SplitContainer splitItems;
        private System.Windows.Forms.TabPage tabNPCs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBrowseTemplate;
        private System.Windows.Forms.TextBox txtTemplatePath;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.PictureBox pictureItem;
        private System.Windows.Forms.PropertyGrid gridItems;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnNewTemplate;
        private System.Windows.Forms.ToolStripButton toolStripBtnSaveTemplate;
        private System.Windows.Forms.DataGridView dgItemProps;
        private System.Windows.Forms.Button btnImgSelect;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtItemImage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTemplate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRemoveNPC;
        private System.Windows.Forms.DataGridView dgNPCs;
        private System.Windows.Forms.Button btnAddNPC;
        private System.Windows.Forms.Button btnBrowseImageNPC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtImageNPC;
        private System.Windows.Forms.DataGridView dgNPCProps;
        private System.Windows.Forms.PictureBox pictureNPC;
        private System.Windows.Forms.PropertyGrid gridNPC;
        public static System.Windows.Forms.Label label1;
        public static System.Windows.Forms.TextBox textBox1;
        public static System.Windows.Forms.Timer timer1;



    }
}

