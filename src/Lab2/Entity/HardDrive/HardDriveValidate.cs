using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public class HardDriveValidate : IValidatorBase
{
    public override ConfigurationResult Validate(Computer.Computer computer)
    {
        var result = new ConfigurationResult();
        if (computer == null) throw new ArgumentNullException(nameof(computer));
        foreach (HardDrive hardDrive in computer.HardDrives)
        {
            if (!computer.Motherboard.ConnectionOptions.Contains(hardDrive.ConnectionOptions))
                result.AddMessage(new MessageBuilder().SetStatus(StatusType.Warning).SetComment("Unsuport connection for harddrive.").Build());
        }

        return result;
    }
}