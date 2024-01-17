using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class SsdDriveBuilder
{
    private string? _connectionType;
    private int _capacityInGB;
    private int _maxSpeedInMBps;
    private int _powerConsumptionInWatts;

    public SsdDriveBuilder SetConnectionType(string connectionType)
    {
        _connectionType = connectionType;
        return this;
    }

    public SsdDriveBuilder SetCapacityInGB(int capacity)
    {
        _capacityInGB = capacity;
        return this;
    }

    public SsdDriveBuilder SetMaxSpeedInMBps(int maxSpeed)
    {
        _maxSpeedInMBps = maxSpeed;
        return this;
    }

    public SsdDriveBuilder SetPowerConsumptionInWatts(int powerConsumption)
    {
        _powerConsumptionInWatts = powerConsumption;
        return this;
    }

    public SsdDrive Build()
    {
        return new SsdDrive(
            _connectionType ?? throw new InvalidOperationException(),
            _capacityInGB,
            _maxSpeedInMBps,
            _powerConsumptionInWatts);
    }
}