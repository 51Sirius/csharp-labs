using System;
using System.Collections.ObjectModel;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private const int StandartDepth = 1;
    private readonly IFileSystem _fileSystem;
    private readonly int _depth;
    private readonly IPackOfSymbols _symbols;

    public TreeListCommand(IFileSystem fileSystem, IPackOfSymbols symbols, int depth = StandartDepth)
    {
        _fileSystem = fileSystem;
        _depth = depth;
        _symbols = symbols;
    }

    public void Execute()
    {
        string currentDirectory = _fileSystem.CurrentDirectory;
        PrintDirectoryTree(currentDirectory, _depth);
    }

    private void PrintDirectoryTree(string directoryPath, int currentDepth)
    {
        if (currentDepth < 0)
        {
            return;
        }

        if (_symbols.Indentation != null)
        {
            string indent = new string(_symbols.Indentation[0], (_depth - currentDepth) * _symbols.Indentation.Length);
            Console.WriteLine($"{indent}{_symbols.FolderSymbol} [{Path.GetFileName(directoryPath)}]");
        }

        Collection<string> content = _fileSystem.GetDirectoryContent(directoryPath);

        foreach (string entry in content)
        {
            if (_fileSystem.IsDirectory(entry))
            {
                PrintDirectoryTree(entry, currentDepth - 1);
            }
            else
            {
                if (_symbols.Indentation != null)
                {
                    string fileIndent = new string(
                        _symbols.Indentation[0],
                        (_depth - currentDepth + 1) * _symbols.Indentation.Length);
                    Console.WriteLine($"{fileIndent}{_symbols.FolderSymbol} {Path.GetFileName(entry)}");
                }
            }
        }
    }
}