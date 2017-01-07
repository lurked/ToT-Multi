using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ToT.Library
{
    public class NPC
    {
        public string Name { get; set; }
        public NPCType NpcType { get; set; }
        [Browsable(false)]
        public string TextureImg { get; set; }
        public Vector2 ImgFrames { get; set; }
        public List<Prop> Props { get; set; }
        public int SpawnMin { get; set; }
        public int SpawnMax { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public float Rotation { get; set; }

        [Browsable(false)]
        private Rectangle rect;

        [Browsable(false)]
        public Vector2 Position { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public bool ToDraw { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public Texture2D Img { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public Animation MainAnim { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public Rectangle Rect
        { 
            get
            {
                Rectangle newRect = new Rectangle((int)Position.X, (int)Position.Y, Img.Width, Img.Height);
                if (rect == null || rect != newRect)
                {
                    rect = newRect;
                }
                return rect;
            }
            set
            {
                rect = value;   
            }
        }

        public Rectangle GetRect(Vector2 blockPos)
        {
            Rectangle newRect;
            if (Img != null)
                newRect = new Rectangle((int)(blockPos.X + Position.X), (int)(blockPos.Y + Position.Y), Img.Width, Img.Height);
            else newRect = new Rectangle();

            return newRect;
        }


        public NPC()
        {
            Props = new List<Prop>();
            SpawnMin = 1;
            SpawnMax = 1;
            //ImgFrames = new Vector2(1, 1);
            Rotation = 0f;
            MainAnim = new Animation(AnimationType.Spritesheet);
        }

        public NPC(string name, NPCType npcType)
        {
            Name = name;
            NpcType = npcType;

            SpawnMin = 1;
            SpawnMax = 1;
            //ImgFrames = new Vector2(1, 1);
            Rotation = 0f;

            Props = new List<Prop>();

            MainAnim = new Animation(AnimationType.Spritesheet);
        }

        public void Update()
        {
            if (MainAnim.Image != null)
            {
                MainAnim.Update();
            }

        }

    }
}