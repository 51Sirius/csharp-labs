using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Journey
{
    private readonly Spaceship _ship;
    private readonly Collection<EnvironmentBase> _environments;

    public Journey(Spaceship ship)
    {
        _ship = ship;
        _environments = new Collection<EnvironmentBase>();
    }

    public void AddRout(EnvironmentBase environment)
    {
        _environments.Add(environment);
    }

    public JourneyResult JourneyCalculate()
    {
        var result = new JourneyResult(true, 0, 0, false, false, false);
        foreach (EnvironmentBase environment in _environments)
        {
            result += environment.PassingRoute(_ship) ?? throw new InvalidOperationException();
            if (result.IsFinished())
            {
                return result;
            }
        }

        result.JourneyComplete();
        return result;
    }

    public Spaceship? OptimapShip(Spaceship first, Spaceship second)
    {
        var journeyFirst = new Journey(first);
        foreach (EnvironmentBase environment in _environments)
        {
            journeyFirst.AddRout(environment);
        }

        var journeySecond = new Journey(second);
        foreach (EnvironmentBase environment in _environments)
        {
            journeySecond.AddRout(environment);
        }

        JourneyResult resultFirst = journeyFirst.JourneyCalculate();
        JourneyResult resultSecond = journeySecond.JourneyCalculate();
        if (resultFirst.DoneJourney && resultSecond.DoneJourney)
        {
            if (resultFirst.GiveInfo()[0] < resultSecond.GiveInfo()[0])
            {
                return first;
            }
            else
            {
                return second;
            }
        }
        else
        {
            if (resultFirst.DoneJourney)
            {
                return first;
            }
            else if (resultSecond.DoneJourney)
            {
                return second;
            }
            else
            {
                return null;
            }
        }
    }
}