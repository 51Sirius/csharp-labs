using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.FileViewers;

public class ConsoleFileViewer : IFileViewer
{
    public void ViewFileContent(string content)
    {
        Console.WriteLine("File Content:");
        Console.WriteLine(content);
    }
}