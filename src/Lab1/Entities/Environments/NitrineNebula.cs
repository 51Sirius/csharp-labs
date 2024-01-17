using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NitrineNebula : EnvironmentBase
{
    private Collection<AntimatterFlares> _obstacle;
    public NitrineNebula(Collection<AntimatterFlares> obstacles, int lenght)
        : base(lenght)
    {
        _obstacle = obstacles;
    }

    public override bool AccessPassage(Spaceship ship)
    {
        return ship != null && ship.IsHaveExpEngine();
    }
}