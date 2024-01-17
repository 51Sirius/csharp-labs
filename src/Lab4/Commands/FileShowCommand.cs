using System;
using Itmo.ObjectOrientedProgramming.Lab4.Service;
using Itmo.ObjectOrientedProgramming.Lab4.Service.FileViewers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private readonly IFileViewer fileViewer;
    private readonly IFileSystem fileSystem;
    private readonly string filePath;
    private readonly string mode;

    public FileShowCommand(IFileViewer fileViewer, IFileSystem fileSystem, string filePath, string mode)
    {
        this.fileViewer = fileViewer;
        this.fileSystem = fileSystem;
        this.filePath = filePath;
        this.mode = mode;
    }

    public void Execute()
    {
        string absolutePath = PathUtil.GetAbsolutePath(fileSystem.CurrentDirectory, filePath);
        string content = fileSystem.ReadFileContent(absolutePath);

        if (mode.ToLower(System.Globalization.CultureInfo.CurrentCulture) == "console")
        {
            fileViewer.ViewFileContent(content);
        }
        else
        {
            Console.WriteLine("Invalid mode for file viewing. Try again.");
        }
    }
}