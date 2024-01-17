using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class WifiAdapterBuilder
{
    private string? _wifiStandardVersion;
    private bool _hasBluetoothModule;
    private string? _pcieVersion;
    private int _powerConsumption;

    public WifiAdapterBuilder SetWifiStandardVersion(string wifiStandardVersion)
    {
        _wifiStandardVersion = wifiStandardVersion;
        return this;
    }

    public WifiAdapterBuilder SetHasBluetoothModule(bool hasBluetoothModule)
    {
        _hasBluetoothModule = hasBluetoothModule;
        return this;
    }

    public WifiAdapterBuilder SetPcieVersion(string pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public WifiAdapterBuilder SetPowerConsumptionInWatts(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WifiAdapter Build()
    {
        return new WifiAdapter(
            _wifiStandardVersion ?? throw new InvalidOperationException(),
            _hasBluetoothModule,
            _pcieVersion ?? throw new InvalidOperationException(),
            _powerConsumption);
    }
}