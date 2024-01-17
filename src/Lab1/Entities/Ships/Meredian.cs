using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Meredian : Spaceship
{
    public Meredian(double fuel, bool isPhoton)
        : base(new DeflectorTwo(isPhoton), new ArmorShip(2), new ImpulseEngineE(), 2, null, true, fuel: fuel)
    {
    }
}