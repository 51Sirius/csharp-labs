using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly IFileSystem fileSystem;
    private readonly string filePath;
    private readonly string newName;

    public FileRenameCommand(IFileSystem fileSystem, string filePath, string newName)
    {
        this.fileSystem = fileSystem;
        this.filePath = filePath;
        this.newName = newName;
    }

    public void Execute()
    {
        string absolutePath = PathUtil.GetAbsolutePath(fileSystem.CurrentDirectory, filePath);
        string? directoryPath = Path.GetDirectoryName(absolutePath);
        if (directoryPath == null) throw new ArgumentNullException(nameof(directoryPath));
        string newFullPath = Path.Combine(directoryPath, newName);

        if (fileSystem.FileExists(absolutePath))
        {
            if (fileSystem.RenameFile(absolutePath, newName))
            {
                Console.WriteLine($"File '{absolutePath}' renamed to '{newFullPath}'.");
            }
            else
            {
                Console.WriteLine($"Failed to rename file '{absolutePath}'.");
            }
        }
        else
        {
            Console.WriteLine($"File '{absolutePath}' does not exist.");
        }
    }
}