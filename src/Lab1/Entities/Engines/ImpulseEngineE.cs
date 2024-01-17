using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineE : Engine
{
    private const int СostMultiplier = 2;

    public ImpulseEngineE()
        : base(СostMultiplier)
    {
    }

    public static new double GetRequiredFuild(double distance)
    {
        return GetTimeFromDistance(distance) * 2;
    }

    private static double GetTimeFromDistance(double distance)
    {
        double timeTravel = 0;
        double speed;
        for (int i = 0; i < distance; i = (int)(i + speed))
        {
            timeTravel++;
            speed = Math.Exp(timeTravel);
        }

        return timeTravel;
    }
}