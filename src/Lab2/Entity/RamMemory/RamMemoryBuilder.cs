using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class RamMemoryBuilder
{
    private int _memorySizeInGB;
    private Collection<string> _supportedJedecPairs = new Collection<string>();
    private Collection<string> _xmpProfiles = new Collection<string>();
    private Collection<string> _formFactors = new Collection<string>();
    private string? _ddrStandardVersion;
    private int _powerConsumptionInWatts;

    public RamMemoryBuilder SetMemorySizeInGB(int memorySize)
    {
        _memorySizeInGB = memorySize;
        return this;
    }

    public RamMemoryBuilder AddSupportedJedecPair(string jedecPair)
    {
        _supportedJedecPairs.Add(jedecPair);
        return this;
    }

    public RamMemoryBuilder AddXmpProfile(string xmpProfile)
    {
        _xmpProfiles.Add(xmpProfile);
        return this;
    }

    public RamMemoryBuilder AddFormFactor(string formFactor)
    {
        _formFactors.Add(formFactor);
        return this;
    }

    public RamMemoryBuilder SetDdrStandardVersion(string ddrStandard)
    {
        _ddrStandardVersion = ddrStandard;
        return this;
    }

    public RamMemoryBuilder SetPowerConsumptionInWatts(int powerConsumption)
    {
        _powerConsumptionInWatts = powerConsumption;
        return this;
    }

    public RamMemory Build()
    {
        return new RamMemory(
            _memorySizeInGB,
            _supportedJedecPairs,
            _xmpProfiles,
            _formFactors,
            _ddrStandardVersion ?? throw new InvalidOperationException(),
            _powerConsumptionInWatts);
    }
}