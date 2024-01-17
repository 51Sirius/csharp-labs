using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class VideoCardBuilder
{
    private int _height;
    private int _width;
    private int _videoMemorySize;
    private string? _pcieVersion;
    private int _chipFrequency;
    private int _powerConsumption;

    public VideoCardBuilder SetHeight(int height)
    {
        _height = height;
        return this;
    }

    public VideoCardBuilder SetWidth(int width)
    {
        _width = width;
        return this;
    }

    public VideoCardBuilder SetVideoMemorySize(int videoMemorySize)
    {
        _videoMemorySize = videoMemorySize;
        return this;
    }

    public VideoCardBuilder SetPcieVersion(string pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public VideoCardBuilder SetChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public VideoCardBuilder SetPowerConsumptionInWatts(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public VideoCard Build()
    {
        return new VideoCard(
            _height,
            _width,
            _videoMemorySize,
            _pcieVersion ?? throw new InvalidOperationException(),
            _chipFrequency,
            _powerConsumption);
    }
}