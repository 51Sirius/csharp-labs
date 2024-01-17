using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;

public class ConfigurationResult
{
    public ConfigurationResult()
    {
        Messages = new Collection<Message>();
    }

    public Collection<Message> Messages { get; private set; }

    public void AddMessage(Message message)
    {
        Messages.Add(message);
    }

    public void Add(ConfigurationResult configurationResult)
    {
        if (configurationResult == null) throw new ArgumentNullException(nameof(configurationResult));
        foreach (Message message in configurationResult.Messages)
        {
            Messages.Add(message);
        }
    }
}