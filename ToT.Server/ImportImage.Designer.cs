namespace ToT.Server
{
    partial class ImportImage
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
            this.listImages = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.pictureItem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureItem)).BeginInit();
            this.SuspendLayout();
            // 
            // listImages
            // 
            this.listImages.FormattingEnabled = true;
            this.listImages.Location = new System.Drawing.Point(12, 51);
            this.listImages.Name = "listImages";
            this.listImages.Size = new System.Drawing.Size(299, 485);
            this.listImages.TabIndex = 0;
            this.listImages.SelectedIndexChanged += new System.EventHandler(this.listImages_SelectedIndexChanged);
            this.listImages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listImages_DoubleClick);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(580, 542);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 542);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // pictureItem
            // 
            this.pictureItem.Location = new System.Drawing.Point(317, 51);
            this.pictureItem.Name = "pictureItem";
            this.pictureItem.Size = new System.Drawing.Size(363, 485);
            this.pictureItem.TabIndex = 3;
            this.pictureItem.TabStop = false;
            // 
            // ImportImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 567);
            this.Controls.Add(this.pictureItem);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.listImages);
            this.Name = "ImportImage";
            this.Text = "ImportImage";
            this.Load += new System.EventHandler(this.ImportImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listImages;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.PictureBox pictureItem;
    }
}