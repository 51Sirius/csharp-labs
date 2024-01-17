using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class PowerUnitValidate : IValidatorBase
{
    public override ConfigurationResult Validate(Computer.Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));
        var result = new ConfigurationResult();
        if (computer.AllPowerConsumption() > computer.PowerUnit.PeakLoadInWatts)
        {
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Warning)
                .SetComment("Used more power").Build());
        }

        return result;
    }
}