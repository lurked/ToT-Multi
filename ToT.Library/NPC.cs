using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;

namespace ToT.Library
{
    public class NPC
    {
        public string Name { get; set; }
        public NPCType NpcType { get; set; }
        [Browsable(false)]
        public string TextureImg { get; set; }
        public List<Prop> Props { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public bool ToDraw { get; set; }


        public NPC()
        {
            Props = new List<Prop>();
        }

        public NPC(string name, NPCType npcType, string template = "")
        {
            Name = name;
            NpcType = npcType;

            if (template != "")
                InitFromTemplate(template);

            Props = new List<Prop>();
        }

        public void InitFromTemplate(string template)
        {

        }
    }
}