using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class Motherboard : ICloneable
{
    public Motherboard(
        string cpuSocket,
        Collection<string> connectionOptions,
        int sataPorts,
        string chipset,
        Collection<string> supportedMemoryFrequencies,
        Collection<string>? xmpProfiles,
        string ddrStandard,
        int ramSlots,
        string formFactor,
        Bios.Bios bios)
    {
        CpuSocket = cpuSocket;
        ConnectionOptions = connectionOptions;
        SataPorts = sataPorts;
        Chipset = chipset;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        XmpProfiles = xmpProfiles;
        DdrStandard = ddrStandard;
        RamSlots = ramSlots;
        FormFactor = formFactor;
        Bios = bios;
    }

    public string CpuSocket { get; private set; }
    public Collection<string> ConnectionOptions { get; private set; }
    public int SataPorts { get; private set; }
    public string Chipset { get; private set; }
    public Collection<string> SupportedMemoryFrequencies { get; private set; }
    public Collection<string>? XmpProfiles { get; private set; }
    public string DdrStandard { get; private set; }
    public int RamSlots { get; private set; }
    public string FormFactor { get; private set; }
    public Bios.Bios Bios { get; private set; }

    public object Clone()
    {
        var clonedBios = (Bios.Bios)Bios.Clone();
        return new Motherboard(
            CpuSocket,
            new Collection<string>(ConnectionOptions),
            SataPorts,
            Chipset,
            new Collection<string>(SupportedMemoryFrequencies),
            XmpProfiles,
            DdrStandard,
            RamSlots,
            FormFactor,
            clonedBios);
    }

    public Motherboard CreateNewMotherboard(
        string newCpuSocket,
        Collection<string> newConnectionOptions,
        int newSataPorts,
        string newChipset,
        Collection<string> newSupportedMemoryFrequencies,
        Collection<string>? newXmpProfiles,
        string newDdrStandard,
        int newRamSlots,
        string newFormFactor)
    {
        var clonedBios = (Bios.Bios)Bios.Clone();
        var newMotherboard = (Motherboard)Clone();
        newMotherboard.CpuSocket = newCpuSocket;
        newMotherboard.ConnectionOptions = new Collection<string>(newConnectionOptions);
        newMotherboard.SataPorts = newSataPorts;
        newMotherboard.Chipset = newChipset;
        newMotherboard.SupportedMemoryFrequencies = new Collection<string>(newSupportedMemoryFrequencies);
        newMotherboard.XmpProfiles = newXmpProfiles;
        newMotherboard.DdrStandard = newDdrStandard;
        newMotherboard.RamSlots = newRamSlots;
        newMotherboard.FormFactor = newFormFactor;
        newMotherboard.Bios = clonedBios;

        return newMotherboard;
    }
}
