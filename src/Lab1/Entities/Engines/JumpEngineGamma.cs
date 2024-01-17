using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngineGamma : JumpEngine
{
    public JumpEngineGamma()
    {
    }

    public static new double GetRequiredFuild(double distance)
    {
        return distance * distance;
    }
}