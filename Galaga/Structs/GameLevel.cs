﻿namespace Galaga;

public struct GameLevel
{
    public LevelEnums name;
    public int heroHealthpoints;
    public int enemyHealthpoints;
    public int heroBlusterDamage;
    public ulong heroSpeed;
    public int enemyBlusterDamage;
    public ulong enemySpeed;
    public ulong enemyShotFrequensy;
    public int maxEnemiesOnScreen;
}
