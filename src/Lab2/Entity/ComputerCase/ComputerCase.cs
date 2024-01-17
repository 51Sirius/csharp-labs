using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.ComputerCase;

public class ComputerCase : ICloneable
{
    public ComputerCase(int maxLength, int maxWidth, Collection<string> supportedFormFactors, int dimensions)
    {
        MaxLength = maxLength;
        MaxWidth = maxWidth;
        SupportedMotherboardFormFactors = supportedFormFactors;
        Dimensions = dimensions;
    }

    public int MaxLength { get; private set; }
    public int MaxWidth { get; private set; }
    public Collection<string> SupportedMotherboardFormFactors { get; private set; }
    public int Dimensions { get; private set; }

    public object Clone()
    {
        return new ComputerCase(MaxLength, MaxWidth, new Collection<string>(SupportedMotherboardFormFactors), Dimensions);
    }

    public ComputerCase CreateNewComputerCase(int newMaxLength, int newMaxWidth, Collection<string> newSupportedFormFactors, int newDimensions)
    {
        var newComputerCase = (ComputerCase)Clone();
        newComputerCase.MaxLength = newMaxLength;
        newComputerCase.MaxWidth = newMaxWidth;
        newComputerCase.SupportedMotherboardFormFactors = new Collection<string>(newSupportedFormFactors);
        newComputerCase.Dimensions = newDimensions;

        return newComputerCase;
    }
}