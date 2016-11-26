using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lidgren.Network;

namespace ToT
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ToTClient : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D playerTexture;
        SpriteFont fontTexture;

        KeyboardState ActualKeyState,
                      LastKeyState;
        ClientState gameState;

        public static string HeadText = "Please Enter your name:"; //The main text on the upper left corner
        public static bool TextCanWrite = true; //Also important: If this is true, you can type in text, 
                                                //otherwise the players connected to the server and play. 

        public ToTClient()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = ClientState.MainMenu;
        }


        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
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

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTexture = Content.Load<Texture2D>("player");
            fontTexture = Content.Load<SpriteFont>("font");
        }


        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            //System.Threading.Thread.Sleep(16);

            //The Actual and the Last key combination allows it to be valid in a given moment is a key strokes.
            LastKeyState = ActualKeyState;
            ActualKeyState = Keyboard.GetState();

            Network.Update();
            Player.Update();


            if (TextCanWrite == true) //If its is True...
            {
                TextInput.Update(); //The TextInput is available and updated

                //If your name is not empty and the actual keystroke
                if (ActualKeyState.IsKeyDown(Keys.Enter) && LastKeyState.IsKeyUp(Keys.Enter) && TextInput.text != "")
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
                    Network.outmsg.Write(TextInput.text);
                    Network.outmsg.Write(160);
                    Network.outmsg.Write(120);
                    Network.Client.SendMessage(Network.outmsg, NetDeliveryMethod.ReliableOrdered);

                    TextCanWrite = false;

                    System.Threading.Thread.Sleep(300);
                }
                else if (ActualKeyState.IsKeyDown(Keys.Escape) && LastKeyState.IsKeyUp(Keys.Escape))
                {
                    this.Exit();
                }
            }
            else
            {
                if (ActualKeyState.IsKeyDown(Keys.Escape) && LastKeyState.IsKeyUp(Keys.Escape))
                {
                    Network.outmsg = Network.Client.CreateMessage();
                    Network.outmsg.Write("disconnect");
                    Network.outmsg.Write(TextInput.text);
                    Network.Client.SendMessage(Network.outmsg, NetDeliveryMethod.ReliableOrdered);

                    System.Threading.Thread.Sleep(300);

                    TextCanWrite = true;
                    Player.players.Clear();
                    HeadText = "Please Enter your name:";

                    //this.Exit();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate,
                              BlendState.NonPremultiplied);

            if (TextCanWrite == true)
            {
                spriteBatch.DrawString(fontTexture, HeadText, new Vector2(), Color.White);
                spriteBatch.DrawString(fontTexture, TextInput.text + "_", new Vector2(0, 25), Color.White);
            }

            foreach (Player p in Player.players)
            {
                spriteBatch.Draw(playerTexture, new Rectangle((int)p.position.X, (int)p.position.Y, p.defaultRect.Width, p.defaultRect.Height), p.drawRect, Color.White);
                spriteBatch.DrawString(fontTexture, p.name, new Vector2(p.position.X, p.position.Y - 18), Color.White, 0, new Vector2(), 0.6f, SpriteEffects.None, 0);
            }

            spriteBatch.DrawString(fontTexture, "Players: " + Player.players.Count.ToString(), new Vector2(0, 580), Color.White, 0, new Vector2(), 0.75f, SpriteEffects.None, 0);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
