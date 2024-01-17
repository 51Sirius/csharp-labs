using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract class EnvironmentBase
{
    private double _lenght;
    private Collection<Obstacle> _obstacle = new Collection<Obstacle>();

    protected EnvironmentBase(int lenght)
    {
        _lenght = lenght;
    }

    public abstract bool AccessPassage(Spaceship ship);
    public JourneyResult? PassingRoute(Spaceship ship)
    {
        return ship?.Fly(_lenght, this);
    }

    public ResultDefense DropObstacles(Spaceship ship)
    {
        if (_obstacle != null)
        {
            foreach (Obstacle obstacle in _obstacle)
            {
                if (ship != null)
                {
                    ResultDefense result = ship.TakeDamage(obstacle);
                    if (result.DeathCrew || result.DestroyingShip)
                    {
                        return result;
                    }
                }
            }
        }

        var res = new ResultDefense();
        res.DeathCrew = false;
        res.DestroyingShip = false;
        return res;
    }
}