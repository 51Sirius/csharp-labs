using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Stella : Spaceship
{
    public Stella(double fuel, bool isPhoton)
        : base(new DeflectorOne(isPhoton), new ArmorShip(1), new ImpulseEngineC(), 1, new JumpEngineOmega(), true, fuel: fuel)
    {
    }
}