namespace Galaga;

public struct GameProperty
{
    public char[,] gamezone;
    public Spaceship[] allSpaceships;
    public ulong gameTime;
    public bool isGameOver;
    public GameLevelStructure level;
    public int score;
}
