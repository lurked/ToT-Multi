using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToT.Library
{
    public class Prop
    {
        public string Name { get; set; }
        public float Level { get; set; }

        public Prop(string propName, float propLevel)
        {
            Name = propName;
            Level = propLevel;
        }
    }
}
