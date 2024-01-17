using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

public class Configuration
{
    private List<IValidatorBase> _validators = new List<IValidatorBase>
    {
        new BiosValidate(),
        new ComputerCaseValidate(),
        new CoolerValidate(),
        new HardDriveValidate(),
        new PowerUnitValidate(),
        new SsdDriveValidate(),
        new VideoCardValidate(),
        new XmpProfileValidate(),
        new MotherboardValidate(),
        new ComputerValidate(),
    };

    public ConfigurationResult Validate(Computer computer)
    {
        var result = new ConfigurationResult();
        foreach (IValidatorBase validator in _validators)
        {
            result.Add(validator.Validate(computer));
        }

        return result;
    }
}