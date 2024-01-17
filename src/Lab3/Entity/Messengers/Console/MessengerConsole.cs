using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class MessengerConsole : IMessengerConsole
{
    public void DisplayMessage(string text)
    {
        Console.WriteLine(text);
    }
}