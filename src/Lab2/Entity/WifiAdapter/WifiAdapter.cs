using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class WifiAdapter : ICloneable
{
    public WifiAdapter(
        string wifiStandardVersion,
        bool hasBluetoothModule,
        string pcieVersion,
        int powerConsumption)
    {
        WifiStandardVersion = wifiStandardVersion;
        HasBluetoothModule = hasBluetoothModule;
        PcieVersion = pcieVersion;
        PowerConsumption = powerConsumption;
    }

    public string WifiStandardVersion { get; private set; }
    public bool HasBluetoothModule { get; private set; }
    public string PcieVersion { get; private set; }
    public int PowerConsumption { get; private set; }

    public object Clone()
    {
        return new WifiAdapter(WifiStandardVersion, HasBluetoothModule, PcieVersion, PowerConsumption);
    }

    public WifiAdapter CreateNewWifiAdapter(
        string newWifiStandardVersion,
        bool newHasBluetoothModule,
        string newPcieVersion,
        int newPowerConsumption)
    {
        var newWifiAdapter = (WifiAdapter)Clone();
        newWifiAdapter.WifiStandardVersion = newWifiStandardVersion;
        newWifiAdapter.HasBluetoothModule = newHasBluetoothModule;
        newWifiAdapter.PcieVersion = newPcieVersion;
        newWifiAdapter.PowerConsumption = newPowerConsumption;

        return newWifiAdapter;
    }
}