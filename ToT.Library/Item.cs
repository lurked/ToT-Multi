using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;
using Microsoft.Xna.Framework.Graphics;

namespace ToT.Library
{
    public class Item
    {
        public string Name { get; set; }
        public ItemType IType { get; set; }
        [Browsable(false)]
        public string TextureImg { get; set; }
        public List<Prop> Props { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public bool ToDraw { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public Texture2D Img { get; set; }
        

        public Item()
        {
            Props = new List<Prop>();
        }

        public Item(string name, ItemType itemType, string template = "")
        {
            Name = name;
            IType = itemType;

            if (template != "")
                InitFromTemplate(template);

            Props = new List<Prop>();
        }

        public void InitFromTemplate(string template)
        {

        }
    }
}
