using System;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly IFileSystem fileSystem;
    private readonly string filePath;

    public FileDeleteCommand(IFileSystem fileSystem, string filePath)
    {
        this.fileSystem = fileSystem;
        this.filePath = filePath;
    }

    public void Execute()
    {
        string absolutePath = PathUtil.GetAbsolutePath(fileSystem.CurrentDirectory, filePath);

        if (fileSystem.FileExists(absolutePath))
        {
            if (fileSystem.DeleteFile(absolutePath))
            {
                Console.WriteLine($"File '{absolutePath}' deleted.");
            }
            else
            {
                Console.WriteLine($"Failed to delete file '{absolutePath}'.");
            }
        }
        else
        {
            Console.WriteLine($"File '{absolutePath}' does not exist.");
        }
    }
}