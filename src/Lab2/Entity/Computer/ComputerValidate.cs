using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Computer;

public class ComputerValidate : IValidatorBase
{
    public override ConfigurationResult Validate(Computer computer)
    {
        var result = new ConfigurationResult();
        if (computer == null) throw new ArgumentNullException(nameof(computer));
        if (!computer.RamMemories.Any())
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Error).SetComment("Computer without RAM").Build());
        if (!computer.SsdDrives.Any() && !computer.HardDrives.Any())
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Error).SetComment("Computer without drivers").Build());
        if (!computer.VideoCards.Any() && !computer.Processor.IntegratedGraphics)
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Error).SetComment("Computer without videodriver").Build());
        if (computer.PowerUnit is null)
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Error).SetComment("Computer without PowerUnit").Build());
        if (computer.Cooler is null)
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Error).SetComment("Computer without coller").Build());
        return result;
    }
}