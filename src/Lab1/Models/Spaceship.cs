using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Spaceship
{
    private readonly DeflectorBase? _deflector;
    private readonly ArmorShip _armor;
    private readonly Engine _impulseEngine;
    private readonly JumpEngine? _jumpEngine;
    private readonly int _size;
    private readonly bool _withAntiNitrine;
    private double _fuel;

    public Spaceship(DeflectorBase? deflector, ArmorShip armor, Engine impulseEngine, int size, JumpEngine? jumpEngine, bool withAntiNitrine, double fuel)
    {
        _impulseEngine = impulseEngine;
        _armor = armor;
        _deflector = deflector;
        _size = size;
        _jumpEngine = jumpEngine;
        _withAntiNitrine = withAntiNitrine;
        _fuel = fuel;
    }

    public bool IsHaveJumpEngine()
    {
        return _jumpEngine != null;
    }

    public bool IsHaveExpEngine()
    {
        return _impulseEngine.GetType() == typeof(ImpulseEngineE);
    }

    public ResultDefense TakeDamage(Obstacle obstacle)
    {
        if (obstacle != null && this._withAntiNitrine && Obstacle.IsAntiNitrineDefend())
        {
            var res = new ResultDefense();
            res.DeathCrew = false;
            res.DestroyingShip = false;
            return res;
        }

        if (obstacle != null)
        {
            if (_deflector != null)
            {
                if (_deflector.IsAlive())
                {
                    return _deflector.TakeDamage(obstacle);
                }

                return _armor.TakeDamage(obstacle);
            }

            return _armor.TakeDamage(obstacle);
        }

        {
            var res = new ResultDefense();
            res.DeathCrew = false;
            res.DestroyingShip = false;
            return res;
        }
    }

    public JourneyResult Fly(double lenght, EnvironmentBase environmentBase)
    {
        if (environmentBase != null && environmentBase.AccessPassage(this))
        {
            double requiredFuel = 0;
            double requiredTime = 0;
            if (environmentBase.GetType() == typeof(Nebula))
            {
                if (_jumpEngine != null)
                {
                    requiredFuel = _jumpEngine.GetRequiredFuild(lenght);
                    requiredTime = Engine.GiveTimeFromDistance();
                }
            }
            else
            {
                requiredFuel = _impulseEngine.GetRequiredFuild(lenght);
                requiredTime = Engine.GiveTimeFromDistance();
            }

            ResultDefense result = environmentBase.DropObstacles(this);
            bool lostShip = requiredFuel > _fuel;
            bool succes = !(lostShip || result.DeathCrew || result.DeathCrew);
            return new JourneyResult(succes, requiredFuel, requiredTime, result.DeathCrew, result.DestroyingShip, lostShip);
        }

        return new JourneyResult(false, 0, 0, false, false, true);
    }
}