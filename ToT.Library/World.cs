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
        public List<Block> BlocksBase { get; set; }
        public List<Block> BlocksNorth { get; set; }
        public List<Block> BlocksSouth { get; set; }
        public List<Block> BlocksWest { get; set; }
        public List<Block> BlocksEast { get; set; }

        public World()
        {
            BlocksBase = new List<Block>();
            BlocksNorth = new List<Block>();
            BlocksSouth = new List<Block>();
            BlocksWest = new List<Block>();
            BlocksEast = new List<Block>();
        }

        public World(string name, WorldAction worldAction)
        {
            BlocksBase = new List<Block>();
            BlocksNorth = new List<Block>();
            BlocksSouth = new List<Block>();
            BlocksWest = new List<Block>();
            BlocksEast = new List<Block>();

            if (worldAction == WorldAction.GenerateNew)
            {
                Name = name;


                BlocksBase.Add(new Block()
                {
                    Position = new Vector2(0, 0),
                    Dimensions = new Vector2(1440, 900),
                    Level = 0,
                    TemplateName = "MainBase",
                    Coords = "B:0"
                });

                AddTiles(BlocksNorth, 5, Orientation.North);
                AddTiles(BlocksSouth, 5, Orientation.South);
                AddTiles(BlocksWest, 5, Orientation.West);
                AddTiles(BlocksEast, 5, Orientation.East);
            }

        }

        public void AddTiles(List<Block> Blocks, int nbTiles, Orientation ori)
        {
            Random randDim = new Random();
            Block lastBlock;
            Vector2 tDimensions;


            Array sizeValues;
            Random randSize = new Random();
            TileSize randomSize;

            sizeValues = Enum.GetValues(typeof(TileSize));

            float tX = 0;
            float tY = 0;

            for(int i = 0; i < nbTiles; i++)
            {
                tX = 0;
                tY = 0;


                //if (Blocks.Count > 3)
                //{
                //    lastBlock = Blocks[Blocks.Count - 1];

                //    randomSize = (TileSize)sizeValues.GetValue(random.Next(0, sizeValues.Length));
                //}
                //else
                if (Blocks.Count > 0)
                {
                    lastBlock = Blocks[Blocks.Count - 1];

                    randomSize = (TileSize)sizeValues.GetValue(randSize.Next(0, sizeValues.Length));
                }
                else
                {
                    lastBlock = BlocksBase[0];

                    //randomSize = TileSize.Medium;
                    randomSize = (TileSize)sizeValues.GetValue(randSize.Next(0, sizeValues.Length - 3));
                }
                
                tDimensions = GetSize(randomSize);

                string sBCoords = "";
                switch (ori)
                {
                    case Orientation.North:
                        if (Blocks.Count == 0)
                            tX = lastBlock.Position.X + (lastBlock.Dimensions.X - tDimensions.X) / 2;
                        else
                            tX = randDim.Next((int)lastBlock.Position.X - (int)lastBlock.Dimensions.X + 96, (int)lastBlock.Position.X + (int)lastBlock.Dimensions.X - 96);

                        tY = lastBlock.Position.Y - tDimensions.Y;
                        sBCoords = "N:" + Blocks.Count.ToString();
                        break;
                    case Orientation.South:
                        if (Blocks.Count == 0)
                            tX = lastBlock.Position.X + (lastBlock.Dimensions.X - tDimensions.X) / 2;
                        else
                            tX = randDim.Next((int)lastBlock.Position.X - (int)lastBlock.Dimensions.X + 96, (int)lastBlock.Position.X + (int)lastBlock.Dimensions.X - 96);
                        tY = lastBlock.Position.Y + lastBlock.Dimensions.Y;
                        sBCoords = "S:" + Blocks.Count.ToString();

                        break;
                    case Orientation.West:
                        if (Blocks.Count == 0)
                            tY = lastBlock.Position.Y + (lastBlock.Dimensions.Y - tDimensions.Y) / 2;
                        else
                            tY = randDim.Next((int)lastBlock.Position.Y - (int)lastBlock.Dimensions.Y + 96, (int)lastBlock.Position.Y + (int)lastBlock.Dimensions.Y - 96);
                        tX = lastBlock.Position.X - tDimensions.X;
                        sBCoords = "W:" + Blocks.Count.ToString();

                        break;
                    case Orientation.East:
                        if (Blocks.Count == 0)
                            tY = lastBlock.Position.Y + (lastBlock.Dimensions.Y - tDimensions.Y) / 2;
                        else
                            tY = randDim.Next((int)lastBlock.Position.Y - (int)lastBlock.Dimensions.Y + 96, (int)lastBlock.Position.Y + (int)lastBlock.Dimensions.Y - 96);
                        tX = lastBlock.Position.X + lastBlock.Dimensions.X;
                        sBCoords = "E:" + Blocks.Count.ToString();

                        break;
                }
                Block newBlock = new Block()
                {
                    Position = new Vector2(tX, tY),
                    Dimensions = tDimensions,
                    Level = 0,
                    TemplateName = "MainBase",
                    Coords = sBCoords
                };


                Blocks.Add(newBlock);


            }
            
        }

        private static Vector2 GetSize(TileSize randomSize)
        {
            Vector2 tDimensions;
            Random tRand = new Random();
            switch (randomSize)
            {
                case TileSize.Tiny:
                    tDimensions = new Vector2(tRand.Next(144, 289), tRand.Next(144, 289));
                    break;
                case TileSize.VerySmall:
                    tDimensions = new Vector2(tRand.Next(240, 481), tRand.Next(240, 481));
                    break;
                case TileSize.Small:
                    tDimensions = new Vector2(tRand.Next(384, 769), tRand.Next(384, 769));
                    break;
                case TileSize.Medium:
                    tDimensions = new Vector2(tRand.Next(432, 865), tRand.Next(432, 865));
                    break;
                case TileSize.Large:
                    tDimensions = new Vector2(tRand.Next(576, 1153), tRand.Next(576, 1153));
                    break;
                case TileSize.VeryLarge:
                    tDimensions = new Vector2(tRand.Next(816, 1441), tRand.Next(816, 1441));
                    break;
                case TileSize.Huge:
                    tDimensions = new Vector2(tRand.Next(1200, 1681), tRand.Next(1200, 1681));
                    break;
                case TileSize.HughMongus:
                    tDimensions = new Vector2(tRand.Next(1440, 1921), tRand.Next(1440, 1921));
                    break;
                default:
                    tDimensions = new Vector2(640, 480);
                    break;
            }
            return tDimensions;
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
