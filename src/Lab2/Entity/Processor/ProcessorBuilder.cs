using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class ProcessorBuilder
{
    private double _coreFrequencyInGHz;
    private int _numberOfCores;
    private string? _socket;
    private bool _integratedGraphics;
    private Collection<string> _supportedMemoryFrequencies = new Collection<string>();
    private int _thermalDesignPower;
    private int _powerConsumptionInWatts;
    private string? _model;

    public ProcessorBuilder SetCoreFrequencyInGHz(double coreFrequency)
    {
        _coreFrequencyInGHz = coreFrequency;
        return this;
    }

    public ProcessorBuilder SetModel(string model)
    {
        _model = model;
        return this;
    }

    public ProcessorBuilder SetNumberOfCores(int numberOfCores)
    {
        _numberOfCores = numberOfCores;
        return this;
    }

    public ProcessorBuilder SetSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ProcessorBuilder SetIntegratedGraphics(bool hasIntegratedGraphics)
    {
        _integratedGraphics = hasIntegratedGraphics;
        return this;
    }

    public ProcessorBuilder AddSupportedMemoryFrequency(string frequency)
    {
        _supportedMemoryFrequencies.Add(frequency);
        return this;
    }

    public ProcessorBuilder SetThermalDesignPower(int tdp)
    {
        _thermalDesignPower = tdp;
        return this;
    }

    public ProcessorBuilder SetPowerConsumptionInWatts(int powerConsumption)
    {
        _powerConsumptionInWatts = powerConsumption;
        return this;
    }

    public Processor Build()
    {
        return new Processor(
            _coreFrequencyInGHz,
            _numberOfCores,
            _socket ?? throw new InvalidOperationException(),
            _integratedGraphics,
            _supportedMemoryFrequencies,
            _thermalDesignPower,
            _powerConsumptionInWatts,
            _model ?? throw new InvalidOperationException());
    }
}