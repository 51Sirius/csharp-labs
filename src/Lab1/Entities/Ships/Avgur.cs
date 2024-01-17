using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Avgur : Spaceship
{
    public Avgur(double fuel, bool isPhoton)
        : base(new DeflectorThree(isPhoton), new ArmorShip(1), new ImpulseEngineE(), 3, new JumpEngineAlpha(), false, fuel: fuel)
    {
    }
}