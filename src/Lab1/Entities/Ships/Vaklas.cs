using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Vaklas : Spaceship
{
    public Vaklas(double fuel, bool isPhoton)
        : base(new DeflectorOne(isPhoton), new ArmorShip(2), new ImpulseEngineE(), 2, new JumpEngineGamma(), false, fuel: fuel)
    {
    }
}