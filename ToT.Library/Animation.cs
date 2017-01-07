using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ToT.Library
{
    public class Animation
    {
        public Texture2D Image { get; set; }
        public Vector2 Frames { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Origin { get; set; }
        public int fX { get; set; }
        public int fY { get; set; }
        public int lastFX { get; set; }
        public int lastFY { get; set; }
        public bool Active { get; set; }
        public AnimationType Type { get; set; }
        public Rectangle SourceRect { get; set; }
        Vector2 BaseFrames;
        
        private int frameCounter, switchFrame;
        public int FrameWidth
        {
            get
            {
                if (Frames.X != 0f)
                    return Image.Width / (int)Frames.X;
                else
                    return Image.Width;
            }
        }

        public int FrameHeight
        {
            get
            {
                if (Frames.Y != 0f)
                    return Image.Height / (int)Frames.Y;
                else
                    return Image.Height;
            }
        }


        public Animation(AnimationType tType = AnimationType.None)
        {
            fX = 0;
            fY = 0;
            lastFX = 0;
            lastFY = 0;

            Type = tType;
            BaseFrames = new Vector2(1, 1);

            frameCounter = 0;
            switchFrame = 100;
        }

        public void Init(string imgPath, GraphicsDevice tGD)
        {
            FileStream filestream = new FileStream(imgPath, FileMode.Open);
            Texture2D myTexture = Texture2D.FromStream(tGD, filestream);

            Image = myTexture;
            filestream.Close();

            InitAnim();
        }

        public void Init(Texture2D tImage)
        {
            Image = tImage;
            if (Image != null)
                InitAnim();
        }

        public void InitAnim()
        {
            if (Frames != BaseFrames)
                SourceRect = new Rectangle(fX * FrameWidth, fY * FrameHeight, FrameWidth, FrameHeight);
            else
                SourceRect = new Rectangle(0, 0, Image.Width, Image.Height);

            Size = new Vector2(SourceRect.Width, SourceRect.Height);

            Origin = Size / 2;
        }

        public void Update()
        {
            switch(Type)
            {
                case AnimationType.Spritesheet:
                        if (Active)
                        {
                            frameCounter += 16;
                            if (Frames.X > 1)
                            {
                                if (frameCounter >= switchFrame)
                                {
                                    frameCounter = 0;
                                    fX++;

                                    if (fX >= Frames.X)
                                        fX = 0;
                                }

                            }
                        }
                        else
                        {
                            frameCounter = 0;
                            fX = 1;
                        }
                    if (lastFX != fX || lastFY != fY)
                    {
                        SourceRect = new Rectangle(fX * (int)Size.X, fY * (int)Size.Y, (int)Size.X, (int)Size.Y);
                        lastFX = fX;
                        lastFY = fY;
                    }
                        
                    break;
                default:
                    
                    break;
            }
        }


    }
}
