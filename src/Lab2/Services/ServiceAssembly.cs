using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ServiceAssembly
{
    public ServiceAssembly(ConfigurationResult configurationResult)
    {
        if (configurationResult == null) throw new ArgumentNullException(nameof(configurationResult));
        foreach (Entity.Message.Message message in configurationResult.Messages)
        {
            if (message.Status == StatusType.Error) ResultBuild = ResultBuild.Refusel;
            if (message.Status == StatusType.Warning) ResultBuild = ResultBuild.Comment;
        }
    }

    public ResultBuild ResultBuild { get; private set; } = ResultBuild.Succes;
}