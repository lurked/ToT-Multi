using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using Microsoft.Xna.Framework;

namespace ToT
{
    class Network
    {
        public static NetClient Client;
        public static NetPeerConfiguration Config;
        /*public*/
        static NetIncomingMessage incmsg;
        public static NetOutgoingMessage outmsg;

        public static void Update()
        {
            //The biggest difference is that the client side of things easier, 
            //since we will only consider the amount of player object is created, 
            //so there is no keeping track of separate "Server.Connections" as the server side.
            while ((incmsg = Client.ReadMessage()) != null)
            {
                switch (incmsg.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        {
                            string headStringMessage = incmsg.ReadString();

                            switch (headStringMessage)
                            {
                                case "connect":
                                    {
                                        string name = incmsg.ReadString();
                                        int x = incmsg.ReadInt32();
                                        int y = incmsg.ReadInt32();

                                        //Another way to filter out the players with the same name, 
                                        //where the first step in any case is added to the player, 
                                        //and then check the second round with a double for loop that is in agreement with two players.

                                        Player.players.Add(new Player(name, new Vector2(x, y), new Rectangle(0, 0, 20, 40), new Rectangle(0, 0, 20, 40)));

                                        for (int i1 = 0; i1 < Player.players.Count; i1++)
                                        {
                                            for (int i2 = /*0*/i1 + 1; i2 < Player.players.Count; i2++)
                                            {
                                                if (i1 != i2 && Player.players[i1].name.Equals(Player.players[i2].name))
                                                {
                                                    Player.players.RemoveAt(i1);
                                                    i1--;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case "move":
                                    {
                                        try
                                        {
                                            string name = incmsg.ReadString();
                                            int x = incmsg.ReadInt32();
                                            int y = incmsg.ReadInt32();

                                            for (int i = 0; i < Player.players.Count; i++)
                                            {
                                                //It is important that you only set the value of the player, if it is not yours, 
                                                //otherwise it would cause lagg (because you'll always be first with yours, and there is a slight delay from server-client).
                                                //Of course, sometimes have to force the server to the actual position of the player, otherwise could easily cheat.
                                                if (Player.players[i].name.Equals(name) && Player.players[i].name != TextInput.text)
                                                {
                                                    Player.players[i].position = new Vector2(x, y);
                                                    break;
                                                }
                                            }
                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                    }
                                    break;

                                case "disconnect": //Clear enough :)
                                    {
                                        string name = incmsg.ReadString();

                                        for (int i = 0; i < Player.players.Count; i++)
                                        {
                                            if (Player.players[i].name.Equals(name))
                                            {
                                                Player.players.RemoveAt(i);
                                                i--;
                                                break;
                                            }
                                        }
                                    }
                                    break;

                                case "deny": //If the name on the message is the same as ours
                                    {
                                        ToTClient.HeadText = "This name is already taken:";
                                        ToTClient.TextCanWrite = true;
                                        Player.players.Clear();
                                    }
                                    break;
                            }
                        }
                        break;
                }
                Client.Recycle(incmsg);
            }
        }
    }
}
