using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineC : Engine
{
    private const int СostMultiplier = 1;
    private double _speed;

    public ImpulseEngineC()
        : base(СostMultiplier)
    {
        _speed = 60;
    }

    public static new double GetRequiredFuild(double distance)
    {
        return distance;
    }

    public double GetTimeFromDistance(double distance)
    {
        return distance * _speed;
    }
}