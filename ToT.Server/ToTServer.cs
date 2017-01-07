using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Lidgren.Network;
using ToT.Library;


namespace ToT.Server
{
    public partial class totServerForm : Form
    {
        public const string WORLDPATH = "C:/Prog/ToT/ToT/Worlds/";
        public const string PLAYERSPATH = "C:/Prog/ToT/ToT/Worlds/Players/";
        public const string TEMPLATESPATH = "C:/Prog/ToT/ToT/Templates/";
        public const string IMAGESPATH = "C:/Prog/ToT/ToT/Data/Img/";
        public World CurrentWorld { get; set; }
        public Template CurrentTemplate { get; set; }
        public TileTemplate CurrentTTemplate { get; set; }
        public GameTime ServerGameTime { get; set; }
        TimeSpan MainLoopTS { get; set; }
        FileManager fileManager;
        List<NPC> CurrTempEnemies;
        public totServerForm()
        {
            InitializeComponent();

            InitGameModes();

            fileManager = new FileManager();

            InitWorlds();

            InitToolkit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ServerGameTime.TotalGameTime.Add(MainLoopTS);
            Network.Update(CurrentWorld);
            Player.Update();
            CurrentWorld.UpdateServer(ServerGameTime);
        }

        public void StartServer()
        {
            //creating a new network config, and starting the server (with "Network" class, created below)
            Network.Config = new NetPeerConfiguration("ToTNetwork"); // The server and the client program must also use this name, so that can communicate with each other.
            Network.Config.Port = 14242; //one port, if your PC it not using yet
            Network.Server = new NetServer(Network.Config);
            Network.Server.Start();

            AddLogEntry("Starting Server...\r\n\r\n");
            AddLogEntry("Game Mode : " + cboGameMode.Text + "\r\n\r\n");

            if (cboWorld.Text == "New World")
            {
                AddLogEntry("Generating Current World : " + txtWorldName.Text + "...\r\n\r\n");
                CurrentWorld = new World(txtWorldName.Text, WorldAction.GenerateNew, cboTemplate.Text);
                //CurrentWorld.Name = "Base World 01";

                AddLogEntry("Generation Complete." + "\r\n\r\n");

            }
            else
            {
                AddLogEntry("Generating Current World : " + cboWorld.Text + "...\r\n\r\n");
                //CurrentWorld = new World(cboWorld.Text);
                CurrentWorld = fileManager.LoadWorld(WORLDPATH + cboWorld.Text + ".totw");

                AddLogEntry("Generation Complete." + "\r\n\r\n");

            }
            AddLogEntry("Server started!" + "\r\n");
            AddLogEntry("Waiting for connections..." + "\r\n\r\n");

            ServerGameTime = new GameTime(); 
            MainLoopTS = new TimeSpan(0, 0, 0, 0, timer1.Interval);
            timer1.Enabled = true;
            timer1.Start();
            btnSaveWorld.Enabled = true;
        }

        public void SaveCurrentWorld()
        {
            AddLogEntry("Saving current world.\r\n\r\n");

            fileManager.SaveToFile(fileManager.SerializeWorld(CurrentWorld), WORLDPATH + CurrentWorld.Name + ".totw");
            foreach (Player p in Player.players)
                fileManager.SaveToFile(JsonConvert.SerializeObject(p), PLAYERSPATH + p.name + ".totp");

            AddLogEntry("Closing current world..." + "\r\n");
        }

        public void StopServer()
        {
            timer1.Stop();
            timer1.Enabled = false;

            SaveCurrentWorld();
            Player.players.Clear();
            AddLogEntry("Server shut down." + "\r\n");

            Network.Server.Shutdown("Server stopped manually by host.");
            MainLoopTS = new TimeSpan(0, 0, 0, 0, timer1.Interval);

            InitWorlds();
            btnSaveWorld.Enabled = false;
        }

        public void InitGameModes()
        {
            var values = Enum.GetValues(typeof(GameMode));

            foreach (GameMode tGM in values)
                cboGameMode.Items.Add(tGM.ToString());

            cboGameMode.Text = "Adventure";
        }

        public static void AddLogEntry(string logText)
        {
            textBox1.AppendText(DateTime.Now.ToString() + ": " + logText);
        }

