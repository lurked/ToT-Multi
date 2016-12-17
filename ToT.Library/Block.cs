using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ToT.Library
{
    public class Block
    {
        public Vector2 Position { get; set; }
        public Vector2 Dimensions { get; set; }
        public int Level { get; set; }
        public string TemplateName { get; set; }
        public Texture2D MainBlockRect { get; set; }
        public string Coords { get; set; }
        public bool HasPlayer { get; set; }
        private Color backColor;
        public Block()
        {
            
        }

        public void Update(GameTime gameTime)
        {
        }

        public void UpdateServer(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
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
        }
    }
}
