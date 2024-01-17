using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats.Users;

public class UserAdresat : IAdresat
{
    private LoggerBase _logger;
    private User _user;

    public UserAdresat(
        User user,
        LoggerBase logger)
    {
        _user = user;
        _logger = logger;
    }

    public void SendMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        var decorateMessage = new UserMessageLoggerDecorator(message, _logger);
        _user.Send(message);
        decorateMessage.ReceiveMessage();
    }
}