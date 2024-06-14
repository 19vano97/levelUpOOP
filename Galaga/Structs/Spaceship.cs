using System.Drawing;

namespace Galaga;

public struct Spaceship
{
    public int id;
    public char symbol;
    public int healthPoint;
    public BlusterProperties bluster;
    public Position spaceshipCoodinates;
    public ulong spaceshipSpeed;
}
