using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Topic;

public class Topic
{
    public Topic(string title, IAdresat adresat)
    {
        Title = title;
        Adresat = adresat;
    }

    public string Title { get; private set; }
    public IAdresat Adresat { get; private set; }

    public void SendMessage(string messageTitle, string messageBody, int importanceLevel)
    {
        var newMessage = new Message(messageTitle, messageBody, importanceLevel);
        TransmitMessage(newMessage);
    }

    private void TransmitMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        Adresat.SendMessage(message);
    }
}