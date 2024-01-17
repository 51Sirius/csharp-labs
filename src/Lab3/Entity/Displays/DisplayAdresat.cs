using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats.Displays;

public class DisplayAdresat : IAdresat
{
    private LoggerBase _logger;
    private Display _display;

    public DisplayAdresat(
        LoggerBase logger,
        Display display)
    {
        _logger = logger;
        _display = display;
    }

    public void SendMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        var decoratedMessage = new DisplayMessageLoggerDecorator(message, _logger);
        _display.SendMessage(message);
        decoratedMessage.ReceiveMessage();
    }
}