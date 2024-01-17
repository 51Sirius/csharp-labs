namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class NullWifiAdapter : WifiAdapter
{
    private new const string WifiStandardVersion = " ";
    private new const bool HasBluetoothModule = false;
    private new const string PcieVersion = " ";
    private new const int PowerConsumption = 0;
    public NullWifiAdapter()
        : base(WifiStandardVersion, HasBluetoothModule, PcieVersion, PowerConsumption)
    {
    }
}