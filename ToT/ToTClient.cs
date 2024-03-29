﻿using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lidgren.Network;
using ToT.Library;

namespace ToT
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ToTClient : Game
    {
        public const string IMAGESPATH = "C:/Prog/ToT/ToT/Data/Img/";

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private FrameCounter _frameCounter = new FrameCounter();
        private Camera PlayerCamera;

        Texture2D playerTexture;
        SpriteFont fontTexture;

        int IndexPlayer;
        string PlayerName;

        public static ClientState gameState;
        public static PlayerState playerState;
        public static InputManager playerInputs;

        public bool TemplateTexturesInitiated = false; //To initiate the world's template textures on the first world update.

        public static string HeadText = "Enter your character name:"; //The main text on the upper left corner
        
        public World CurrentWorld { get; set; }

        public ToTClient()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = ClientState.Login;
            playerState = PlayerState.Idle;
            IndexPlayer = -1;         
        }


        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            //graphics.IsFullScreen = true;
            
            //Adjusts the speed of the game. 
            //If "IsFixedTimeStep = True" and the "graphics.SynchronizeWithVerticalRetrace = False", then the game run with 60 FPS, 
            //this is important because the data transmission network can be fixed to 60 FPS.
            //NOTE: 60 FPS realtime transmission (for "move" data) is !!!not optimal!!!, but for simplicity thus now used.
            graphics.SynchronizeWithVerticalRetrace = false;
            
            IsFixedTimeStep = true;
            graphics.ApplyChanges();

            Network.Config = new NetPeerConfiguration("ToTNetwork"); //Same as the Server, so the same name to be used.
            Network.Client = new NetClient(Network.Config);

            playerInputs = new InputManager();

            base.Initialize();
            Camera tCam = new Camera(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            PlayerCamera = tCam;
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTexture = Content.Load<Texture2D>("char\\char48_ballface2");
            fontTexture = Content.Load<SpriteFont>("fontUI");
        }


        protected override void UnloadContent()
        {
            CurrentWorld = null;

        }

        protected override void Update(GameTime gameTime)
        {
            //System.Threading.Thread.Sleep(16);

            int tI = Network.Update(PlayerName);
            if (tI != -1)
                IndexPlayer = tI;
            playerInputs.Update();
            CurrentWorld = Network.CurrentWorld;

            Player.Update(PlayerCamera, CurrentWorld, playerInputs, PlayerName);
            if (CurrentWorld != null)
                CurrentWorld.Update(gameTime);

            switch(gameState)
            {
                case ClientState.Login:
                    TextInput.Update(playerInputs); //The TextInput is available and updated

                    //If your name is not empty and the actual keystroke
                    if (playerInputs.KeyPressed(Keys.Enter) && TextInput.text != "")
                    {
                        Network.Client.Start(); //Starting the Network Client
                        Network.Client.Connect("localhost", 14242); //And Connect the Server with IP (string) and host (int) parameters

                        //The causes are shown below pause for a bit longer. 
                        //On the client side can be a little time to properly connect to the server before the first message you send us. 
                        //The second one is also a reason. The client does not manually force the quick exit until it received a first message from the server. 
                        //If the client connect to trying one with the same name as that already exists on the server, 
                        //and you attempt to exit Esc-you do not even arrived yet reject response ("deny"), the underlying visible event is used, 
                        //so you can disconnect from the other player from the server because the name he applied for the existing exit button. 
                        //Therefore, this must be some pause. 
                        System.Threading.Thread.Sleep(300);

                        Network.outmsg = Network.Client.CreateMessage();
                        Network.outmsg.Write("connect");
                        PlayerName = TextInput.text;
                        Network.outmsg.Write(PlayerName);
                        Network.outmsg.Write(160);
                        Network.outmsg.Write(120);
                        Network.Client.SendMessage(Network.outmsg, NetDeliveryMethod.ReliableOrdered);
                        
                        gameState = ClientState.Game;

                        System.Threading.Thread.Sleep(300);

                        Network.outmsg = Network.Client.CreateMessage();
                        Network.outmsg.Write("getworld");
                        Network.outmsg.Write(PlayerName);
                        Network.Client.SendMessage(Network.outmsg, NetDeliveryMethod.ReliableOrdered);
                    
                        System.Threading.Thread.Sleep(300);


                    }
                    else if (playerInputs.KeyPressed(Keys.Escape))
                    {
                        this.Exit();
                    }
                    break;
                case ClientState.Game:
                    if (IndexPlayer == -1)
                        IndexPlayer = GetCurrentPlayer(PlayerName);
                    
                    if (playerState == PlayerState.Chatting)
                    {
                        TextInput.Update(playerInputs); //The TextInput is available and updated
                        if (playerInputs.KeyPressed(Keys.Enter) && TextInput.text != "")
                        {
                            Network.outmsg = Network.Client.CreateMessage();
                            Network.outmsg.Write("chat");
                            Network.outmsg.Write(PlayerName);
                            string chatText = TextInput.text.Substring(1);
                            Network.outmsg.Write(chatText);
                            Network.Client.SendMessage(Network.outmsg, NetDeliveryMethod.ReliableOrdered);

                            playerState = PlayerState.Idle;
                        }
                        if (playerInputs.KeyPressed(Keys.Escape))
                        {
                            playerState = PlayerState.Idle;
                        }
                    }
                    else
                    {
                        if (playerInputs.KeyPressed(Keys.Escape))
                        {
                            Network.outmsg = Network.Client.CreateMessage();
                            Network.outmsg.Write("disconnect");
                            Network.outmsg.Write(PlayerName);
                            Network.Client.SendMessage(Network.outmsg, NetDeliveryMethod.ReliableOrdered);

                            System.Threading.Thread.Sleep(300);

                            gameState = ClientState.Login;
                            Player.players.Clear();
                            HeadText = "Please Enter your name:";
                            PlayerCamera.SetFocalPoint(Vector2.Zero);
                        }
                        if (playerInputs.KeyPressed(Keys.T))
                        {
                            TextInput.text = "";
                            playerState = PlayerState.Chatting;
                        }
                    }

                    
                    break;
            }

            base.Update(gameTime);

            if (IndexPlayer != -1)
                if (Player.players.Count > IndexPlayer)
                    PlayerCamera.SetFocalPoint(Player.players[IndexPlayer].position);
            PlayerCamera.Update();
        }

        public int GetCurrentPlayer(string playerName)
        {
            //foreach (Player tP in Player.players)
            for (int i = 0; i < Player.players.Count; i++)
                if (Player.players[i].name == playerName)
                    return i;
            return -1;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            bool drawWorld = true;
            bool drawChat = false;
            spriteBatch.Begin(SpriteSortMode.Immediate,
                              BlendState.NonPremultiplied, null, null, null, null, PlayerCamera.ViewMatrix);
            switch(gameState)
            {
                case ClientState.Login:
                    drawWorld = false;
                    spriteBatch.DrawString(fontTexture, HeadText, PlayerCamera.Position + new Vector2(), Color.Black);
                    spriteBatch.DrawString(fontTexture, TextInput.text + "_", PlayerCamera.Position + new Vector2(0, 25), Color.Black);
                    break;
                case ClientState.Game:
                    if (playerState == PlayerState.Chatting)
                        drawChat = true;
                    break;
            }


            if (drawWorld)
            {
                if (CurrentWorld != null)
                {
                    if (!TemplateTexturesInitiated)
                    {
                        CurrentWorld.StuffTemplate.InitTemplateImages(GraphicsDevice, IMAGESPATH);
                        TemplateTexturesInitiated = true;
                    }

                    CurrentWorld.Draw(spriteBatch, fontTexture);
                    spriteBatch.DrawString(fontTexture, "World: " + CurrentWorld.Name, new Vector2(0, 0), Color.White, 0, new Vector2(), 0.75f, SpriteEffects.None, 0);
                }
                foreach (Player p in Player.players)
                {

                    if (p.Projectiles.Count > 0)
                    {
                        if (p.ProjImg == null)
                        {
                            FileStream filestream = new FileStream(IMAGESPATH + "BoltWood.png", FileMode.Open);
                            p.ProjImg = Texture2D.FromStream(GraphicsDevice, filestream);

                            filestream.Close();
                        }
                        foreach(Projectile tP in p.Projectiles)
                        {
                            spriteBatch.Draw(p.ProjImg, new Rectangle((int)tP.Position.X, (int)tP.Position.Y, p.ProjImg.Width, p.ProjImg.Height), Color.White);
                        }
                    }

                    if (p.MainAnim.Image == null)
                    {
                        p.MainAnim.Frames = new Vector2(3, 4);
                        p.MainAnim.Init(IMAGESPATH + p.CharImg, GraphicsDevice);
                    }
                    
                    //spriteBatch.Draw(playerTexture, new Rectangle((int)p.position.X, (int)p.position.Y, p.defaultRect.Width, p.defaultRect.Height), p.drawRect, Color.White, p.Rotation, new Vector2(24, 24), SpriteEffects.None, 0f);
                    
                    //spriteBatch.Draw(p.MainAnim.Image, new Rectangle((int)p.position.X, (int)p.position.Y, p.defaultRect.Width, p.defaultRect.Height), p.drawRect, Color.White, p.Rotation, new Vector2(24, 24), SpriteEffects.None, 0f);
                    
                    spriteBatch.Draw(p.MainAnim.Image, p.position, p.MainAnim.SourceRect, Color.White, p.Rotation, p.MainAnim.Origin, 1f, SpriteEffects.None, 0.0f);



                    spriteBatch.DrawString(fontTexture, p.name, new Vector2(p.position.X - p.defaultRect.Width / 2, p.position.Y - 22 - p.defaultRect.Height / 2), Color.Black, 0, new Vector2(), 0.6f, SpriteEffects.None, 0);
                    if (p.healthbar == null || p.LastPain != p.Pain)
                    {
                        float tHealth = p.GetPropLevel("Health");
                        TextureRect tRect = new TextureRect(spriteBatch, new Vector2(p.defaultRect.Width, 6f), Color.Green, 0, TextureRectType.PercentageBar, (tHealth - p.Pain) / tHealth);
                        p.healthbar = tRect.RectTexture;
                    }
                    spriteBatch.Draw(p.healthbar, new Rectangle((int)(p.position.X - p.defaultRect.Width / 2), (int)(p.position.Y - 6 - p.defaultRect.Height / 2), (int)p.defaultRect.Width, 5), Color.White);
                }
                //spriteBatch.DrawString(fontTexture, "Players: " + Player.players.Count.ToString(), new Vector2(0, 580), Color.White, 0, new Vector2(), 0.75f, SpriteEffects.None, 0);

                //FPS COUNTER
                var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                _frameCounter.Update(deltaTime);
                var fps = string.Format("FPS: {0}", Math.Round(_frameCounter.AverageFramesPerSecond));
                spriteBatch.DrawString(fontTexture, fps, PlayerCamera.Position + new Vector2(PlayerCamera.ScreenDimensions.X - 50, 0), Color.Black, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
            if (drawChat && TextInput.text != "")
                spriteBatch.DrawString(fontTexture, TextInput.text.Substring(1) + "_", PlayerCamera.Position + new Vector2(0, PlayerCamera.ScreenDimensions.Y - 25), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
