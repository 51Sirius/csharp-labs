using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class XmpProfile : ICloneable
{
    public XmpProfile(string timings, float voltage, string frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Timings { get; private set; }
    public float Voltage { get; private set; }
    public string Frequency { get; private set; }

    public object Clone()
    {
        return new XmpProfile(Timings, Voltage, Frequency);
    }

    public XmpProfile CreateNewXmpProfile(string newTimings, float newVoltage, string newFrequency)
    {
        var newXmpProfile = (XmpProfile)Clone();
        newXmpProfile.Timings = newTimings;
        newXmpProfile.Voltage = newVoltage;
        newXmpProfile.Frequency = newFrequency;

        return newXmpProfile;
    }
}