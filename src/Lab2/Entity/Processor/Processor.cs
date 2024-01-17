using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class Processor : ICloneable
{
    public Processor(
        double coreFrequency,
        int numberOfCores,
        string socket,
        bool integratedGraphics,
        Collection<string> supportedMemoryFrequencies,
        int tdp,
        int powerConsumption,
        string model)
    {
        CoreFrequencyInGHz = coreFrequency;
        NumberOfCores = numberOfCores;
        Socket = socket;
        IntegratedGraphics = integratedGraphics;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        ThermalDesignPower = tdp;
        PowerConsumption = powerConsumption;
        Model = model;
    }

    public string Model { get; private set; }
    public double CoreFrequencyInGHz { get; private set; }
    public int NumberOfCores { get; private set; }
    public string Socket { get; private set; }
    public bool IntegratedGraphics { get; private set; }
    public Collection<string> SupportedMemoryFrequencies { get; private set; }
    public int ThermalDesignPower { get; private set; }
    public int PowerConsumption { get; private set; }

    public object Clone()
    {
        var clonedMemoryFrequencies = new Collection<string>(SupportedMemoryFrequencies);

        return new Processor(
            CoreFrequencyInGHz,
            NumberOfCores,
            Socket,
            IntegratedGraphics,
            clonedMemoryFrequencies,
            ThermalDesignPower,
            PowerConsumption,
            Model);
    }

    public Processor CreateNewProcessor(
        double newCoreFrequency,
        int newNumberOfCores,
        string newSocket,
        bool newIntegratedGraphics,
        Collection<string> newSupportedMemoryFrequencies,
        int newTdp,
        int newPowerConsumption,
        string newModel)
    {
        var clonedMemoryFrequencies = new Collection<string>(newSupportedMemoryFrequencies);

        var newProcessor = (Processor)Clone();
        newProcessor.CoreFrequencyInGHz = newCoreFrequency;
        newProcessor.NumberOfCores = newNumberOfCores;
        newProcessor.Socket = newSocket;
        newProcessor.IntegratedGraphics = newIntegratedGraphics;
        newProcessor.SupportedMemoryFrequencies = clonedMemoryFrequencies;
        newProcessor.ThermalDesignPower = newTdp;
        newProcessor.PowerConsumption = newPowerConsumption;
        newProcessor.Model = newModel;

        return newProcessor;
    }
}