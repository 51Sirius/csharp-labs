using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats.Displays.DisplayDriver;

public abstract class DisplayDriver
{
    protected DisplayDriver(ConsoleColor color)
    {
        Color = color;
    }

    public ConsoleColor Color { get; protected set; }

    public virtual void Clear()
    {
        Console.Clear();
    }

    public virtual void DisplayText(string text)
    {
        Console.WriteLine(text);
    }

    public virtual void DisplayColoredText(string text)
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}