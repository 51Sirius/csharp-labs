using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.ComputerCase;

public class ComputerCaseValidate : IValidatorBase
{
    public override ConfigurationResult Validate(Computer.Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));
        var result = new ConfigurationResult();
        ValidateWithMotherBoard(computer, result);
        ValidateWithVideoCards(computer, result);
        return result;
    }

    private static void ValidateWithMotherBoard(Computer.Computer computer, ConfigurationResult result)
    {
        if (!computer.ComputerCase.SupportedMotherboardFormFactors.Contains(computer.Motherboard.FormFactor))
        {
            result.AddMessage(new MessageBuilder().SetStatus(StatusType.Warning)
                .SetComment("Form factor is not supported").Build());
        }
    }

    private static void ValidateWithVideoCards(Computer.Computer computer, ConfigurationResult result)
    {
        foreach (VideoCard videoCard in computer.VideoCards)
        {
            if (videoCard.Width > computer.ComputerCase.MaxLength || videoCard.Height > computer.ComputerCase.MaxWidth)
            {
                result.AddMessage(new MessageBuilder().SetStatus(StatusType.Warning)
                    .SetComment("Size of video card unsuported").Build());
            }
        }
    }
}