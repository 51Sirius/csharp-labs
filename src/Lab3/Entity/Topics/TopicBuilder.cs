using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Topic;

public class TopicBuilder
{
    private string? _title;
    private IAdresat? _adresat;

    public TopicBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }

    public TopicBuilder SetAdresat(IAdresat adresat)
    {
        _adresat = adresat;
        return this;
    }

    public Topic Build()
    {
        return new Topic(
            _title ?? throw new InvalidOperationException(),
            _adresat ?? throw new InvalidOperationException());
    }
}