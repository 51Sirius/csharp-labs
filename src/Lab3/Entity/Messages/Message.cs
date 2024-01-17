using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

public class Message : ICloneable
{
    public Message(string title, string body, int importanceLevel)
    {
        Title = title;
        Body = body;
        ImportanceLevel = importanceLevel;
    }

    public Message(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        Color = message.Color;
        Title = message.Title;
        Body = message.Body;
        ImportanceLevel = message.ImportanceLevel;
    }

    public string Title { get; private set; }
    public string Body { get; private set; }
    public int ImportanceLevel { get; private set; }
    public ConsoleColor Color { get; private set; }

    public object Clone()
    {
        return new Message(Title, Body, ImportanceLevel);
    }

    public Message EditMessage(string newBody)
    {
        var newMessage = (Message)Clone();
        newMessage.Body = newBody;
        return newMessage;
    }
}