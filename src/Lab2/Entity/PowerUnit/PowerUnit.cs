using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class PowerUnit : ICloneable
{
    public PowerUnit(int peakLoadInWatts)
    {
        PeakLoadInWatts = peakLoadInWatts;
    }

    public int PeakLoadInWatts { get; private set; }

    public object Clone()
    {
        return new PowerUnit(PeakLoadInWatts);
    }

    public PowerUnit CreateNewPowerUnit(int newPeakLoadInWatts)
    {
        var newPowerUnit = (PowerUnit)Clone();
        newPowerUnit.PeakLoadInWatts = newPeakLoadInWatts;

        return newPowerUnit;
    }
}