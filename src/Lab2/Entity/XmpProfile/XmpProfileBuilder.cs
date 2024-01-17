using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class XmpProfileBuilder
{
    private string? _timings;
    private float _voltage;
    private string? _frequency;

    public XmpProfileBuilder SetTimings(string timings)
    {
        _timings = timings;
        return this;
    }

    public XmpProfileBuilder SetVoltage(float voltage)
    {
        _voltage = voltage;
        return this;
    }

    public XmpProfileBuilder SetFrequency(string frequency)
    {
        _frequency = frequency;
        return this;
    }

    public XmpProfile Build()
    {
        return new XmpProfile(
            _timings ?? throw new InvalidOperationException(),
            _voltage,
            _frequency ?? throw new InvalidOperationException());
    }
}