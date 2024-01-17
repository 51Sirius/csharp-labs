using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats.Messengers;

public class MessengerAdresat : IAdresat
{
    private LoggerBase _logger;
    private Messenger _messenger;

    public MessengerAdresat(
        LoggerBase logger, Messenger messenger)
    {
        _logger = logger;
        _messenger = messenger;
    }

    public void SendMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        var decoratedMessage = new MessengerMessageLoggerDecorator(message, _logger);
        _messenger.SendMessage(message);
        decoratedMessage.ReceiveMessage();
    }
}