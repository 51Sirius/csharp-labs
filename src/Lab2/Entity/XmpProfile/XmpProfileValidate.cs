using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class XmpProfileValidate : IValidatorBase
{
    public override ConfigurationResult Validate(Computer.Computer computer)
    {
        var result = new ConfigurationResult();
        if (computer == null) throw new ArgumentNullException(nameof(computer));
        if (!computer.Processor.SupportedMemoryFrequencies.Contains(computer.XmpProfile.Frequency) && computer.XmpProfile is not NullXmpProfile)
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Error).SetComment("Frequency XMP is unsupport").Build());
        return result;
    }
}