namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class PowerUnitBuilder
{
    private int _peakLoadInWatts;

    public PowerUnitBuilder SetPeakLoadInWatts(int peakLoadInWatts)
    {
        _peakLoadInWatts = peakLoadInWatts;
        return this;
    }

    public PowerUnit Build()
    {
        return new PowerUnit(_peakLoadInWatts);
    }
}