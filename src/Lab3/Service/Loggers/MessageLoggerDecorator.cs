using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service.Loggers;

public class MessageLoggerDecorator : Message
{
    private readonly LoggerBase logger;

    public MessageLoggerDecorator(Message message, LoggerBase logger)
        : base(message)
    {
        this.logger = logger;
    }

    public void NotReceiveMessage()
    {
        LogMessage($"Не получил сообщение {Title}, т.к. недостаточный уровень важности");
    }

    public void ReceiveMessage()
    {
        LogMessage($"Получил сообщение {Title}");
    }

    private void LogMessage(string message)
    {
        logger.LogMessage("Адресат", $"{message}");
    }
}