        public void InitWorlds()
        {
            //Loading Worlds to select from in the server tab
            cboWorld.Items.Clear();
            List<string> tWorlds = fileManager.GetWorlds(WORLDPATH);
            cboWorld.Items.Add("New World");
            foreach (string tS in tWorlds)
                cboWorld.Items.Add(tS);

            cboWorld.Text = "New World";

            //Loading Templates to use for the select world.
            cboTemplate.Items.Clear();
            List<string> tTemplates = fileManager.GetWorlds(TEMPLATESPATH);
            foreach (string tS in tTemplates)
                cboTemplate.Items.Add(tS);

            cboTemplate.Text = "ToTDefault_01";
        }

        public void InitToolkit()
        {
            CurrentTemplate = new Template("BaseTotTemplate01");

            FillItemsList(CurrentTemplate);
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (btnStartServer.Text == "Start") 
            {
                if (txtWorldName.Text == "" && cboWorld.Text == "New World")
                {
                    MessageBox.Show("Please enter a name to create a new world.");
                }
                else
                {
                    btnStartServer.Text = "Stop";
                    StartServer();
                }

            }
            else
            {
                btnStartServer.Text = "Start";
                StopServer();
            }

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Process.Start(txtClientPath.Text);
        }

        private void totServerForm_Load(object sender, EventArgs e)
        {
        }

