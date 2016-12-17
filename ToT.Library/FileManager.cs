using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToT.Library
{
    public class FileManager
    {
        public void SaveToFile(string strToWrite, string path)
        {
            StreamWriter file = new System.IO.StreamWriter(path);
            file.WriteLine(strToWrite);

            file.Close();
        }





        public string SerializeWorld(World worldToSerialize)
        {
            string world;

            world = JsonConvert.SerializeObject(worldToSerialize);

            return world;
        }

        public World DeserializeWorld(string srlzdWorld)
        {
            World tWorld = null;
            tWorld = JsonConvert.DeserializeObject<World>(srlzdWorld);

            return tWorld;
        }

        public World LoadWorld(string worldPath)
        {
            World tWorld = null; 
            tWorld = JsonConvert.DeserializeObject<World>(File.ReadAllText(@worldPath));
            
            return tWorld;
        }

        public List<string> GetWorlds(string worldPath)
        {
            DirectoryInfo d = new DirectoryInfo(worldPath);
            List<string> worlds = new List<string>();
            
            foreach (var file in d.GetFiles("*.totw"))
                worlds.Add(file.Name.Replace(".totw", ""));

            return worlds;
        }
    }
}
