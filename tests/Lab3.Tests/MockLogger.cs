using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service.Loggers;

public class MockLogger : LoggerBase
{
    public string LastLoggedName { get; private set; } = string.Empty;
    public string LastLoggedMessage { get; private set; } = string.Empty;

    public override void LogMessage(string username, string message)
    {
        LastLoggedName = username;
        LastLoggedMessage = message;
    }
}