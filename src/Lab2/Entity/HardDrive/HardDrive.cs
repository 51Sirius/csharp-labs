using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class HardDrive : ICloneable
{
    public HardDrive(int capacity, int spindleSpeed, int powerConsumption, string connectionOptions)
    {
        CapacityInGB = capacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
        ConnectionOptions = connectionOptions;
    }

    public int CapacityInGB { get; private set; }
    public int SpindleSpeed { get; private set; }
    public int PowerConsumption { get; private set; }
    public string ConnectionOptions { get; private set; }

    public object Clone()
    {
        return new HardDrive(CapacityInGB, SpindleSpeed, PowerConsumption, ConnectionOptions);
    }

    public HardDrive CreateNewHardDrive(int newCapacity, int newSpindleSpeed, int newPowerConsumption, string newConnectionOptions)
    {
        var newHardDrive = (HardDrive)Clone();
        newHardDrive.CapacityInGB = newCapacity;
        newHardDrive.SpindleSpeed = newSpindleSpeed;
        newHardDrive.PowerConsumption = newPowerConsumption;
        newHardDrive.ConnectionOptions = newConnectionOptions;

        return newHardDrive;
    }
}