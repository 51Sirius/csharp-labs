using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class Space : EnvironmentBase
{
    private Collection<Stones> _obstacle;
    public Space(Collection<Stones> obstacles, int lenght)
        : base(lenght)
    {
        _obstacle = obstacles;
    }

    public override bool AccessPassage(Spaceship ship)
    {
        return true;
    }
}