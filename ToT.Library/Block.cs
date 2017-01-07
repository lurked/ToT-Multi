using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace ToT.Library
{
    public class Block
    {
        public Vector2 Position { get; set; }
        public Vector2 Dimensions { get; set; }
        public int Level { get; set; }
        public string TemplateName { get; set; }
        public TileTemplate TileTemplate { get; set; }
        public Texture2D MainBlockRect { get; set; }
        public string Coords { get; set; }
        public bool HasPlayer { get; set; }
        public List<NPC> Enemies { get; set; }

        [JsonIgnore]
        public bool ImgInitiated { get; set; }

        private Color backColor;

        public Block()
        {
            Enemies = new List<NPC>();

        }

        public void Update(GameTime gameTime)
        {
            for(int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Update();
            }
        }

        public void UpdateServer(GameTime gameTime)
        {

        }

        public void GenerateStuff()
        {
            if (TileTemplate.Enemies.Count > 0)
            {
                int nbToSpawn = StaticRandom.Instance.Next(1, 4);
                for (int i = 0; i < nbToSpawn; i++)
                {
                    NPC randEnemy = new NPC();
                    randEnemy = TileTemplate.Enemies[StaticRandom.Instance.Next(0, TileTemplate.Enemies.Count)];
                    randEnemy.Position = new Vector2(StaticRandom.Instance.Next(10, (int)Dimensions.X - 64), StaticRandom.Instance.Next(10, (int)Dimensions.Y - 64));
                    randEnemy.ToDraw = true;
                    Enemies.Add(randEnemy);
                }
            }
        }

        public Texture2D GetTexture(string textureName, List<NPC> listNPCs)
        {
            foreach (NPC tN in listNPCs)
                if (tN.TextureImg == textureName)
                    return tN.Img;
            return null;
        }

        public void InitiateImages(TileTemplate tTemplate)
        {
            TileTemplate = tTemplate;
            ImgInitiated = true;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont textureFont)
        {
            if (MainBlockRect == null)
            {

                TextureRect tRect = new TextureRect(spriteBatch, Dimensions, Color.ForestGreen, 3);
                MainBlockRect = tRect.RectTexture;
            }
            if (HasPlayer)
                backColor = Color.DarkGreen;
            else
                backColor = Color.ForestGreen;
            spriteBatch.Draw(MainBlockRect, new Rectangle((int)Position.X, (int)Position.Y, (int)Dimensions.X, (int)Dimensions.Y), backColor);

            foreach (NPC tE in Enemies)
            {
                if (tE.MainAnim.Image == null)
                {
                    tE.MainAnim.Frames = tE.ImgFrames;
                    tE.MainAnim.Active = true;
                    tE.MainAnim.Init(GetTexture(tE.TextureImg, TileTemplate.Enemies));
                }
                if (tE.MainAnim.Image != null)
                {
                    //spriteBatch.Draw(tE.Img, tE.GetRect(Position), Color.White);

                    spriteBatch.Draw(tE.MainAnim.Image, tE.Position + Position, tE.MainAnim.SourceRect, Color.White, tE.Rotation, tE.MainAnim.Origin, 1f, SpriteEffects.None, 0.0f);
                }

                spriteBatch.DrawString(textureFont, tE.Name, tE.Position + Position, Color.Red);
            }
                
        }
    }
}
