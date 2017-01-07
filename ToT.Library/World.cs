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
        public const string TEMPLATESPATH = "C:/Prog/ToT/ToT/Templates/";        
        public string Name { get; set; }
        public Template StuffTemplate { get; set; }
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

        public World(string name, WorldAction worldAction, string stuffTemplate = "ToTDefault_01")
        {
            BlocksBase = new List<Block>();
            BlocksNorth = new List<Block>();
            BlocksSouth = new List<Block>();
            BlocksWest = new List<Block>();
            BlocksEast = new List<Block>();

            FileManager fm = new FileManager();
            StuffTemplate = fm.LoadTemplate(TEMPLATESPATH + stuffTemplate + ".tott");

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

                AddTiles(BlocksNorth, 5, Orientation.North, StuffTemplate);
                AddTiles(BlocksSouth, 5, Orientation.South, StuffTemplate);
                AddTiles(BlocksWest, 5, Orientation.West, StuffTemplate);
                AddTiles(BlocksEast, 5, Orientation.East, StuffTemplate);
            }

        }

        public void AddTiles(List<Block> Blocks, int nbTiles, Orientation ori, Template tTemplate)
        {
            Block lastBlock;
            Vector2 tDimensions;


            Array sizeValues;
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

                    randomSize = (TileSize)sizeValues.GetValue(StaticRandom.Instance.Next(0, sizeValues.Length));
                }
                else
                {
                    lastBlock = BlocksBase[0];

                    //randomSize = TileSize.Medium;
                    randomSize = (TileSize)sizeValues.GetValue(StaticRandom.Instance.Next(0, sizeValues.Length - 3));
                }
                
                tDimensions = GetSize(randomSize);

                string sBCoords = "";
                switch (ori)
                {
                    case Orientation.North:
                        if (Blocks.Count == 0)
                            tX = lastBlock.Position.X + (lastBlock.Dimensions.X - tDimensions.X) / 2;
                        else
                            tX = StaticRandom.Instance.Next((int)lastBlock.Position.X - (int)lastBlock.Dimensions.X + 96, (int)lastBlock.Position.X + (int)lastBlock.Dimensions.X - 96);

                        tY = lastBlock.Position.Y - tDimensions.Y;
                        sBCoords = "N:" + Blocks.Count.ToString();
                        break;
                    case Orientation.South:
                        if (Blocks.Count == 0)
                            tX = lastBlock.Position.X + (lastBlock.Dimensions.X - tDimensions.X) / 2;
                        else
                            tX = StaticRandom.Instance.Next((int)lastBlock.Position.X - (int)lastBlock.Dimensions.X + 96, (int)lastBlock.Position.X + (int)lastBlock.Dimensions.X - 96);
                        tY = lastBlock.Position.Y + lastBlock.Dimensions.Y;
                        sBCoords = "S:" + Blocks.Count.ToString();

                        break;
                    case Orientation.West:
                        if (Blocks.Count == 0)
                            tY = lastBlock.Position.Y + (lastBlock.Dimensions.Y - tDimensions.Y) / 2;
                        else
                            tY = StaticRandom.Instance.Next((int)lastBlock.Position.Y - (int)lastBlock.Dimensions.Y + 96, (int)lastBlock.Position.Y + (int)lastBlock.Dimensions.Y - 96);
                        tX = lastBlock.Position.X - tDimensions.X;
                        sBCoords = "W:" + Blocks.Count.ToString();

                        break;
                    case Orientation.East:
                        if (Blocks.Count == 0)
                            tY = lastBlock.Position.Y + (lastBlock.Dimensions.Y - tDimensions.Y) / 2;
                        else
                            tY = StaticRandom.Instance.Next((int)lastBlock.Position.Y - (int)lastBlock.Dimensions.Y + 96, (int)lastBlock.Position.Y + (int)lastBlock.Dimensions.Y - 96);
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

                int indexTemplate = StaticRandom.Instance.Next(0, StuffTemplate.TTemplates.Count);

                newBlock.TileTemplate = StuffTemplate.TTemplates[indexTemplate];
                newBlock.GenerateStuff();
                Blocks.Add(newBlock);
            }
            
        }

        private static Vector2 GetSize(TileSize randomSize)
        {
            Vector2 tDimensions;

            switch (randomSize)
            {
                case TileSize.Tiny:
                    tDimensions = new Vector2(StaticRandom.Instance.Next(144, 289), StaticRandom.Instance.Next(144, 289));
                    break;
                case TileSize.VerySmall:
                    tDimensions = new Vector2(StaticRandom.Instance.Next(240, 481), StaticRandom.Instance.Next(240, 481));
                    break;
                case TileSize.Small:
                    tDimensions = new Vector2(StaticRandom.Instance.Next(384, 769), StaticRandom.Instance.Next(384, 769));
                    break;
                case TileSize.Medium:
                    tDimensions = new Vector2(StaticRandom.Instance.Next(432, 865), StaticRandom.Instance.Next(432, 865));
                    break;
                case TileSize.Large:
                    tDimensions = new Vector2(StaticRandom.Instance.Next(576, 1153), StaticRandom.Instance.Next(576, 1153));
                    break;
                case TileSize.VeryLarge:
                    tDimensions = new Vector2(StaticRandom.Instance.Next(816, 1441), StaticRandom.Instance.Next(816, 1441));
                    break;
                case TileSize.Huge:
                    tDimensions = new Vector2(StaticRandom.Instance.Next(1200, 1681), StaticRandom.Instance.Next(1200, 1681));
                    break;
                case TileSize.HughMongus:
                    tDimensions = new Vector2(StaticRandom.Instance.Next(1440, 1921), StaticRandom.Instance.Next(1440, 1921));
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

        public void Draw(SpriteBatch spriteBatch, SpriteFont textureFont)
        {

            foreach (Block tB in BlocksBase)
                tB.Draw(spriteBatch, textureFont);

            DrawBlock(BlocksNorth, spriteBatch, textureFont);
            DrawBlock(BlocksSouth, spriteBatch, textureFont);
            DrawBlock(BlocksWest, spriteBatch, textureFont);
            DrawBlock(BlocksEast, spriteBatch, textureFont);
            //foreach (Block tB in BlocksNorth)
            //    tB.Draw(spriteBatch, textureFont); 
            //foreach (Block tB in BlocksSouth)
            //    tB.Draw(spriteBatch, textureFont);
            //foreach (Block tB in BlocksWest)
            //    tB.Draw(spriteBatch, textureFont);
            //foreach (Block tB in BlocksEast)
            //    tB.Draw(spriteBatch, textureFont);
        }

        private void DrawBlock(List<Block> tBlocks, SpriteBatch spriteBatch, SpriteFont textureFont)
        {
            foreach (Block tB in tBlocks)
            {
                if (!tB.ImgInitiated)
                {
                    foreach (TileTemplate tTT in StuffTemplate.TTemplates)
                        if (tTT.Name == tB.TileTemplate.Name)
                        {
                            tB.InitiateImages(tTT);
                            break;
                        }
                }
                tB.Draw(spriteBatch, textureFont);
            }
        }
    }
}
