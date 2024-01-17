using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class Nebula : EnvironmentBase
{
    private Collection<SpaceWhales> _obstacle;
    public Nebula(Collection<SpaceWhales> obstacles, int lenght)
        : base(lenght)
    {
        _obstacle = obstacles;
    }

    public override bool AccessPassage(Spaceship ship)
    {
        return ship != null && ship.IsHaveJumpEngine();
    }
}