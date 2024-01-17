using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class MotherboardBuilder
{
    private string? cpuSocket;
    private Collection<string>? connectionOptions;
    private int sataPorts;
    private string? chipset;
    private Collection<string> supportedMemoryFrequencies = new Collection<string>();
    private Collection<string> xmpProfiles = new Collection<string>();
    private string? ddrStandard;
    private int ramSlots;
    private string? formFactor;
    private Bios.Bios? bios;

    public MotherboardBuilder SetCpuSocket(string cpuSocket)
    {
        this.cpuSocket = cpuSocket;
        return this;
    }

    public MotherboardBuilder SetConnecttionOptions(Collection<string> connectionOptions)
    {
        this.connectionOptions = connectionOptions;
        return this;
    }

    public MotherboardBuilder SetSataPorts(int sataPorts)
    {
        this.sataPorts = sataPorts;
        return this;
    }

    public MotherboardBuilder SetChipset(string chipset)
    {
        this.chipset = chipset;
        return this;
    }

    public MotherboardBuilder AddSupportedMemoryFrequency(string frequency)
    {
        supportedMemoryFrequencies.Add(frequency);
        return this;
    }

    public MotherboardBuilder AddXmpProfile(string xmpProfile)
    {
        xmpProfiles.Add(xmpProfile);
        return this;
    }

    public MotherboardBuilder SetDdrStandard(string ddrStandard)
    {
        this.ddrStandard = ddrStandard;
        return this;
    }

    public MotherboardBuilder SetRamSlots(int ramSlots)
    {
        this.ramSlots = ramSlots;
        return this;
    }

    public MotherboardBuilder SetFormFactor(string formFactor)
    {
        this.formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder SetBiosAttributes(Bios.Bios biosAttributes)
    {
        bios = biosAttributes;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            cpuSocket ?? throw new InvalidOperationException(),
            connectionOptions ?? throw new InvalidOperationException(),
            sataPorts,
            chipset ?? throw new InvalidOperationException(),
            supportedMemoryFrequencies,
            xmpProfiles ?? throw new InvalidOperationException(),
            ddrStandard ?? throw new InvalidOperationException(),
            ramSlots,
            formFactor ?? throw new InvalidOperationException(),
            bios ?? throw new InvalidOperationException());
    }
}