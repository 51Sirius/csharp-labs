using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    private readonly IFileSystem fileSystem;

    public DisconnectCommand(IFileSystem fileSystem)
    {
        this.fileSystem = fileSystem;
    }

    public void Execute()
    {
        fileSystem.Disconnect();
        Console.WriteLine("Disconnected from the file system.");
    }
}