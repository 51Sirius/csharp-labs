using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Computer;

public class ComputerBuilder
{
    private Motherboard? _motherboard;
    private Processor? _processor;
    private Cooler.Cooler? _cooler;
    private Collection<RamMemory> _rams = new Collection<RamMemory>();
    private XmpProfile? _xmpProfile;
    private Collection<VideoCard> _videoCards = new Collection<VideoCard>();
    private ComputerCase.ComputerCase? _computerCase;
    private PowerUnit? _powerUnit;
    private WifiAdapter? _wifiAdapter;
    private Collection<SsdDrive> _ssdDrives = new Collection<SsdDrive>();
    private Collection<HardDrive> _hardDrives = new Collection<HardDrive>();
    private Bios.Bios? _bios;

    public ComputerBuilder(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));
        _motherboard = computer.Motherboard;
        _processor = computer.Processor;
        _cooler = computer.Cooler;
        _rams = computer.RamMemories;
        _xmpProfile = computer.XmpProfile;
        _videoCards = computer.VideoCards;
        _computerCase = computer.ComputerCase;
        _powerUnit = computer.PowerUnit;
        _wifiAdapter = computer.WifiAdapter;
        _ssdDrives = computer.SsdDrives;
        _hardDrives = computer.HardDrives;
        _bios = computer.Bios;
    }

    public ComputerBuilder()
    {
    }

    public ComputerBuilder SetMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public ComputerBuilder SetBios(Bios.Bios bios)
    {
        _bios = bios;
        return this;
    }

    public ComputerBuilder SetProcessor(Processor processor)
    {
        _processor = processor;
        return this;
    }

    public ComputerBuilder SetCooler(Cooler.Cooler cooler)
    {
        _cooler = cooler;
        return this;
    }

    public ComputerBuilder AddRamMemory(RamMemory ram)
    {
        _rams.Add(ram);
        return this;
    }

    public ComputerBuilder SetXmpProfile(XmpProfile xmpProfile)
    {
        _xmpProfile = xmpProfile;
        return this;
    }

    public ComputerBuilder AddVideoCard(VideoCard videoCard)
    {
        _videoCards.Add(videoCard);
        return this;
    }

    public ComputerBuilder SetComputerCase(ComputerCase.ComputerCase computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public ComputerBuilder SetPowerUnit(PowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public ComputerBuilder SetWifiAdapter(WifiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public ComputerBuilder AddSsdDrive(SsdDrive ssdDrive)
    {
        _ssdDrives.Add(ssdDrive);
        return this;
    }

    public ComputerBuilder AddHardDrive(HardDrive hardDrive)
    {
        _hardDrives.Add(hardDrive);
        return this;
    }

    public Computer Build()
    {
        return new Computer(
            _motherboard ?? throw new InvalidOperationException(),
            _processor ?? throw new InvalidOperationException(),
            _cooler ?? throw new InvalidOperationException(),
            _rams,
            _xmpProfile ?? new NullXmpProfile(),
            _videoCards,
            _computerCase ?? throw new InvalidOperationException(),
            _powerUnit ?? throw new InvalidOperationException(),
            _bios ?? throw new InvalidOperationException(),
            _wifiAdapter ?? new NullWifiAdapter(),
            _ssdDrives,
            _hardDrives);
    }
}