using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Xna.Framework.Graphics;

namespace ToT.Library
{
    public class Template
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }
        public List<NPC> NPCs { get; set; }
        public List<TileTemplate> TTemplates { get; set; }
        [Browsable(false)]
        public List<Texture2D> ItemsImgs { get; set; }
        [Browsable(false)]
        public List<List<Texture2D>> TTempImgs { get; set; }

        public Template()
        {
            Items = new List<Item>();
            NPCs = new List<NPC>();
            TTemplates = new List<TileTemplate>();
            ItemsImgs = new List<Texture2D>();
            TTempImgs = new List<List<Texture2D>>();
            //Items.Add(new Item("New Item 1", ItemType.Weapon));
        }

        public Template(string name)
        {
            Name = name;
            Items = new List<Item>();
            Items.Add(new Item("New Item 1", ItemType.Weapon));
            NPCs = new List<NPC>();
            NPCs.Add(new NPC("New NPC 1", NPCType.Neutral));
            TTemplates = new List<TileTemplate>();
            TTemplates.Add(new TileTemplate("New Template 1"));
            ItemsImgs = new List<Texture2D>();
            TTempImgs = new List<List<Texture2D>>();
        }


        public void InitTemplateImages(GraphicsDevice tGD, string imgPath)
        {
            foreach (Item tI in Items)
            {
                FileStream filestream = new FileStream(imgPath + tI.TextureImg + ".png", FileMode.Open);
                Texture2D myTexture = Texture2D.FromStream(tGD, filestream);

                tI.Img = myTexture;
                filestream.Close();
            }

            foreach(TileTemplate tTT in TTemplates)
                foreach(NPC tN in tTT.Enemies)
                {
                    FileStream filestream = new FileStream(imgPath + tN.TextureImg + ".png", FileMode.Open);
                    Texture2D myTexture = Texture2D.FromStream(tGD, filestream);

                    tN.Img = myTexture;
                    filestream.Close();
                }


            //foreach (NPC tN in NPCs)
            //{
            //    FileStream filestream = new FileStream(imgPath + tN.TextureImg + ".png", FileMode.Open);
            //    Texture2D myTexture = Texture2D.FromStream(tGD, filestream);

            //    tN.Img = myTexture;
            //    filestream.Close();
            //}
           

            //foreach (Item tI in Items)
            //{
            //    FileStream filestream = new FileStream(imgPath + tI.TextureImg + ".png", FileMode.Open);
            //    Texture2D myTexture = Texture2D.FromStream(tGD, filestream);

            //    ItemsImgs.Add(myTexture);
            //}

            //for(int i = 0; i < TTemplates.Count; i++)
            //{
            //    List<Texture2D> tT2 = new List<Texture2D>();
            //    for(int j = 0; j < TTemplates[i].Enemies.Count; j++)
            //    {
            //        FileStream filestream = new FileStream(imgPath + TTemplates[i].Enemies[j].TextureImg + ".png", FileMode.Open);
            //        Texture2D myTexture = Texture2D.FromStream(tGD, filestream);

            //        tT2.Add(myTexture);
            //    }
            //    TTempImgs.Add(tT2);
            //}
        }


        public string Serialize()
        {
            string dsrlzdTemplate = "";

            dsrlzdTemplate = JsonConvert.SerializeObject(this);

            return dsrlzdTemplate;
        }
    }
}
