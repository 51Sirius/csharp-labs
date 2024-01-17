using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Service.FileViewers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service;

public class CommandManager
{
    private readonly IFileSystem _fileSystem;
    private readonly IFileViewer _fileViewer;

    public CommandManager(IFileSystem fileSystem, IFileViewer fileViewer)
    {
        _fileSystem = fileSystem;
        _fileViewer = fileViewer;
    }

    public void ProcessCommand(string? command)
    {
        string[]? commandParts = command?.Split(' ');
        switch (commandParts?[0].ToLower(System.Globalization.CultureInfo.CurrentCulture))
        {
            case "connect":
                ConnectCommand(connectAddress: commandParts[1], mode: commandParts[3]);
                break;

            case "disconnect":
                DisconnectCommand();
                break;

            case "tree":
                TreeListCommand(depth: int.Parse(commandParts[3], CultureInfo.InvariantCulture));
                break;

            case "file":
                ProcessFileCommand(commandParts);
                break;

            default:
                Console.WriteLine("Invalid command. Try again.");
                break;
        }
    }

    private void ConnectCommand(string connectAddress, string mode)
    {
        ICommand connectCommand = new ConnectCommand(_fileSystem, connectAddress, mode);
        connectCommand.Execute();
    }

    private void DisconnectCommand()
    {
        ICommand disconnectCommand = new DisconnectCommand(_fileSystem);
        disconnectCommand.Execute();
    }

    private void TreeListCommand(int depth)
    {
        ICommand treeListCommand = new TreeListCommand(_fileSystem, new PackOfSymbols(), depth);
        treeListCommand.Execute();
    }

    private void ProcessFileCommand(string[]? commandParts)
    {
        switch (commandParts?[1].ToLower(CultureInfo.CurrentCulture))
        {
            case "show":
                FileShowCommand(filePath: commandParts[2], mode: commandParts[4]);
                break;

            case "move":
                FileMoveCommand(sourcePath: commandParts[2], destinationPath: commandParts[3]);
                break;

            case "copy":
                FileCopyCommand(sourcePath: commandParts[2], destinationPath: commandParts[3]);
                break;

            case "delete":
                FileDeleteCommand(filePath: commandParts[2]);
                break;

            case "rename":
                FileRenameCommand(filePath: commandParts[2], newName: commandParts[3]);
                break;

            default:
                Console.WriteLine("Invalid file command. Try again.");
                break;
        }
    }

    private void FileShowCommand(string filePath, string mode)
    {
        ICommand fileShowCommand = new FileShowCommand(_fileViewer, _fileSystem, filePath, mode);
        fileShowCommand.Execute();
    }

    private void FileMoveCommand(string sourcePath, string destinationPath)
    {
        ICommand fileMoveCommand = new FileMoveCommand(_fileSystem, sourcePath, destinationPath);
        fileMoveCommand.Execute();
    }

    private void FileCopyCommand(string sourcePath, string destinationPath)
    {
        ICommand fileCopyCommand = new FileCopyCommand(_fileSystem, sourcePath, destinationPath);
        fileCopyCommand.Execute();
    }

    private void FileDeleteCommand(string filePath)
    {
        ICommand fileDeleteCommand = new FileDeleteCommand(_fileSystem, filePath);
        fileDeleteCommand.Execute();
    }

    private void FileRenameCommand(string filePath, string newName)
    {
        ICommand fileRenameCommand = new FileRenameCommand(_fileSystem, filePath, newName);
        fileRenameCommand.Execute();
    }
}