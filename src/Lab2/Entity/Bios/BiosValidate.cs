using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Bios;

public class BiosValidate : IValidatorBase
{
    public override ConfigurationResult Validate(Computer.Computer computer)
    {
        var result = new ConfigurationResult();
        if (computer == null) throw new ArgumentNullException(nameof(computer));
        if (!computer.Bios.SupportedProcessors.Contains(computer.Processor.Model))
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Warning).SetComment("BIOS is not compatible with processor.").Build());
        return result;
    }
}