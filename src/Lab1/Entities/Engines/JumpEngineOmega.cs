using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngineOmega : JumpEngine
{
    public JumpEngineOmega()
    {
    }

    public static new double GetRequiredFuild(double distance)
    {
        return distance * Math.Log(distance);
    }
}