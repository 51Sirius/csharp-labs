namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Engine
{
    private double _costMultiplier;

    public Engine(double costMultiplier)
    {
        _costMultiplier = costMultiplier;
    }

    public static double GiveTimeFromDistance()
    {
        return 0;
    }

    public double GetRequiredFuild(double distance)
    {
        return distance * _costMultiplier;
    }
}