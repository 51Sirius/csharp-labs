using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Bios;

public class BiosBuilder
{
    private string? _type;
    private string? _version;
    private Collection<string> supportedProcessors = new Collection<string>();

    public BiosBuilder SetType(string type)
    {
        _type = type;
        return this;
    }

    public BiosBuilder SetVersion(string version)
    {
        _version = version;
        return this;
    }

    public BiosBuilder AddSupportedProcessor(string processor)
    {
        supportedProcessors.Add(processor);
        return this;
    }

    public Bios Build()
    {
        return new Bios(
            _type ?? throw new InvalidOperationException(),
            _version ?? throw new InvalidOperationException(),
            supportedProcessors);
    }
}