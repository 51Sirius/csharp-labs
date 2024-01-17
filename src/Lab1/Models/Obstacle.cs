namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract class Obstacle
{
    public int Damage { get; init; }

    public static bool IsDamageHuman()
    {
        return false;
    }

    public static bool IsAntiNitrineDefend()
    {
        return false;
    }
}