        private void cboWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWorld.Text == "New World")
                groupWorldSettings.Enabled = true;
            else
                groupWorldSettings.Enabled = false;
        }

        private void btnSaveWorld_Click(object sender, EventArgs e)
        {
            SaveCurrentWorld();
        }

        private void btnBrowseTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "ToT Template Files|*.tott";
            openFileDialog1.Title = "Select a Template File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Template tTemplate;

                tTemplate = fileManager.LoadTemplate(openFileDialog1.FileName);

                if (tTemplate != null)
                    CurrentTemplate = tTemplate;

                FillItemsList(CurrentTemplate);


            }
        }

        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            if (txtTemplatePath.Text != "")
            {
                Template tTemplate;
                tTemplate = fileManager.LoadTemplate(txtTemplatePath.Text);

                if (tTemplate != null)
                    CurrentTemplate = tTemplate;

                FillItemsList(CurrentTemplate);
            }
        }

        private void FillItemsList(Template tTemplate)
        {
            dgItems.DataSource = null;
            
            var bindingList = new BindingList<Item>(tTemplate.Items);
            var source = new BindingSource(bindingList, null);
            dgItems.DataSource = source;


            dgNPCs.DataSource = null;
            var bindingList2 = new BindingList<NPC>(tTemplate.NPCs);
            var source2 = new BindingSource(bindingList2, null);
            dgNPCs.DataSource = source2;


            dgTTemplates.DataSource = null;
            var bindingList3 = new BindingList<TileTemplate>(tTemplate.TTemplates);
            var source3 = new BindingSource(bindingList3, null);
            dgTTemplates.DataSource = source3;

        }

        private void FillTempsList(Template tTemplate)
        {
            dgPossibleEnemies.DataSource = null;
            CurrTempEnemies = new List<NPC>();

            foreach (NPC tN in tTemplate.NPCs)
                if (tN.NpcType == NPCType.Enemy)
                    CurrTempEnemies.Add(tN);

            var bindingList = new BindingList<NPC>(CurrTempEnemies);
            var source = new BindingSource(bindingList, null);
            dgPossibleEnemies.DataSource = source;
        }

        private void FillTTempsList(TileTemplate TTemplate)
        {
            dgTTempEnemies.DataSource = null;

            var bindingList = new BindingList<NPC>(TTemplate.Enemies);
            var source = new BindingSource(bindingList, null);
            dgTTempEnemies.DataSource = source;
        }

        private void FillPropsList(Item tItem)
        {
            dgItemProps.DataSource = null;
            if (tItem.Props != null)
            {
                var bindingList = new BindingList<Prop>(tItem.Props);
                var source = new BindingSource(bindingList, null);

                dgItemProps.DataSource = source;
            }
        }


        private void FillNPCPropsList(NPC tNPC)
        {
            dgNPCProps.DataSource = null;
            if (tNPC.Props != null)
            {
                var bindingList = new BindingList<Prop>(tNPC.Props);
                var source = new BindingSource(bindingList, null);

                dgNPCProps.DataSource = source;
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string tItemName = "New Item";
            tItemName = GetNextItem(tItemName);
            CurrentTemplate.Items.Add(new Item(tItemName, ItemType.Currency));
            FillItemsList(CurrentTemplate);
        }
        
        public string GetNextItem(string tItemName)
        {
            string nextItem;
            int iNextItem = 1;

            foreach(Item tI in CurrentTemplate.Items)
                if (tI.Name == tItemName  + " " + iNextItem)
                    iNextItem += 1;

            nextItem = tItemName + " " + iNextItem;

            return nextItem;
        }
        public string GetNextNPC(string tNPCName)
        {
            string nextNPC;
            int iNextNPC = 1;

            foreach (NPC tI in CurrentTemplate.NPCs)
                if (tI.Name == tNPCName + " " + iNextNPC)
                    iNextNPC += 1;

            nextNPC = tNPCName + " " + iNextNPC;

            return nextNPC;
        }

        public string GetNextTemplate(string tNPCName)
        {
            string nextNPC;
            int iNextNPC = 1;

            foreach (TileTemplate tTT in CurrentTemplate.TTemplates)
                if (tTT.Name == tNPCName + " " + iNextNPC)
                    iNextNPC += 1;

            nextNPC = tNPCName + " " + iNextNPC;

            return nextNPC;
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {

        }
        private void dgItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridItems.SelectedObject = CurrentTemplate.Items[dgItems.CurrentRow.Index];
            FillPropsList(CurrentTemplate.Items[dgItems.CurrentRow.Index]);
            txtItemImage.Text = CurrentTemplate.Items[dgItems.CurrentRow.Index].TextureImg;
        }

        private void dgNPCs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridNPC.SelectedObject = CurrentTemplate.NPCs[dgNPCs.CurrentRow.Index];
            FillNPCPropsList(CurrentTemplate.NPCs[dgNPCs.CurrentRow.Index]);
            txtImageNPC.Text = CurrentTemplate.NPCs[dgNPCs.CurrentRow.Index].TextureImg;
        }


        private void dgTTemplates_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            gridTTemp.SelectedObject = CurrentTemplate.TTemplates[dgTTemplates.CurrentRow.Index];
            CurrentTTemplate = CurrentTemplate.TTemplates[dgTTemplates.CurrentRow.Index];
            FillTemplatesList(CurrentTTemplate);
            FillTempsList(CurrentTemplate);
        }

        private void toolStripBtnNewTemplate_Click(object sender, EventArgs e)
        {
            string TemplateName = Microsoft.VisualBasic.Interaction.InputBox("Template Name", "Enter the new template's name :", "New Template", -1, -1);

            if (TemplateName != "")
            {
                txtTemplatePath.Text = TEMPLATESPATH + TemplateName + ".tott";

                CurrentTemplate = new Template(TemplateName);
                FillItemsList(CurrentTemplate);
            }
            else
                MessageBox.Show("Template Creation Cancelled.", "New Template");
        }

        private void toolStripBtnSaveTemplate_Click(object sender, EventArgs e)
        {
            string srlzdTemplate = JsonConvert.SerializeObject(CurrentTemplate);
            string tempPath = txtTemplatePath.Text;

            if (tempPath == "")
                tempPath = TEMPLATESPATH + CurrentTemplate.Name + ".tott";

            fileManager.SaveToFile(srlzdTemplate, tempPath);

            txtTemplatePath.Text = tempPath;
        }

        private void btnImgSelect_Click(object sender, EventArgs e)
        {
            ImportImage tIImg = new ImportImage();
            tIImg.ImgPath = IMAGESPATH;
            tIImg.ShowDialog();
            txtItemImage.Text = tIImg.ImgToReturn;
            CurrentTemplate.Items[dgItems.CurrentRow.Index].TextureImg = tIImg.ImgToReturn;
        }

        private void txtItemImage_TextChanged(object sender, EventArgs e)
        {
            if (txtItemImage.Text != "")
            {
                pictureItem.Image = Image.FromFile(@IMAGESPATH + txtItemImage.Text + ".png");
            }
            else
                pictureItem.Image = null;
        }

        private void txtImageNPC_TextChanged(object sender, EventArgs e)
        {
            if (txtImageNPC.Text != "")
            {
                pictureNPC.Image = Image.FromFile(@IMAGESPATH + txtImageNPC.Text + ".png");
            }
            else
                pictureNPC.Image = null;
        }

        private void btnAddNPC_Click(object sender, EventArgs e)
        {
            string tTemplateName = "New NPC";
            tTemplateName = GetNextNPC(tTemplateName);
            CurrentTemplate.NPCs.Add(new NPC(tTemplateName, NPCType.Neutral));
            FillItemsList(CurrentTemplate);
        }

        private void btnBrowseImageNPC_Click(object sender, EventArgs e)
        {

            ImportImage tIImg = new ImportImage();
            tIImg.ImgPath = IMAGESPATH;
            tIImg.ShowDialog();
            txtImageNPC.Text = tIImg.ImgToReturn;
            CurrentTemplate.NPCs[dgNPCs.CurrentRow.Index].TextureImg = tIImg.ImgToReturn;
        }

        private void FillTemplatesList(TileTemplate tTemp)
        {
            gridTTemp.SelectedObject = tTemp;
            
            FillTTempsList(tTemp);
        }

        public void AddEnemyToTTemp(TileTemplate tTemp, NPC enemyToAdd)
        {
            bool enemyExists = false;
            foreach (NPC tS in tTemp.Enemies)
                if (tS.Name == enemyToAdd.Name)
                {
                    enemyExists = true;
                    break;
                }
            if (enemyExists == false)
            {
                tTemp.Enemies.Add(enemyToAdd);
                FillTTempsList(tTemp);
            }
            else
                MessageBox.Show("Enemy already exists in the current template.", "Enemy Exists.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

        }

        private void btnAddTTempEnemies_Click(object sender, EventArgs e)
        {
            if (dgPossibleEnemies.SelectedCells != null)
                AddEnemyToTTemp(CurrentTTemplate, CurrTempEnemies[dgPossibleEnemies.CurrentRow.Index]);
                
        }

        private void btnDelTTempEnemies_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAllTTempEnemies_Click(object sender, EventArgs e)
        {

        }

        private void btnDelAllTTempEnemies_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTileTemplate_Click(object sender, EventArgs e)
        {
            string tTemplateName = "New Template";
            tTemplateName = GetNextTemplate(tTemplateName);
            CurrentTemplate.TTemplates.Add(new TileTemplate(tTemplateName));
            FillItemsList(CurrentTemplate);
            FillTempsList(CurrentTemplate);
        }

        private void dgPossibleEnemies_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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
                                        //float rot = incmsg.ReadFloat(); // -||- player's angle
                                        //float pain = incmsg.ReadFloat(); // -||- player's pain

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

                                            //ICITTE SERVER
                                            //Checking if player's name exists, if so, load player from file.
                                            FileManager fmPlayer = new FileManager();
                                            //Player loadPlayer = fmPlayer.LoadPlayer(name, totServerForm.WORLDPATH);
                                            string srlzdPlayer = fmPlayer.LoadPlayer(name, totServerForm.PLAYERSPATH);
                                            Player loadPlayer;
                                            if (srlzdPlayer == "")
                                                loadPlayer = new Player(name, new Vector2(x, y), 0);
                                            else
                                                loadPlayer = JsonConvert.DeserializeObject<Player>(srlzdPlayer);
                                            Player.players.Add(loadPlayer);

                                            //Player.players.Add(new Player(name, new Vector2(x, y), 0)); //Add to player messages received as a parameter
                                            int ind = Player.players.Count - 1;
                                            //Player.players[ind].Rotation = rot;
                                            //Player.players[ind].Pain = pain;

                                            totServerForm.AddLogEntry(name + " connected." + "\r\n");

                                            for (int i = 0; i < Player.players.Count; i++)
                                            {
                                                // Write a new message with incoming parameters, and send the all connected clients.
                                                outmsg = Server.CreateMessage();

                                                outmsg.Write("connect");
                                                outmsg.Write(Player.players[i].name);
                                                outmsg.Write((int)Player.players[i].position.X);
                                                outmsg.Write((int)Player.players[i].position.Y);
                                                outmsg.Write((float)Player.players[i].Rotation);
                                                outmsg.Write((float)Player.players[i].Pain);
                                                outmsg.Write(JsonConvert.SerializeObject(Player.players[i].Projectiles));

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
                                            float rot = incmsg.ReadFloat(); // -||- player's angle
                                            float pain = incmsg.ReadFloat(); // -||- player's pain
                                            string srlzdProjs = incmsg.ReadString();

                                            for (int i = 0; i < Player.players.Count; i++)
                                            {
                                                if (Player.players[i].name.Equals(name))
                                                {
                                                    Player.players[i].position = new Vector2(x, y);
                                                    Player.players[i].timeOut = 0;
                                                    Player.players[i].Rotation = rot;
                                                    Player.players[i].Pain = pain;
                                                    Player.players[i].Projectiles = JsonConvert.DeserializeObject<List<Projectile>>(srlzdProjs);
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
                                    {
                                        string playerName = incmsg.ReadString();

                                        totServerForm.AddLogEntry(playerName + " - GetWorld Request\r\n");
                                        outmsg = Server.CreateMessage();
                                        outmsg.Write("getworld");
                                        outmsg.Write(playerName);
                                        FileManager fmWorld = new FileManager();
                                        string srlzdWorld = fmWorld.SerializeWorld(tCurrentWorld);
                                        outmsg.Write(srlzdWorld);
                                        //outmsg.WriteAllProperties(tCurrentWorld);
                                        //outmsg.WriteAllProperties(tCurrentWorld.BlocksBase);
                                        //outmsg.WriteAllProperties(tCurrentWorld.BlocksNorth);
                                        //outmsg.WriteAllProperties(tCurrentWorld.BlocksSouth);
                                        //outmsg.WriteAllProperties(tCurrentWorld.BlocksWest);
                                        //outmsg.WriteAllProperties(tCurrentWorld.BlocksEast);
                                        Server.SendMessage(outmsg, incmsg.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                                        totServerForm.AddLogEntry(playerName + " - GetWorld Request Answered\r\n\r\n");
                                    }
                                    break;
                                case "chat":
                                    {
                                        string playerName = incmsg.ReadString();
                                        string chatText = incmsg.ReadString();
                                        totServerForm.AddLogEntry(playerName + " : " + chatText + "\r\n");

                                        //outmsg = Server.CreateMessage();
                                        //outmsg.Write("chat");
                                        //outmsg.Write(playerName);
                                        //outmsg.Write(chatText);
                                        //Server.SendMessage(Network.outmsg, incmsg.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                                        //totServerForm.AddLogEntry(playerName + " - Chat Request Answered\r\n\r\n");
                                    }
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
        public Vector2 position;
        public float Rotation;
        public float Pain;
        public int timeOut; //This disconnects the client, even if no message from him within a certain period of time and not been reset value.
        public List<Projectile> Projectiles;

        public static List<Player> players = new List<Player>();

        public Player(string name,
                      Vector2 pozition,
                      int timeOut)
        {
            this.name = name;
            this.position = pozition;
            this.timeOut = timeOut;
            this.Projectiles = new List<Projectile>();
        }

        public static void Update()
        {
            if (Network.Server.ConnectionsCount == players.Count) //If the number of the player object actually corresponds to the number of connected clients.
            {
                for (int i = 0; i < players.Count; i++)
                {
                    for (int j = 0; j < players[i].Projectiles.Count; j++)
                    {
                        if (players[i].Projectiles[j].Active)
                        {
                            players[i].Projectiles[j].Update();
                            if (players[i].Projectiles[j].Active)
                                if (Vector2.Distance(players[i].Projectiles[j].Position, players[i].Projectiles[j].StartPosition) >= players[i].Projectiles[j].MaxDistance)
                                {
                                    players[i].Projectiles.RemoveAt(j);
                                    j--;
                                }
                        }
                    }
                    players[i].timeOut++; //This data member continuously counts up with every frame/tick.

                    //The server simply always sends data to the all players current position of all clients.
                    Network.outmsg = Network.Server.CreateMessage();

                    Network.outmsg.Write("move");
                    Network.outmsg.Write(players[i].name);
                    Network.outmsg.Write((int)players[i].position.X);
                    Network.outmsg.Write((int)players[i].position.Y);
                    Network.outmsg.Write((float)players[i].Rotation);
                    Network.outmsg.Write((float)players[i].Pain);
                    Network.outmsg.Write(JsonConvert.SerializeObject(players[i].Projectiles));

                    Network.Server.SendMessage(Network.outmsg, Network.Server.Connections, NetDeliveryMethod.Unreliable, 0);

                    if (players[i].timeOut > 360) //If this is true, so that is the player not sent information with himself
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
