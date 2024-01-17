using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class HardDriveBuilder
{
    private int _capacity;
    private int _spindleSpeed;
    private int _powerConsumption;
    private string? _connectionOptions;

    public HardDriveBuilder SetCapacityInGB(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public HardDriveBuilder SetSpindleSpeedInRPM(int spindleSpeed)
    {
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public HardDriveBuilder SetPowerConsumptionInWatts(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public HardDriveBuilder SetConnectionOptions(string connectionOptions)
    {
        _connectionOptions = connectionOptions;
        return this;
    }

    public HardDrive Build()
    {
        return new HardDrive(
            _capacity,
            _spindleSpeed,
            _powerConsumption,
            _connectionOptions ?? throw new ArgumentNullException());
    }
}