using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToT.Library
{
    public class Template
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }
        public List<NPC> NPCs { get; set; }

        public Template()
        {
            Items = new List<Item>();
            NPCs = new List<NPC>();
            //Items.Add(new Item("New Item 1", ItemType.Weapon));
        }

        public Template(string name)
        {
            Name = name;
            Items = new List<Item>();
            Items.Add(new Item("New Item 1", ItemType.Weapon));
            NPCs = new List<NPC>();
            NPCs.Add(new NPC("New NPC 1", NPCType.Neutral));
            
        }

        public string Serialize()
        {
            string dsrlzdTemplate = "";

            dsrlzdTemplate = JsonConvert.SerializeObject(this);

            return dsrlzdTemplate;
        }
    }
}
