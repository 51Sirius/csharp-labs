using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class PleasureShuttle : Spaceship
{
    public PleasureShuttle(double fuel)
        : base(null, new ArmorShip(1), new ImpulseEngineC(), 1, null, false, fuel: fuel)
    {
    }
}