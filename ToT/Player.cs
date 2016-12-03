using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ToT.Library;

namespace ToT
{
    public class Player
    {
        public string name;
        public Vector2 position;
        public Rectangle defaultRect,
                         drawRect;
        public List<Prop> PlayerProps;

        public Texture2D healthbar;

        public static KeyboardState ActualKeyState;
        public static MouseState ActualMouseState;

        public static List<Player> players = new List<Player>();
        public PlayerClass CurrentClass { get; set; }
        public float Rotation { get; set; }

        public float Pain { get; set; }
        public float LastPain { get; set; }
        public Player(string name, Vector2 pozition, Rectangle defaultRect, Rectangle drawRect, PlayerClass pClass = PlayerClass.Noob)
        {
            this.name = name;
            this.position = pozition;
            this.defaultRect = defaultRect;
            this.drawRect = drawRect;

            PlayerProps = new List<Prop>();
            Init(pClass);
        }

        public void Init(PlayerClass pClass)
        {
            //Initiate a player of the pClass player class according to some bs templates.
            //Maybe use an editor later.
            PlayerProps.Clear();


            Random tRand = new Random();

            Pain = tRand.Next(0, 10);
            LastPain = Pain;

            switch(pClass)
            {
                case PlayerClass.Noob:
                    PlayerProps.Add(new Prop("Health", 10));
                    PlayerProps.Add(new Prop("Energy", 0));
                    PlayerProps.Add(new Prop("Speed", 5));
                    break;
                case PlayerClass.Warrior:
                    PlayerProps.Add(new Prop("Level", 1));
                    PlayerProps.Add(new Prop("Health", 20));
                    PlayerProps.Add(new Prop("Energy", 5));
                    PlayerProps.Add(new Prop("Speed", 6));
                    break;
                case PlayerClass.Archer:
                    PlayerProps.Add(new Prop("Level", 1));
                    PlayerProps.Add(new Prop("Health", 15));
                    PlayerProps.Add(new Prop("Energy", 5));
                    PlayerProps.Add(new Prop("Speed", 7));
                    break;
                case PlayerClass.Mage:
                    PlayerProps.Add(new Prop("Level", 1));
                    PlayerProps.Add(new Prop("Health", 10));
                    PlayerProps.Add(new Prop("Energy", 20));
                    PlayerProps.Add(new Prop("Speed", 7));
                    break;
                case PlayerClass.Druid:
                    PlayerProps.Add(new Prop("Level", 1));
                    PlayerProps.Add(new Prop("Health", 15));
                    PlayerProps.Add(new Prop("Energy", 10));
                    PlayerProps.Add(new Prop("Speed", 6));
                    break;
                case PlayerClass.Tech:
                    PlayerProps.Add(new Prop("Level", 1));
                    PlayerProps.Add(new Prop("Health", 15));
                    PlayerProps.Add(new Prop("Energy", 15));
                    PlayerProps.Add(new Prop("Speed", 6));
                    break;
                default:
                    break;
            }
        }

        public Prop GetProp(string propName)
        {
            //Returns the propName property
            foreach (Prop tP in PlayerProps)
                if (tP.Name == propName)
                    return tP;
            return null;
        }

        public float GetPropLevel(string propName)
        {
            //Returns the level of the propName property
            foreach (Prop tP in PlayerProps)
                if (tP.Name == propName)
                    return tP.Level;
            return 0;
        }

        public float SetPropLevel(string propName, float propLevel)
        {
            //Sets the level of the propName property
            foreach (Prop tP in PlayerProps)
                if (tP.Name == propName)
                {
                    tP.Level = propLevel;
                    return tP.Level;
                }
            PlayerProps.Add(new Prop(propName, propLevel));
            return propLevel;
        }

        public static void Update(Camera pCam)
        {
            ActualKeyState = Keyboard.GetState();
            ActualMouseState = Mouse.GetState();
            
            foreach (Player p in players)
            {
                p.defaultRect.X = (int)p.position.X;
                p.defaultRect.Y = (int)p.position.Y;

                //This step is very simple, just sending a Player state
                if (p.name.Equals(TextInput.text)) //If the player's name is equal to the TextInput your name.
                {
                    Vector2 mousePosition = new Vector2(ActualMouseState.X, ActualMouseState.Y);
                    //p.Rotation = (float)Math.Atan2((double)ActualMouseState.Position.Y - ((16) - pCam.Position.Y), (double)ActualMouseState.Position.X - ((p.position.X + 16) - pCam.Position.X)); //this will return the angle(in radians) from sprite to mouse.

                    Vector2 dPos = ((p.position) - pCam.Position) - mousePosition;

                    p.Rotation = (float)Math.Atan2(dPos.Y, dPos.X);

                    float fSpeed = p.GetPropLevel("Speed");
                    if (ActualKeyState.IsKeyDown(Keys.Right) || ActualKeyState.IsKeyDown(Keys.D))
                        p.position.X += fSpeed;
                    if (ActualKeyState.IsKeyDown(Keys.Left) || ActualKeyState.IsKeyDown(Keys.A))
                        p.position.X -= fSpeed;
                    if (ActualKeyState.IsKeyDown(Keys.Up) || ActualKeyState.IsKeyDown(Keys.W))
                        p.position.Y -= fSpeed;
                    if (ActualKeyState.IsKeyDown(Keys.Down) || ActualKeyState.IsKeyDown(Keys.S))
                        p.position.Y += fSpeed;

                    Network.outmsg = Network.Client.CreateMessage();
                    Network.outmsg.Write("move");
                    Network.outmsg.Write(p.name);
                    Network.outmsg.Write((int)p.position.X);
                    Network.outmsg.Write((int)p.position.Y);
                    Network.outmsg.Write((float)p.Rotation);
                    Network.outmsg.Write((float)p.Pain);

                    Network.Client.SendMessage(Network.outmsg, NetDeliveryMethod.Unreliable);
                }
            }
        }
    }
}
