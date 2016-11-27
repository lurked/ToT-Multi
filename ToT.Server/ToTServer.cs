using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Lidgren.Network;
using ToT.Library;


namespace ToT.Server
{
    public partial class totServerForm : Form
    {
        public World CurrentWorld { get; set; }
        public GameTime ServerGameTime { get; set; }
        TimeSpan MainLoopTS { get; set; }
        public totServerForm()
        {
            InitializeComponent();

            //creating a new network config, and starting the server (with "Network" class, created below)
            Network.Config = new NetPeerConfiguration("ToTNetwork"); // The server and the client program must also use this name, so that can communicate with each other.
            Network.Config.Port = 14242; //one port, if your PC it not using yet
            Network.Server = new NetServer(Network.Config);
            Network.Server.Start();

            AddLogEntry("Generating Current World..." + "\r\n");
            CurrentWorld = new World();
            CurrentWorld.Name = "Base World 01";
            AddLogEntry("Generation Complete." + "\r\n\r\n");

            AddLogEntry("Server started!" + "\r\n");
            AddLogEntry("Waiting for connections..." + "\r\n\r\n");

            ServerGameTime = new GameTime();
            MainLoopTS = new TimeSpan(0, 0, 0, 0, timer1.Interval);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ServerGameTime.TotalGameTime.Add(MainLoopTS);
            Network.Update(CurrentWorld);
            Player.Update();
            CurrentWorld.UpdateServer(ServerGameTime);
        }

        public static void AddLogEntry(string logText)
        {
            textBox1.AppendText(DateTime.Now.ToString() + ": " + logText);
        }
    }

    

    class Network // A Basics Network class
    {
        public static NetServer Server; //the Server
        public static NetPeerConfiguration Config; //the Server config
        /*public*/
        static NetIncomingMessage incmsg; //the incoming messages that server can read from clients
        public static NetOutgoingMessage outmsg; //the outgoing messages that clients can receive and read
        /*public*/
        static bool playerRefresh; //below for explanation...

