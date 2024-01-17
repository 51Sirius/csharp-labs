using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class RamMemory : ICloneable
{
    public RamMemory(
        int memorySize,
        Collection<string> supportedJedecPairs,
        Collection<string> xmpProfiles,
        Collection<string> formFactors,
        string ddrStandardVersion,
        int powerConsumption)
    {
        MemorySizeInGB = memorySize;
        SupportedJedecPairs = supportedJedecPairs;
        XmpProfiles = xmpProfiles;
        FormFactors = formFactors;
        DdrStandardVersion = ddrStandardVersion;
        PowerConsumption = powerConsumption;
    }

    public int MemorySizeInGB { get; private set; }
    public Collection<string> SupportedJedecPairs { get; private set; }
    public Collection<string> XmpProfiles { get; private set; }
    public Collection<string> FormFactors { get; private set; }
    public string DdrStandardVersion { get; private set; }
    public int PowerConsumption { get; private set; }

    public object Clone()
    {
        var clonedSupportedJedecPairs = new Collection<string>(SupportedJedecPairs);
        var clonedXmpProfiles = new Collection<string>(XmpProfiles);
        var clonedFormFactors = new Collection<string>(FormFactors);

        return new RamMemory(
            MemorySizeInGB,
            clonedSupportedJedecPairs,
            clonedXmpProfiles,
            clonedFormFactors,
            DdrStandardVersion,
            PowerConsumption);
    }

    public RamMemory CreateNewRamMemory(
        int newMemorySize,
        Collection<string> newSupportedJedecPairs,
        Collection<string> newXmpProfiles,
        Collection<string> newFormFactors,
        string newDdrStandardVersion,
        int newPowerConsumption)
    {
        var clonedSupportedJedecPairs = new Collection<string>(newSupportedJedecPairs);
        var clonedXmpProfiles = new Collection<string>(newXmpProfiles);
        var clonedFormFactors = new Collection<string>(newFormFactors);

        var newRamMemory = (RamMemory)Clone();
        newRamMemory.MemorySizeInGB = newMemorySize;
        newRamMemory.SupportedJedecPairs = clonedSupportedJedecPairs;
        newRamMemory.XmpProfiles = clonedXmpProfiles;
        newRamMemory.FormFactors = clonedFormFactors;
        newRamMemory.DdrStandardVersion = newDdrStandardVersion;
        newRamMemory.PowerConsumption = newPowerConsumption;

        return newRamMemory;
    }
}