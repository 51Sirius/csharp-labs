using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class VideoCard : ICloneable
{
    public VideoCard(
        int height,
        int width,
        int videoMemorySize,
        string pcieVersion,
        int chipFrequency,
        int powerConsumption)
    {
        Height = height;
        Width = width;
        VideoMemorySize = videoMemorySize;
        PcieVersion = pcieVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public int Height { get; private set; }
    public int Width { get; private set; }
    public int VideoMemorySize { get; private set; }
    public string PcieVersion { get; private set; }
    public int ChipFrequency { get; private set; }
    public int PowerConsumption { get; private set; }

    public object Clone()
    {
        return new VideoCard(Height, Width, VideoMemorySize, PcieVersion, ChipFrequency, PowerConsumption);
    }

    public VideoCard CreateNewVideoCard(
        int newHeight,
        int newWidth,
        int newVideoMemorySize,
        string newPcieVersion,
        int newChipFrequency,
        int newPowerConsumption)
    {
        var newVideoCard = (VideoCard)Clone();
        newVideoCard.Height = newHeight;
        newVideoCard.Width = newWidth;
        newVideoCard.VideoMemorySize = newVideoMemorySize;
        newVideoCard.PcieVersion = newPcieVersion;
        newVideoCard.ChipFrequency = newChipFrequency;
        newVideoCard.PowerConsumption = newPowerConsumption;

        return newVideoCard;
    }
}