        public static void Update(World tCurrentWorld)
        {
            while ((incmsg = Server.ReadMessage()) != null) //while the message is received, and is not equal to null...
            {
                switch (incmsg.MessageType) //There are several types of messages (see the Lidgren Basics tutorial), but it is easier to just use it the most important thing the "Data".
                {
                    case NetIncomingMessageType.Data:
                        {
                            //////////////////////////////////////////////////////////////
                            // You must create your own custom protocol with the        //
                            // server-client communication, and data transmission.      //
                            //////////////////////////////////////////////////////////////


                            // 1. step: The first data/message (string or int) tells the program to what is going on, that is what comes to doing.
                            // 2. step: The second tells by name (string) or id (int) which joined client(player) or object(bullets, or other dynamic items) to work.
                            // 3. step: The other data is the any some parameters you want to use, and this is setting and refhreshing the object old (player or item) state.

                            // Now this example I'm use to string (yes you can saving the bandwidth with all messages, if you use integer)
                            string headStringMessage = incmsg.ReadString(); //the first data (1. step)

                            switch (headStringMessage) //and I'm think this is can easyli check what comes to doing
                            {
                                case "connect": //if the firs message/data is "connect"
                                    {
                                        string name = incmsg.ReadString(); //Reading the 2. message who included the name (you can use integer, if you want to store the players in little data)
                                        int x = incmsg.ReadInt32(); //Reading the x position
                                        int y = incmsg.ReadInt32(); // -||- y postion

                                        playerRefresh = true; //just setting this "True"

                                        // Now check to see if you have at least one of our players, the subsequent attempts to connect with the same name. 
                                        for (int i = 0; i < Player.players.Count; i++)
                                        {
                                            if (Player.players[i].name.Equals(name)) //If its is True...
                                            {
                                                outmsg = Server.CreateMessage(); //The Server creating a new outgoing message
                                                outmsg.Write("deny"); //and this moment writing this to one message "deny" (the rest of the ClientAplication in interpreting)

                                                //Sending the message
                                                //parameters:
                                                //1. the message which we have written
                                                //2. whom we send (Now just only the person who sent the message to the server)
                                                //3. delivery reliability (Since this is an important message, so be sure to be delivered)
                                                //4. The channel on which the message is sent (I do not deal with it, just give the default value)
                                                Server.SendMessage(outmsg, incmsg.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);

                                                System.Threading.Thread.Sleep(100); //a little pause the current process to make sure the message is sent to the client before they break down in contact with him.
                                                incmsg.SenderConnection.Disconnect("bye"); //ends the connection with the client who sent the message, and you can writing the any string message if you want
                                                playerRefresh = false; //Now the "if" its is True, we disable the playerRefhres bool
                                                break;
                                            }
                                        }

                                        // but if the above check is false, then the following happens:
                                        if (playerRefresh == true)
                                        {
                                            System.Threading.Thread.Sleep(100); //A little pause to make sure you connect the client before performing further operations
                                            Player.players.Add(new Player(name, new Vector2(x, y), 0)); //Add to player messages received as a parameter
                                            totServerForm.AddLogEntry(name + " connected." + "\r\n");

                                            for (int i = 0; i < Player.players.Count; i++)
                                            {
                                                // Write a new message with incoming parameters, and send the all connected clients.
                                                outmsg = Server.CreateMessage();

                                                outmsg.Write("connect");
                                                outmsg.Write(Player.players[i].name);
                                                outmsg.Write((int)Player.players[i].pozition.X);
                                                outmsg.Write((int)Player.players[i].pozition.Y);

                                                Server.SendMessage(Network.outmsg, Network.Server.Connections, NetDeliveryMethod.ReliableOrdered, 0);
                                            }
                                        }

                                        totServerForm.label1.Text = "Players: " + Player.players.Count;
                                    }
                                    break;

                                case "move": //The moving messages
                                    {
                                        //This message is treated as plain UDP (NetDeliveryMethod.Unreliable)
                                        //The motion is not required to get clients in every FPS.
                                        //The exception handling is required if the message can not be delivered in full, 
                                        //just piece, so this time the program does not freeze.
                                        try
                                        {
                                            string name = incmsg.ReadString();
                                            int x = incmsg.ReadInt32();
                                            int y = incmsg.ReadInt32();

                                            for (int i = 0; i < Player.players.Count; i++)
                                            {
                                                if (Player.players[i].name.Equals(name))
                                                {
                                                    Player.players[i].pozition = new Vector2(x, y);
                                                    Player.players[i].timeOut = 0; //below for explanation (Player class)...
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
                                case "getworld":
                                    string playerName = incmsg.ReadString();

                                    totServerForm.AddLogEntry(playerName + " - GetWorld Request\r\n");
                                    outmsg = Server.CreateMessage();
                                    outmsg.Write("getworld");
                                    outmsg.Write(playerName);
                                    outmsg.WriteAllProperties(tCurrentWorld);
                                    Server.SendMessage(Network.outmsg, incmsg.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                                    totServerForm.AddLogEntry(playerName + " - GetWorld Request Answered\r\n\r\n");
                                    break;
                                case "disconnect": //If the client want to disconnect from server at manually
                                    {
                                        string name = incmsg.ReadString();

                                        for (int i = 0; i < Player.players.Count; i++)
                                        {
                                            if (Player.players[i].name.Equals(name)) //If the [index].name equaled the incoming message name...
                                            {
                                                Server.Connections[i].Disconnect("bye"); //The server disconnect the correct client with index
                                                System.Threading.Thread.Sleep(100); //Again a small pause, the server disconnects the client actually
                                                totServerForm.AddLogEntry(name + " disconnected.\r\n");

                                                if (Server.ConnectionsCount != 0) //After if clients count not 0
                                                {
                                                    //Sending the disconnected client name to all online clients
                                                    outmsg = Server.CreateMessage();
                                                    outmsg.Write("disconnect");
                                                    outmsg.Write(name);
                                                    Server.SendMessage(Network.outmsg, Server.Connections, NetDeliveryMethod.ReliableOrdered, 0);
                                                }

                                                Player.players.RemoveAt(i); //And remove the player object
                                                i--;
                                                break;
                                            }
                                        }

                                        totServerForm.label1.Text = "Players: " + Player.players.Count;
                                    }
                                    break;
                            }
                        }
                        break;
                }
                Server.Recycle(incmsg); //All messages processed at the end of the case, delete the contents.
            }
        }
    }

    class Player //The Player class and instant constructor
    {
        public string name;
        public Vector2 pozition;
        public int timeOut; //This disconnects the client, even if no message from him within a certain period of time and not been reset value.

        public static List<Player> players = new List<Player>();

        public Player(string name,
                      Vector2 pozition,
                      int timeOut)
        {
            this.name = name;
            this.pozition = pozition;
            this.timeOut = timeOut;
        }

        public static void Update()
        {
            if (Network.Server.ConnectionsCount == players.Count) //If the number of the player object actually corresponds to the number of connected clients.
            {
                for (int i = 0; i < players.Count; i++)
                {
                    players[i].timeOut++; //This data member continuously counts up with every frame/tick.

                    //The server simply always sends data to the all players current position of all clients.
                    Network.outmsg = Network.Server.CreateMessage();

                    Network.outmsg.Write("move");
                    Network.outmsg.Write(players[i].name);
                    Network.outmsg.Write((int)players[i].pozition.X);
                    Network.outmsg.Write((int)players[i].pozition.Y);

                    Network.Server.SendMessage(Network.outmsg, Network.Server.Connections, NetDeliveryMethod.Unreliable, 0);

                    if (players[i].timeOut > 180) //If this is true, so that is the player not sent information with himself
                    {
                        //The procedure will be the same as the above when "disconnect" message
                        Network.Server.Connections[i].Disconnect("bye");
                        totServerForm.AddLogEntry(players[i].name + " is timed out." + "\r\n");
                        System.Threading.Thread.Sleep(100);

                        if (Network.Server.ConnectionsCount != 0)
                        {
                            Network.outmsg = Network.Server.CreateMessage();

                            Network.outmsg.Write("disconnect");
                            Network.outmsg.Write(players[i].name);

                            Network.Server.SendMessage(Network.outmsg, Network.Server.Connections, NetDeliveryMethod.ReliableOrdered, 0);
                        }

                        players.RemoveAt(i);
                        i--;
                        totServerForm.label1.Text = "Players: " + players.Count;
                        break;
                    }
                }
            }
        }
    }
}
