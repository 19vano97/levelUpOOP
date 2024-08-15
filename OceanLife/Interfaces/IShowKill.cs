using System;

namespace OceanLife;

public interface IShowKill
{
    Coordinates killPlace {get; set;}
    Image victim {get; set;}
    Image killer {get; set;}
}
