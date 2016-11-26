using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ToT
{
    class Player
    {
        public string name;
        public Vector2 position;
        public Rectangle defaultRect,
                         drawRect;

        static KeyboardState ActualKeyState;

        public static List<Player> players = new List<Player>();

        public Player(string name,
                      Vector2 pozition,
                      Rectangle defaultRect,
                      Rectangle drawRect)
        {
            this.name = name;
            this.position = pozition;
            this.defaultRect = defaultRect;
            this.drawRect = drawRect;
        }

        public static void Update()
        {
            ActualKeyState = Keyboard.GetState();

            foreach (Player p in players)
            {
                p.defaultRect.X = (int)p.position.X;
                p.defaultRect.Y = (int)p.position.Y;

                //This step is very simple, just sending a Player state
                if (p.name.Equals(TextInput.text)) //If the player's name is equal to the TextInput your name.
                {
                    if (ActualKeyState.IsKeyDown(Keys.Right) || ActualKeyState.IsKeyDown(Keys.D))
                        p.position.X += 2;
                    if (ActualKeyState.IsKeyDown(Keys.Left) || ActualKeyState.IsKeyDown(Keys.A))
                        p.position.X -= 2;
                    if (ActualKeyState.IsKeyDown(Keys.Up) || ActualKeyState.IsKeyDown(Keys.W))
                        p.position.Y -= 2;
                    if (ActualKeyState.IsKeyDown(Keys.Down) || ActualKeyState.IsKeyDown(Keys.S))
                        p.position.Y += 2;

                    Network.outmsg = Network.Client.CreateMessage();
                    Network.outmsg.Write("move");
                    Network.outmsg.Write(p.name);
                    Network.outmsg.Write((int)p.position.X);
                    Network.outmsg.Write((int)p.position.Y);
                    Network.Client.SendMessage(Network.outmsg, NetDeliveryMethod.Unreliable);
                }
            }
        }
    }
}
