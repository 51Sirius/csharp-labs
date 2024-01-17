using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class AntimatterFlares : Obstacle
{
    public static new bool IsDamageHuman()
    {
        return true;
    }
}