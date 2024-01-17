using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngineAlpha : JumpEngine
{
    public JumpEngineAlpha()
    {
    }

    public static new double GetRequiredFuild(double distance)
    {
        return distance;
    }
}