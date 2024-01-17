using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Consoles;

public class TestConsoleManager : IConsoleManager
{
    private string[] _commands;
    private int _count;

    public TestConsoleManager(string[] commands, int count = 0)
    {
        _commands = commands;
        _count = count;
    }

    public void Write(string text)
    {
        Console.Write(text);
    }

    public string? Read()
    {
        string commandToComplete = _commands[_count];
        _count++;
        return commandToComplete;
    }

    public void WriteLine()
    {
        Console.WriteLine();
    }
}