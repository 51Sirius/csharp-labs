using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

public class MessageBuilder
{
    private string? _title;
    private string? _body;
    private int _importanceLevel;

    public MessageBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }

    public MessageBuilder SetBody(string body)
    {
        _body = body;
        return this;
    }

    public MessageBuilder SetImportanceLevel(int importanceLevel)
    {
        if (importanceLevel < 0)
        {
            throw new ArgumentException("Уровень важности не может быть отрицательным.");
        }

        _importanceLevel = importanceLevel;
        return this;
    }

    public Message Build()
    {
        return new Message(
            _title ?? throw new InvalidOperationException(),
            _body ?? throw new InvalidOperationException(),
            _importanceLevel);
    }
}