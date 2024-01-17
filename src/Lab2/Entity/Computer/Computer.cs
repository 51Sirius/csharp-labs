using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Computer;

public class Computer
{
    public Computer(
        Motherboard motherboard,
        Processor processor,
        Cooler.Cooler cooler,
        Collection<RamMemory> rams,
        XmpProfile xmpProfile,
        Collection<VideoCard> videoCards,
        ComputerCase.ComputerCase computerCase,
        PowerUnit powerUnit,
        Bios.Bios bios,
        WifiAdapter wifiAdapter,
        Collection<SsdDrive> ssdDrives,
        Collection<HardDrive> hardDrives)
    {
        Motherboard = motherboard;
        Processor = processor;
        Cooler = cooler;
        RamMemories = rams;
        XmpProfile = xmpProfile;
        VideoCards = videoCards;
        ComputerCase = computerCase;
        PowerUnit = powerUnit;
        WifiAdapter = wifiAdapter;
        SsdDrives = ssdDrives;
        HardDrives = hardDrives;
        Bios = bios;
    }

    public Motherboard Motherboard { get; private set; }
    public Bios.Bios Bios { get; private set; }
    public Processor Processor { get; private set; }
    public Cooler.Cooler Cooler { get; private set; }
    public Collection<RamMemory> RamMemories { get; private set; }
    public XmpProfile XmpProfile { get; private set; }
    public Collection<VideoCard> VideoCards { get; private set; }
    public ComputerCase.ComputerCase ComputerCase { get; private set; }
    public PowerUnit PowerUnit { get; private set; }
    public WifiAdapter WifiAdapter { get; private set; }
    public Collection<SsdDrive> SsdDrives { get; private set; }
    public Collection<HardDrive> HardDrives { get; private set; }

    public int AllPowerConsumption()
    {
        int powerConsumption = 0;
        foreach (HardDrive hardDrive in HardDrives)
        {
            powerConsumption += hardDrive.PowerConsumption;
        }

        foreach (SsdDrive ssdDrive in SsdDrives)
        {
            powerConsumption += ssdDrive.PowerConsumption;
        }

        foreach (VideoCard videoCard in VideoCards)
        {
            powerConsumption += videoCard.PowerConsumption;
        }

        foreach (RamMemory ram in RamMemories)
        {
            powerConsumption += ram.PowerConsumption;
        }

        powerConsumption += Processor.PowerConsumption;
        powerConsumption += WifiAdapter.PowerConsumption;
        return powerConsumption;
    }
}