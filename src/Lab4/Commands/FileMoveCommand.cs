using System;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : ICommand
{
    private readonly IFileSystem fileSystem;
    private readonly string sourcePath;
    private readonly string destinationPath;

    public FileMoveCommand(IFileSystem fileSystem, string sourcePath, string destinationPath)
    {
        this.fileSystem = fileSystem;
        this.sourcePath = sourcePath;
        this.destinationPath = destinationPath;
    }

    public void Execute()
    {
        string absoluteSourcePath = PathUtil.GetAbsolutePath(fileSystem.CurrentDirectory, sourcePath);
        string absoluteDestinationPath = PathUtil.GetAbsolutePath(fileSystem.CurrentDirectory, destinationPath);

        if (fileSystem.FileExists(absoluteSourcePath))
        {
            if (fileSystem.MoveFile(absoluteSourcePath, absoluteDestinationPath))
            {
                Console.WriteLine($"File '{absoluteSourcePath}' moved to '{absoluteDestinationPath}'.");
            }
            else
            {
                Console.WriteLine($"Failed to move file '{absoluteSourcePath}'.");
            }
        }
        else
        {
            Console.WriteLine($"File '{absoluteSourcePath}' does not exist.");
        }
    }
}
