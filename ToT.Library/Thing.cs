using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace ToT.Library
{
    public class Thing
    {
        public string Name { get; set; }

        public Vector2 Position { get; set; }

        public List<Prop> Props { get; set; }

        public string BlockCoords { get; set; }

        public string TemplateName { get; set; }

        public Thing()
        {

        }

        public Thing(string blockCoords, string name, string templateName)
        {
            BlockCoords = blockCoords;
            Name = name;
            TemplateName = templateName;
        }


    }
}
