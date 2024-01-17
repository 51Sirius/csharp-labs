using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Consoles;

public class ConsoleManager : IConsoleManager
{
    public void Write(string text)
    {
        Console.Write(text);
    }

    public string? Read()
    {
        return Console.ReadLine();
    }

    public void WriteLine()
    {
        Console.WriteLine();
    }
}