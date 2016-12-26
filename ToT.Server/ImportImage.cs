using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToT.Server
{
    public partial class ImportImage : Form
    {
        public string ImgPath { get; set; }
        public string ImgToReturn { get; set; }
        public ImportImage()
        {
            InitializeComponent();
        }

        private void ImportImage_Load(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(@ImgPath);
            FileInfo[] Files = d.GetFiles("*.*");

            foreach (FileInfo file in Files)
                listImages.Items.Add(file.Name.Replace(".png", ""));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImgToReturn = listImages.GetItemText(listImages.SelectedItem);
            pictureItem.Image = Image.FromFile(@ImgPath + ImgToReturn + ".png");
        }

        private void listImages_DoubleClick(object sender, EventArgs e)
        {
            ImgToReturn = listImages.GetItemText(listImages.SelectedItem);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
