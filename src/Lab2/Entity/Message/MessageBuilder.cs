using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Message;

public class MessageBuilder
{
    private StatusType _status;
    private string? _comment;

    public MessageBuilder SetStatus(StatusType status)
    {
        _status = status;
        return this;
    }

    public MessageBuilder SetComment(string comment)
    {
        _comment = comment;
        return this;
    }

    public Message Build()
    {
        if (_status == StatusType.Success && string.IsNullOrWhiteSpace(_comment))
        {
            throw new ArgumentException("A success message must have a non-empty comment.");
        }

        return new Message(_status, _comment ?? throw new InvalidOperationException());
    }
}