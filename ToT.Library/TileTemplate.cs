using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToT.Library
{
    public class TileTemplate
    {
        public string Name { get; set; }
        public int MinTileLevel { get; set; }
        public int MaxTileLevel { get; set; }

        [Browsable(false)]
        public List<NPC> Enemies { get; set; }

        [Browsable(false)]
        public List<string> Styles { get; set; }

        public TileTemplate()
        {
            Name = "Default Tile Template";
            Enemies = new List<NPC>();
            Styles = new List<string>();
        }

        public TileTemplate(string name)
        {
            Name = name;
            Enemies = new List<NPC>();
            Styles = new List<string>();
        }

    }
}
