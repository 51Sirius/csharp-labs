using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Cooler;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Repository
{
    public Collection<Motherboard> Motherboards { get; private set; } = new Collection<Motherboard>();
    public Collection<ComputerCase> ComputerCases { get; private set; } = new Collection<ComputerCase>();
    public Collection<Cooler> Coolers { get; private set; } = new Collection<Cooler>();
    public Collection<HardDrive> HardDrives { get; private set; } = new Collection<HardDrive>();
    public Collection<PowerUnit> PowerUnits { get; private set; } = new Collection<PowerUnit>();
    public Collection<Processor> Processors { get; private set; } = new Collection<Processor>();
    public Collection<RamMemory> RamMemories { get; private set; } = new Collection<RamMemory>();
    public Collection<SsdDrive> SsdDrives { get; private set; } = new Collection<SsdDrive>();
    public Collection<VideoCard> VideoCards { get; private set; } = new Collection<VideoCard>();
    public Collection<WifiAdapter> WifiAdapters { get; private set; } = new Collection<WifiAdapter>();
    public Collection<XmpProfile> XmpProfiles { get; private set; } = new Collection<XmpProfile>();

    public void AddVideoCard(VideoCard videoCard)
    {
        VideoCards.Add(videoCard);
    }

    public void AddMotherBoard(Motherboard motherboard)
    {
        Motherboards.Add(motherboard);
    }

    public void AddComputerCase(ComputerCase computerCase)
    {
        ComputerCases.Add(computerCase);
    }

    public void AddCooler(Cooler cooler)
    {
        Coolers.Add(cooler);
    }

    public void AddHardDrive(HardDrive hhDrive)
    {
        HardDrives.Add(hhDrive);
    }

    public void AddPowerUnit(PowerUnit powerUnit)
    {
        PowerUnits.Add(powerUnit);
    }

    public void AddHardDrives(PowerUnit powerUnit)
    {
        PowerUnits.Add(powerUnit);
    }

    public void AddProcessor(Processor processor)
    {
        Processors.Add(processor);
    }

    public void AddRamMemorie(RamMemory ram)
    {
        RamMemories.Add(ram);
    }

    public void AddSsdDrive(SsdDrive ssdDrive)
    {
        SsdDrives.Add(ssdDrive);
    }

    public void AddVideoCards(VideoCard videoCard)
    {
        VideoCards.Add(videoCard);
    }

    public void AddWifiAdapters(WifiAdapter wifiAdapter)
    {
        WifiAdapters.Add(wifiAdapter);
    }

    public void AddXmpProfile(XmpProfile xmpProfile)
    {
        XmpProfiles.Add(xmpProfile);
    }
}