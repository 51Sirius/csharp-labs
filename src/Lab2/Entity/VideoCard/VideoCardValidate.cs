using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class VideoCardValidate : IValidatorBase
{
    public override ConfigurationResult Validate(Computer.Computer computer)
    {
        var result = new ConfigurationResult();
        if (computer == null) throw new ArgumentNullException(nameof(computer));
        foreach (VideoCard videoCard in computer.VideoCards)
        {
            if (!computer.Motherboard.ConnectionOptions.Contains(videoCard.PcieVersion))
                result.AddMessage(new MessageBuilder().SetStatus(StatusType.Warning).SetComment("Unsuport connection for videocard.").Build());
        }

        return result;
    }
}