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
using Newtonsoft.Json;

namespace ToT
{
    public class Player
    {
        public string name;
        public Vector2 position,
                       lastPos;
        public Rectangle defaultRect,
                         drawRect;
        public List<Prop> PlayerProps;
        public float Pain { get; set; }
        public float LastPain { get; set; }

        [JsonIgnore]
        public Texture2D healthbar;
        [JsonIgnore]
        public static KeyboardState ActualKeyState;
        [JsonIgnore]
        public static MouseState ActualMouseState;
        [JsonIgnore]
        public Block currentBlock;
        [JsonIgnore]
        public static List<Player> players = new List<Player>();
        public PlayerClass CurrentClass { get; set; }
        [JsonIgnore]
        public float Rotation { get; set; }
        [JsonIgnore]
        public bool Collided { get; set; }
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

        public void ValidateNewPos(Player p, World currWorld)
        {
            Block tBlock = null;
            Orientation ori = Orientation.None;
            if (position.Y - drawRect.Height / 2 <= currentBlock.Position.Y)
            {
                ori = Orientation.North;

                tBlock = GetNewBlock(currWorld, ori);
            }
            else if (position.X - drawRect.Width / 2 <= currentBlock.Position.X)
            {
                ori = Orientation.West;

                tBlock = GetNewBlock(currWorld, ori);
            }
            else if (position.Y + drawRect.Height / 2 >= currentBlock.Position.Y + currentBlock.Dimensions.Y)
            {
                ori = Orientation.South;

                tBlock = GetNewBlock(currWorld, ori);
            }
            else if (position.X + drawRect.Width / 2 >= currentBlock.Position.X + currentBlock.Dimensions.X)
            {
                ori = Orientation.East;

                tBlock = GetNewBlock(currWorld, ori);
            }
            //else
            //{
                //tBlock = null;
            
            if (p.position.X - p.drawRect.Width / 2 < p.currentBlock.Position.X ||
                p.position.X + p.drawRect.Width / 2 > p.currentBlock.Position.X + p.currentBlock.Dimensions.X ||
                p.position.Y - p.drawRect.Height / 2 < p.currentBlock.Position.Y ||
                p.position.Y + p.drawRect.Height / 2 > p.currentBlock.Position.Y + p.currentBlock.Dimensions.Y)
            {
                if (tBlock != null && ori != Orientation.None)
                {
                    bool toMove = false;
                    switch(ori)
                    {
                        case Orientation.North:
                            if (p.position.X - p.drawRect.Width / 2 > tBlock.Position.X &&
                                p.position.X + p.drawRect.Width / 2 < tBlock.Position.X + tBlock.Dimensions.X)
                                toMove = true;
                            break;
                        case Orientation.West:
                            if (p.position.Y - p.drawRect.Height / 2 > tBlock.Position.Y &&
                                p.position.Y + p.drawRect.Height / 2 < tBlock.Position.Y + tBlock.Dimensions.Y)
                                toMove = true;                            
                            break;
                        case Orientation.South:
                            if (p.position.X - p.drawRect.Width / 2 > tBlock.Position.X &&
                                p.position.X + p.drawRect.Width / 2 < tBlock.Position.X + tBlock.Dimensions.X)
                                toMove = true;
                            break;
                        case Orientation.East:
                            if (p.position.Y - p.drawRect.Height / 2 > tBlock.Position.Y &&
                                p.position.Y + p.drawRect.Height / 2 < tBlock.Position.Y + tBlock.Dimensions.Y)
                                toMove = true;
                            break;
                    }
                    if (toMove)
                    {
                        currentBlock.HasPlayer = false;
                        tBlock.HasPlayer = true;
                        currentBlock = tBlock;
                        p.Collided = false;
                    }
                    else
                    {
                        p.position = p.lastPos;
                        p.Collided = true;
                    }
                }
                else
                {
                    p.position = p.lastPos;
                    p.Collided = true;
                }
            }
            else
                p.Collided = false;
            //}

            //if (tBlock != null)
            //{
            //    currentBlock.HasPlayer = false;
            //    tBlock.HasPlayer = true;
            //    currentBlock = tBlock;
            //}
                



        }

        public void FindCurrentBlock(World currWorld)
        {

        }

