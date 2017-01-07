
public enum WorldAction
{
    GenerateNew,
    Load
}

public enum GameMode
{
    Adventure,
    Challenge,
    Creative,
    GodMode
}

public enum AnimationType
{
    None,
    Spritesheet,
    Sprite
}

public enum ClientState
{
    Idle,
    MainMenu,
    Login,
    Game,
    Loading
}

public enum PlayerState
{
    Idle,
    Chatting,
    Walking,
    Running,
    Dashing,
    Attacking
}

public enum PlayerClass
{
    Noob,
    Warrior,
    Archer,
    Mage,
    Druid,
    Tech
}

public enum ItemType
{
    Consummable,
    Armor,
    Weapon,
    Jewelry,
    Currency,
    Resource,
    Container,
    Decor,
    Sign
}

public enum NPCType
{
    Neutral,
    Enemy,
    Ally,
    Companion,
    Vendor
}

public enum TextureRectType
{
    Basic,
    PercentageBar
}

public enum Orientation
{
    North,
    South,
    West,
    East,
    None
}
public enum TileSize
{
    Tiny,
    VerySmall,
    Small,
    Medium,
    Large,
    VeryLarge,
    Huge,
    HughMongus
}