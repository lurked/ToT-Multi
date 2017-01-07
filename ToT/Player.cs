using System;
using System.Collections.Generic;
using System.IO;
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
        public const string IMAGESPATH = "C:/Prog/ToT/ToT/Data/Img/";


        public string name;
        public Vector2 position,
                       lastPos;
        public Rectangle defaultRect,
                         drawRect;
        public List<Prop> PlayerProps;
        public float Pain { get; set; }
        public float LastPain { get; set; }
        [JsonIgnore]
        public Prop CurrentAttack { get; set; }
        [JsonIgnore]
        public Texture2D healthbar;
        [JsonIgnore]
        public Block currentBlock;
        [JsonIgnore]
        public static List<Player> players = new List<Player>();
        public PlayerClass CurrentClass { get; set; }
        [JsonIgnore]
        public float Rotation { get; set; }
        [JsonIgnore]
        public bool Collided { get; set; }
        [JsonIgnore]
        public Vector2 RealMousePos { get; set; }
        [JsonIgnore]
        public float DistanceToCharge { get; set; }
        [JsonIgnore]
        public float DistanceToBlink { get; set; }
        [JsonIgnore]
        public Vector2 DashDirection { get; set; }
        [JsonIgnore]
        public Vector2 BlinkDirection { get; set; }
        public List<Projectile> Projectiles { get; set; }
        [JsonIgnore]
        public Texture2D ProjImg { get; set; }
        [JsonIgnore]
        public Animation MainAnim { get; set; }
        public string CharImg { get; set; }

        public const float ChargeSpeed = 0.05f;
        public Player(string name, Vector2 pozition, Rectangle defaultRect, Rectangle drawRect, PlayerClass pClass = PlayerClass.Noob)
        {
            //this.CharImg = "Player01.png";
            this.CharImg = "character4.png";
            
            this.MainAnim = new Animation(AnimationType.Spritesheet);
            this.name = name;
            this.position = pozition;
            this.defaultRect = defaultRect;
            this.drawRect = drawRect;

            PlayerProps = new List<Prop>();
            Projectiles = new List<Projectile>();

            //Loading Default Projectile Images

            Init(pClass);
        }

        public void Init(PlayerClass pClass)
        {
            //Initiate a player of the pClass player class according to some bs templates.
            //Maybe use an editor later.
            PlayerProps.Clear();
            
            //Pain = StaticRandom.Instance.Next(0, 10);
            Pain = 0;
            LastPain = Pain;

            switch(pClass)
            {
                case PlayerClass.Noob:
                    PlayerProps.Add(new Prop("Health", 10));
                    PlayerProps.Add(new Prop("Energy", 0));
                    PlayerProps.Add(new Prop("Speed", 5));
                    PlayerProps.Add(new Prop("Charge", 1));
                    PlayerProps.Add(new Prop("ChargeDistance", 160));
                    PlayerProps.Add(new Prop("Attack-Melee", 1));
                    break;
                case PlayerClass.Warrior:
                    PlayerProps.Add(new Prop("Level", 1));
                    PlayerProps.Add(new Prop("Health", 20));
                    PlayerProps.Add(new Prop("Energy", 5));
                    PlayerProps.Add(new Prop("Speed", 6));
                    PlayerProps.Add(new Prop("Charge", 1));
                    PlayerProps.Add(new Prop("ChargeDistance", 240));
                    PlayerProps.Add(new Prop("Attack-Melee", 1));
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
                    PlayerProps.Add(new Prop("Blink", 1));
                    PlayerProps.Add(new Prop("BlinkDistance", 160));
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

        public static void Update(Camera pCam, World currentWorld, InputManager playerInputs, string CurrentPlayer = "")
        {
            
            foreach (Player p in players)
            {
                p.defaultRect.X = (int)p.position.X;
                p.defaultRect.Y = (int)p.position.Y;

                if (p.MainAnim.Image != null)
                {
                    p.MainAnim.Update();
                }

                //This step is just sending a Player state
                if (p.name.Equals(CurrentPlayer)) //If the player's name is equal to the TextInput your name.
                {
                    if (currentWorld != null)
                        if (p.currentBlock == null && currentWorld.BlocksBase.Count > 0)
                            p.currentBlock = currentWorld.BlocksBase[0];

                    Vector2 mousePosition = playerInputs.MousePosition();
                    //p.Rotation = (float)Math.Atan2((double)ActualMouseState.Position.Y - ((16) - pCam.Position.Y), (double)ActualMouseState.Position.X - ((p.position.X + 16) - pCam.Position.X)); //this will return the angle(in radians) from sprite to mouse.

                    Vector2 dPos = ((p.position) - pCam.Position) - mousePosition;

                    p.Rotation = (float)Math.Atan2(dPos.Y, dPos.X);

                    if (p.MainAnim.Active)
                        p.MainAnim.Active = false;

                    float fSpeed = p.GetPropLevel("Speed");
                    if (playerInputs.KeyDown(Keys.Right) || playerInputs.KeyDown(Keys.D))
                    {
                        p.MainAnim.Active = true;
                        p.lastPos = p.position;

                        p.position.X += fSpeed;
                        p.ValidateNewPos(p, currentWorld);
                    }
                    if (playerInputs.KeyDown(Keys.Left) || playerInputs.KeyDown(Keys.A))
                    {
                        p.MainAnim.Active = true;
                        p.lastPos = p.position;

                        p.position.X -= fSpeed;
                        p.ValidateNewPos(p, currentWorld);
                    }
                    if (playerInputs.KeyDown(Keys.Up) || playerInputs.KeyDown(Keys.W))
                    {
                        p.MainAnim.Active = true;
                        p.lastPos = p.position;

                        p.position.Y -= fSpeed;
                        p.ValidateNewPos(p, currentWorld);
                    }
                    if (playerInputs.KeyDown(Keys.Down) || playerInputs.KeyDown(Keys.S))
                    {
                        p.MainAnim.Active = true;
                        p.lastPos = p.position;

                        p.position.Y += fSpeed;
                        p.ValidateNewPos(p, currentWorld);
                    }

                    if (playerInputs.KeyPressed(Keys.Space) || playerInputs.ButtonPressed(Buttons.Y))
                    {
                        p.MainAnim.Active = true;
                        p.lastPos = p.position;

                        switch(p.CurrentClass)
                        {
                            case PlayerClass.Noob:
                            case PlayerClass.Warrior:
                                p.UsePower("Charge", playerInputs);
                                break;
                            case PlayerClass.Mage:
                                p.UsePower("Blink", playerInputs);
                                break;
                        }
                    }

                    if (playerInputs.MousePressed())
                    {
                        p.UsePower("Attack-Melee", playerInputs, pCam);
                    }

                    //Checks if there's a charging distance remaining.
                    if (p.DistanceToCharge > 0)
                    {
                        p.RealMousePos = playerInputs.MousePosition() + pCam.Position;
                        p.DashDirection = p.RealMousePos - p.position;
                        p.DashDirection.Normalize();

                        p.position += p.DashDirection * ChargeSpeed;

                        p.ValidateNewPos(p, currentWorld);
                        p.DistanceToCharge -= Vector2.Distance(p.lastPos, p.position);
                        p.lastPos = p.position;
                    }

                    //Checks if there's a blinking distance remaining.
                    if (p.DistanceToBlink > 0)
                    {
                        p.RealMousePos = playerInputs.MousePosition() + pCam.Position;
                        p.DashDirection = p.RealMousePos - p.position;
                        p.DashDirection.Normalize();

                        //p.position += (p.DashDirection * (ChargeSpeed * new Vector2(0.1f, 0.1f)));

                        p.ValidateNewPos(p, currentWorld);

                        p.DistanceToCharge -= Vector2.Distance(p.lastPos, p.position);
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
                    Network.outmsg.Write(JsonConvert.SerializeObject(p.Projectiles));

                    Network.Client.SendMessage(Network.outmsg, NetDeliveryMethod.Unreliable);
                }
            }
        }

        public float GetPropLevel(string PowerName)
        {
            float powerLevel = 0;
            foreach (Prop tP in PlayerProps)
                if (tP.Name == PowerName)
                    if (tP.Level > powerLevel)
                        powerLevel = tP.Level;

            return powerLevel;
        }

        public void Attack(Prop attack, InputManager playerInputs, Camera pCam = null)
        {
            switch(attack.Name.ToLower())
            {
                case "attack-melee":
                    switch((int)attack.Level)
                    {
                        case 1:
                            Projectile tProj = new Projectile(attack);
                            tProj.Init(position, playerInputs.MousePosition() + pCam.Position);
                            Projectiles.Add(tProj);
                            
                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                    }
                    break;
                case "attack-ranged":
                    switch ((int)attack.Level)
                    {
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                    }
                    break;
            }
        }

        public void UsePower(string PowerName, InputManager playerInputs, Camera pCam = null)
        {
            if (GetPropLevel(PowerName) > 0)
            {
                switch(PowerName)
                {
                    case "Charge":
                        DistanceToCharge = GetPropLevel("ChargeDistance");
                        break;
                    case "Blink":
                        DistanceToCharge = GetPropLevel("BlinkDistance");
                        break;
                    case "Attack-Melee":
                        CurrentAttack = GetProp("Attack-Melee");
                        Attack(CurrentAttack, playerInputs, pCam);
                        break;
                }
            }
        }
    }
}
