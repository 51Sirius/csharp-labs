using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service;

public class Filter : IAdresat
{
    private IAdresat _adresat;
    private int _importanceLevel;
    private LoggerBase _logger;

    public Filter(IAdresat adresat, int importanceLevel, LoggerBase logger)
    {
        _adresat = adresat;
        _logger = logger;
        _importanceLevel = importanceLevel;
    }

    public void SendMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        var decorateMessage = new MessageLoggerDecorator(message, _logger);
        if (message.ImportanceLevel >= _importanceLevel)
        {
            _adresat.SendMessage(message);
            decorateMessage.ReceiveMessage();
        }
        else
        {
            decorateMessage.NotReceiveMessage();
        }
    }
}