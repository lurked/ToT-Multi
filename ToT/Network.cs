using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using ToT.Library;

namespace ToT
{
    class Network
    {
        public static NetClient Client;
        public static NetPeerConfiguration Config;
        /*public*/
        static NetIncomingMessage incmsg;
        public static NetOutgoingMessage outmsg;
        public static World CurrentWorld { get; set; }

        public static int Update(string playerName)
        {
            int index = -1;
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

                                        Player.players.Add(new Player(name, new Vector2(x, y), new Rectangle(0, 0, 48, 48), new Rectangle(0, 0, 48, 48)));

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
                                            float rot = incmsg.ReadFloat(); // -||- player's angle
                                            float pain = incmsg.ReadFloat(); // -||- player's pain

                                            for (int i = 0; i < Player.players.Count; i++)
                                            {
                                                //It is important that you only set the value of the player, if it is not yours, 
                                                //otherwise it would cause lagg (because you'll always be first with yours, and there is a slight delay from server-client).
                                                //Of course, sometimes have to force the server to the actual position of the player, otherwise could easily cheat.
                                                if (Player.players[i].name.Equals(name) && Player.players[i].name != TextInput.text)
                                                {
                                                    Player.players[i].position = new Vector2(x, y);
                                                    Player.players[i].Rotation = rot;
                                                    Player.players[i].Pain = pain;
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

                                case "disconnect":
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
                                        for (int i = 0; i < Player.players.Count; i++)
                                            if (Player.players[i].name.Equals(playerName))
                                            {
                                                index = i;
                                                break;
                                            }
                                    }
                                    break;
                                case "getworld":
                                    {
                                        string name = incmsg.ReadString();
                                        World tWorld = new World();
                                        FileManager fmWorld = new FileManager();
                                        string srlzdWorld;
                                        incmsg.ReadString(out srlzdWorld);
                                        tWorld = fmWorld.DeserializeWorld(srlzdWorld);

                                        CurrentWorld = tWorld;

                                    }
                                    break;
                                case "deny": //If the name on the message is the same as ours
                                    ToTClient.HeadText = "This name is already taken:";
                                    ToTClient.gameState = ClientState.Login;
                                    Player.players.Clear();
                                    break;
                            }
                        }
                        break;
                }
                Client.Recycle(incmsg);
            }
            return index;
        }
    }
}
