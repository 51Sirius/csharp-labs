using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class JourneyResult
{
    private bool succces;
    private double fuelCost;
    private double time;
    private bool destroyingShip;
    private bool lostShip;
    private bool deathCrew;

    public JourneyResult(bool succces, double fuelCost, double time, bool destroyingShip, bool deathCrew, bool lostShip)
    {
        this.succces = succces;
        this.fuelCost = fuelCost;
        this.time = time;
        this.destroyingShip = destroyingShip;
        this.deathCrew = deathCrew;
        this.lostShip = lostShip;
    }

    public bool DoneJourney { get; private set; }

    public static JourneyResult operator +(JourneyResult firstResult, JourneyResult secondResult)
    {
        if (secondResult != null && firstResult != null)
        {
            bool succces = firstResult.succces && secondResult.succces;
            double fuelCost = firstResult.fuelCost + secondResult.fuelCost;
            double time = firstResult.time + secondResult.time;
            bool destroyingShip = firstResult.destroyingShip || secondResult.destroyingShip;
            bool deathCrew = firstResult.deathCrew || secondResult.deathCrew;
            bool lostShip = firstResult.lostShip || secondResult.lostShip;
            return new JourneyResult(succces, fuelCost, time, destroyingShip, deathCrew, lostShip);
        }
        else
        {
            return new JourneyResult(false, 0, 0, false, false, false);
        }
    }

    public void JourneyComplete()
    {
        DoneJourney = true;
    }

    public bool IsFinished()
    {
        return this.deathCrew || this.destroyingShip || this.lostShip;
    }

    public Collection<double> GiveInfo()
    {
        var infoJourney = new Collection<double>();
        infoJourney.Add(this.fuelCost);
        infoJourney.Add(this.time);
        return infoJourney;
    }

    public JourneyResult Add(JourneyResult left, JourneyResult right)
    {
        throw new System.NotImplementedException();
    }

    public bool Equals(JourneyResult other)
    {
        if (other != null)
        {
            return this.deathCrew == other.deathCrew && this.lostShip == other.lostShip &&
                   this.succces == other.succces;
        }
        else
        {
            return false;
        }
    }
}