        public Block GetNewBlock(World currWorld, Orientation ori)
        {
            Block newBlock = new Block();
            string[] split = currentBlock.Coords.Split(':');
            string sB = split[0];
            int ind = int.Parse(split[1]);

            switch(ori)
            {
                case Orientation.North:
                    if (sB == "B")
                        newBlock = currWorld.BlocksNorth[0];
                    else if (sB == "N")
                        if (currWorld.BlocksNorth.Count > ind + 1)
                            newBlock = currWorld.BlocksNorth[ind + 1];
                        else
                            newBlock = null;
                    else
                        if (ind > 0)
                            newBlock = currWorld.BlocksSouth[ind - 1];
                        else
                            newBlock = currWorld.BlocksBase[0];
                    break;
                case Orientation.West:
                    if (sB == "B")
                        newBlock = currWorld.BlocksWest[0];
                    else if (sB == "W")
                        if (currWorld.BlocksWest.Count > ind + 1)
                            newBlock = currWorld.BlocksWest[ind + 1];
                        else
                            newBlock = null;
                    else
                        if (ind > 0)
                            newBlock = currWorld.BlocksEast[ind - 1];
                        else
                            newBlock = currWorld.BlocksBase[0];
                    break;
                case Orientation.South:
                    if (sB == "B")
                        newBlock = currWorld.BlocksSouth[0];
                    else if (sB == "S")
                        if (currWorld.BlocksSouth.Count > ind + 1)
                            newBlock = currWorld.BlocksSouth[ind + 1];
                        else
                            newBlock = null;
                    else
                        if (ind > 0)
                            newBlock = currWorld.BlocksNorth[ind - 1];
                        else
                            newBlock = currWorld.BlocksBase[0];

                    break;
                case Orientation.East:
                    if (sB == "B")
                        newBlock = currWorld.BlocksEast[0];
                    else if (sB == "E")
                        if (currWorld.BlocksEast.Count > ind + 1)
                            newBlock = currWorld.BlocksEast[ind + 1];
                        else
                            newBlock = null;
                    else
                        if (ind > 0)
                            newBlock = currWorld.BlocksWest[ind - 1];
                        else
                            newBlock = currWorld.BlocksBase[0];
                    break;
            }

            return newBlock;
        }

        public static void Update(Camera pCam, World currentWorld)
        {
            ActualKeyState = Keyboard.GetState();
            ActualMouseState = Mouse.GetState();


            foreach (Player p in players)
            {
                p.defaultRect.X = (int)p.position.X;
                p.defaultRect.Y = (int)p.position.Y;

                //This step is just sending a Player state
                if (p.name.Equals(TextInput.text)) //If the player's name is equal to the TextInput your name.
                {
                    if (currentWorld != null)
                        if (p.currentBlock == null && currentWorld.BlocksBase.Count > 0)
                            p.currentBlock = currentWorld.BlocksBase[0];



                    Vector2 mousePosition = new Vector2(ActualMouseState.X, ActualMouseState.Y);
                    //p.Rotation = (float)Math.Atan2((double)ActualMouseState.Position.Y - ((16) - pCam.Position.Y), (double)ActualMouseState.Position.X - ((p.position.X + 16) - pCam.Position.X)); //this will return the angle(in radians) from sprite to mouse.

                    Vector2 dPos = ((p.position) - pCam.Position) - mousePosition;

                    p.Rotation = (float)Math.Atan2(dPos.Y, dPos.X);

                    float fSpeed = p.GetPropLevel("Speed");
                    if (ActualKeyState.IsKeyDown(Keys.Right) || ActualKeyState.IsKeyDown(Keys.D))
                    {
                        p.lastPos = p.position;

                        p.position.X += fSpeed;
                        p.ValidateNewPos(p, currentWorld);
                    }
                    if (ActualKeyState.IsKeyDown(Keys.Left) || ActualKeyState.IsKeyDown(Keys.A))
                    {
                        p.lastPos = p.position;

                        p.position.X -= fSpeed;
                        p.ValidateNewPos(p, currentWorld);
                    }
                    if (ActualKeyState.IsKeyDown(Keys.Up) || ActualKeyState.IsKeyDown(Keys.W))
                    {
                        p.lastPos = p.position;

                        p.position.Y -= fSpeed;
                        p.ValidateNewPos(p, currentWorld);
                    }
                    if (ActualKeyState.IsKeyDown(Keys.Down) || ActualKeyState.IsKeyDown(Keys.S))
                    {
                        p.lastPos = p.position;

                        p.position.Y += fSpeed;
                        p.ValidateNewPos(p, currentWorld);
                    }

                    //if (p.lastPos != p.position)
                    //if (p.Collided)
                    //    p.FindCurrentBlock(currentWorld);

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
