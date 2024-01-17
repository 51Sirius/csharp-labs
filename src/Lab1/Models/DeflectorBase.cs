using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class DeflectorBase
{
    private int _durability;
    private int _photonDurability;
    private bool _isBreak;

    public DeflectorBase(bool isPhoton, int durability)
    {
        _durability = durability;
        _photonDurability = 0;
        if (isPhoton)
        {
            _photonDurability = 3;
        }
    }

    public ResultDefense TakeDamage(Obstacle obstacle)
    {
        if (obstacle != null && !Obstacle.IsDamageHuman())
        {
            if (_durability - obstacle.Damage > -2)
            {
                _durability -= obstacle.Damage;
                var res = new ResultDefense();
                res.DeathCrew = false;
                res.DestroyingShip = false;
                return res;
            }
            else
            {
                _isBreak = true;
                var res = new ResultDefense();
                res.DeathCrew = false;
                res.DestroyingShip = false;
                return res;
            }
        }

        {
            _photonDurability -= 1;
            var res = new ResultDefense();
            res.DeathCrew = _photonDurability < 0;
            res.DestroyingShip = false;
            return res;
        }
    }

    public bool IsAlive()
    {
        return !_isBreak;
    }
}