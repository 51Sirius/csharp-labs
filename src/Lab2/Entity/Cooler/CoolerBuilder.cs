using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Cooler;

public class CoolerBuilder
{
    private string? _dimensions;
    private Collection<string> _supportedSockets = new Collection<string>();
    private int _maxTdpInWatts;

    public CoolerBuilder SetDimensions(string dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public CoolerBuilder AddSupportedSocket(string socket)
    {
        _supportedSockets.Add(socket);
        return this;
    }

    public CoolerBuilder SetMaxTdpInWatts(int maxTdp)
    {
        _maxTdpInWatts = maxTdp;
        return this;
    }

    public Entity.Cooler.Cooler Build()
    {
        return new Entity.Cooler.Cooler(
            _dimensions ?? throw new InvalidOperationException(),
            _supportedSockets ?? throw new InvalidOperationException(),
            _maxTdpInWatts);
    }
}