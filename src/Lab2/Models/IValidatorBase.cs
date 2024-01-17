using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public abstract class IValidatorBase
{
    public virtual ConfigurationResult Validate(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));
        return new ConfigurationResult();
    }
}