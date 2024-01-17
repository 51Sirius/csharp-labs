using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Cooler;

public class Cooler : ICloneable
{
    public Cooler(string dimensions, Collection<string> supportedSockets, int maxTdp)
    {
        Dimensions = dimensions;
        SupportedSockets = supportedSockets;
        MaxTdpInWatts = maxTdp;
    }

    public string Dimensions { get; private set; }
    public Collection<string> SupportedSockets { get; private set; }
    public int MaxTdpInWatts { get; private set; }

    public object Clone()
    {
        return new Cooler(Dimensions, new Collection<string>(SupportedSockets), MaxTdpInWatts);
    }

    public Cooler CreateNewCooler(string newDimensions, Collection<string> newSupportedSockets, int newMaxTdp)
    {
        var newCooler = (Cooler)Clone();
        newCooler.Dimensions = newDimensions;
        newCooler.SupportedSockets = new Collection<string>(newSupportedSockets);
        newCooler.MaxTdpInWatts = newMaxTdp;

        return newCooler;
    }
}