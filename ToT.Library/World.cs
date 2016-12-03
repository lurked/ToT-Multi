using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ToT.Library
{
    public class World
    {
        public string Name { get; set; }
        public List<Block> BlocksBase {get; set; }
        public List<Block> BlocksNorth {get; set; }
        public List<Block> BlocksSouth {get; set; }
        public List<Block> BlocksWest {get; set; }
        public List<Block> BlocksEast {get; set; }

        public World()
        {
            Name = "default";
            
            BlocksBase = new List<Block>();
            BlocksNorth = new List<Block>();
            BlocksSouth = new List<Block>();
            BlocksWest = new List<Block>();
            BlocksEast = new List<Block>();

            BlocksBase.Add(new Block()
            {
                Position = new Vector2(0, 0),
                Dimensions = new Vector2(1440, 900),
                Level = 0,
                TemplateName = "MainBase"
            });
        }

        public void Update(GameTime gameTime)
        {
            foreach (Block tB in BlocksBase)
                tB.Update(gameTime);
            foreach (Block tB in BlocksNorth)
                tB.Update(gameTime);
            foreach (Block tB in BlocksSouth)
                tB.Update(gameTime);
            foreach (Block tB in BlocksWest)
                tB.Update(gameTime);
            foreach (Block tB in BlocksEast)
                tB.Update(gameTime);
        }

        public void UpdateServer(GameTime serverGameTime)
        {
            foreach (Block tB in BlocksBase)
                tB.UpdateServer(serverGameTime);
            foreach (Block tB in BlocksNorth)
                tB.UpdateServer(serverGameTime);
            foreach (Block tB in BlocksSouth)
                tB.UpdateServer(serverGameTime);
            foreach (Block tB in BlocksWest)
                tB.UpdateServer(serverGameTime);
            foreach (Block tB in BlocksEast)
                tB.UpdateServer(serverGameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block tB in BlocksBase)
                tB.Draw(spriteBatch);
            foreach (Block tB in BlocksNorth)
                tB.Draw(spriteBatch);
            foreach (Block tB in BlocksSouth)
                tB.Draw(spriteBatch);
            foreach (Block tB in BlocksWest)
                tB.Draw(spriteBatch);
            foreach (Block tB in BlocksEast)
                tB.Draw(spriteBatch);
        }
    }
}
