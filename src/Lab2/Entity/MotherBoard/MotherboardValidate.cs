using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class MotherboardValidate : IValidatorBase
{
    public override ConfigurationResult Validate(Computer.Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));
        var result = new ConfigurationResult();
        ValidateWithProcessor(computer, result);
        ValidateWithWifiAdapter(computer, result);
        ValidateWithRam(computer, result);
        return result;
    }

    private static void ValidateWithProcessor(Computer.Computer computer, ConfigurationResult result)
    {
        if (computer.Motherboard.CpuSocket != computer.Processor.Socket)
        {
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Error).SetComment("Socket is not supported")
                .Build());
        }
    }

    private static void ValidateWithWifiAdapter(Computer.Computer computer, ConfigurationResult result)
    {
        if (!computer.Motherboard.ConnectionOptions.Contains(computer.WifiAdapter.PcieVersion) && computer.WifiAdapter is not NullWifiAdapter)
        {
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Warning)
                .SetComment("WifiAdapter is not supported")
                .Build());
        }
    }

    private static void ValidateWithRam(Computer.Computer computer, ConfigurationResult result)
    {
        if (computer.RamMemories.Count > computer.Motherboard.RamSlots)
        {
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Information).SetComment("More rams that need")
                .Build());
        }
    }
}
