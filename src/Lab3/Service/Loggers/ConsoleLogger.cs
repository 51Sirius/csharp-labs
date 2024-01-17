using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service.Loggers;

public class ConsoleLogger : LoggerBase
{
    public override void LogMessage(string username, string message)
    {
        Console.WriteLine($"[Логгер] Адресат {username}: {message}");
    }
}