using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private readonly IFileSystem fileSystem;
    private readonly string address;
    private readonly string mode;

    public ConnectCommand(IFileSystem fileSystem, string address, string mode)
    {
        this.fileSystem = fileSystem;
        this.address = address;
        this.mode = mode;
    }

    public void Execute()
    {
        if (fileSystem.Connect(address, mode))
        {
            Console.WriteLine($"Connected to {address} in {mode} mode");
        }
        else
        {
            Console.WriteLine($"Failed to connect to {address}");
        }
    }
}