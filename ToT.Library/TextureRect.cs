using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ToT.Library
{

    public class TextureRect
    {
        public Texture2D RectTexture { get; set; }
        public Vector2 Dimensions { get; set; }
        public Color RectColor { get; set; }
        public Color BorderColor { get; set; }
        public int BorderWidth { get; set; }
        public TextureRectType Type { get; set; }


        public TextureRect()
        {

        }

        public TextureRect(SpriteBatch spriteBatch, Vector2 dimensions, Color tColor, int borderWidth = 0, TextureRectType rectType = TextureRectType.Basic, float percent = 1f)
        {
            Dimensions = dimensions;
            RectColor = tColor;
            BorderColor = Color.Black;
            if (RectTexture == null)
            {
                RectTexture = new Texture2D(spriteBatch.GraphicsDevice, (int)dimensions.X, (int)dimensions.Y);

                Color[] rectData = null;
                if (rectData == null)
                {
                    rectData = new Color[(int)Dimensions.X * (int)Dimensions.Y];
                    for (int j = 0; j < rectData.Length; ++j)
                    {
                        switch(rectType)
                        {
                            case TextureRectType.PercentageBar:
                                if (j <= dimensions.X * borderWidth && borderWidth > 0)
                                        rectData[j] = BorderColor;
                                else if (j >= dimensions.X * dimensions.Y - dimensions.X * borderWidth && borderWidth > 0)
                                {
                                    rectData[j] = BorderColor;
                                }
                                else
                                {
                                    string _coords = "";
                                    int tX = 0;
                                    int tY = 0;

                                    _coords = (j / dimensions.X).ToString();
                                    string[] split = _coords.Split('.');
                                    tY = int.Parse(split[0]);
                                    tX = j - tY * (int)dimensions.X;
                                    if ((tX < borderWidth || tX >= dimensions.X - borderWidth) && borderWidth > 0)
                                        rectData[j] = BorderColor;
                                    else
                                    {
                                        //Checks if the current X is bigger than the percent of the rectangle's width
                                        if (rectType == TextureRectType.PercentageBar && tX >= (dimensions.X) * percent)
                                        {
                                            rectData[j] = Color.Red;
                                        }
                                        else
                                            rectData[j] = RectColor;
                                    }
                                }
                                break;
                            default:
                                if (j <= dimensions.X * borderWidth && borderWidth > 0)
                                    rectData[j] = BorderColor;
                                else if (j >= dimensions.X * dimensions.Y - dimensions.X * borderWidth && borderWidth > 0)
                                {
                                    rectData[j] = BorderColor;
                                }
                                else
                                {
                                    string _coords = "";
                                    int tX = 0;
                                    int tY = 0;

                                    _coords = (j / dimensions.X).ToString();
                                    string[] split = _coords.Split('.');
                                    tY = int.Parse(split[0]);
                                    tX = j - tY * (int)dimensions.X;
                                    if ((tX < borderWidth || tX >= dimensions.X - borderWidth) && borderWidth > 0)
                                        rectData[j] = BorderColor;
                                    else
                                        rectData[j] = RectColor;
                                }
                                break;
                        }
                        
                    }
                }
                RectTexture.SetData(rectData);
            }
        }

    }
}
