using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class CoolerValidate : IValidatorBase
{
    public override ConfigurationResult Validate(Computer.Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));
        var result = new ConfigurationResult();
        if (computer.Processor.ThermalDesignPower > computer.Cooler.MaxTdpInWatts)
        {
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Warning)
                .SetComment("Power more then TDP").Build());
        }

        if (!computer.Cooler.SupportedSockets.Contains(computer.Processor.Socket))
        {
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Error)
                .SetComment("Unsupported socket").Build());
        }

        return result;
    }
}