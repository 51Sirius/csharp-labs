using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class SsdDrive : ICloneable
{
    public SsdDrive(string connectionType, int capacity, int maxSpeed, int powerConsumption)
    {
        ConnectionType = connectionType;
        CapacityInGB = capacity;
        MaxSpeedInMBps = maxSpeed;
        PowerConsumption = powerConsumption;
    }

    public string ConnectionType { get; private set; }
    public int CapacityInGB { get; private set; }
    public int MaxSpeedInMBps { get; private set; }
    public int PowerConsumption { get; private set; }

    public object Clone()
    {
        return new SsdDrive(ConnectionType, CapacityInGB, MaxSpeedInMBps, PowerConsumption);
    }

    public SsdDrive CreateNewSsdDrive(string newConnectionType, int newCapacity, int newMaxSpeed, int newPowerConsumption)
    {
        var newSsdDrive = (SsdDrive)Clone();
        newSsdDrive.ConnectionType = newConnectionType;
        newSsdDrive.CapacityInGB = newCapacity;
        newSsdDrive.MaxSpeedInMBps = newMaxSpeed;
        newSsdDrive.PowerConsumption = newPowerConsumption;

        return newSsdDrive;
    }
}