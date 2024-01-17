using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class ComputerCaseBuilder
{
    private int _maxLength;
    private int _maxWidth;
    private Collection<string> _supportedMotherboardFormFactors = new Collection<string>();
    private int _dimensions;

    public ComputerCaseBuilder SetMaxLength(int maxLength)
    {
        _maxLength = maxLength;
        return this;
    }

    public ComputerCaseBuilder SetMaxWidth(int maxWidth)
    {
        _maxWidth = maxWidth;
        return this;
    }

    public ComputerCaseBuilder AddSupportedFormFactor(string formFactor)
    {
        _supportedMotherboardFormFactors.Add(formFactor);
        return this;
    }

    public ComputerCaseBuilder SetDimensions(int dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public ComputerCase.ComputerCase Build()
    {
        return new ComputerCase.ComputerCase(
            _maxLength,
            _maxWidth,
            _supportedMotherboardFormFactors,
            _dimensions);
    }
}