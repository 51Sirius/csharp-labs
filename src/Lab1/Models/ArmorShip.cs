using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class ArmorShip
{
    private int _durability;

    public ArmorShip(int classDurability)
    {
        _durability = classDurability switch
        {
            1 => 1,
            2 => 5,
            3 => 20,
            _ => _durability,
        };
    }

    public ResultDefense TakeDamage(Obstacle obstacle)
    {
        if (obstacle != null && !Obstacle.IsDamageHuman())
        {
            if (_durability - obstacle.Damage >= -3)
            {
                _durability -= obstacle.Damage;
                var res = new ResultDefense();
                res.DeathCrew = false;
                res.DestroyingShip = false;
                return res;
            }
            else
            {
                var res = new ResultDefense();
                res.DeathCrew = false;
                res.DestroyingShip = true;
                return res;
            }
        }

        {
            var res = new ResultDefense();
            res.DeathCrew = true;
            res.DestroyingShip = false;
            return res;
        }
    }
}