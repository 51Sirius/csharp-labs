using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Adresats.Displays.DisplayDriver;

public class FileDisplayDriver : DisplayDriver
{
    private string _filePath;

    public FileDisplayDriver(string filePath, ConsoleColor color)
        : base(color)
    {
        _filePath = filePath;
    }

    public override void Clear()
    {
        File.WriteAllText(_filePath, string.Empty);
    }

    public override void DisplayText(string text)
    {
        File.AppendAllText(_filePath, text + Environment.NewLine);
    }

    public override void DisplayColoredText(string text)
    {
        Console.ForegroundColor = Color;
        File.AppendAllText(_filePath, text + Environment.NewLine);
        Console.ResetColor();
    }
}