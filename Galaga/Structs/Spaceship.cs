using System.Drawing;

namespace Galaga;

public struct Spaceship
{
    public int id;
    public char symbol;
    public int healthPoint;
    public BlusterProperty bluster;
    public PositionOf spaceshipCoodinates;
    public ulong spaceshipSpeed;
}
