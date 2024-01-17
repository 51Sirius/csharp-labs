using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Bios;

public class Bios : ICloneable
{
    public Bios(string type, string version, Collection<string> supportedProcessors)
    {
        Type = type;
        Version = version;
        SupportedProcessors = supportedProcessors;
    }

    public string Type { get; private set; }
    public string Version { get; private set; }
    public Collection<string> SupportedProcessors { get; private set; }

    public object Clone()
    {
        return new Bios(Type, Version, new Collection<string>(SupportedProcessors));
    }

    public Bios CreateNewBios(string? newVersion, Collection<string>? newSupportedProcessors, string? newType)
    {
        var newBios = (Bios)Clone();
        newBios.Type = newType ?? Type;
        newBios.Version = newVersion ?? Version;
        newBios.SupportedProcessors = newSupportedProcessors ?? SupportedProcessors;

        return newBios;
    }
}