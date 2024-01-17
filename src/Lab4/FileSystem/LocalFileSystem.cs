using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string currentDirectory)
    {
        CurrentDirectory = currentDirectory;
    }

    public string CurrentDirectory { get; private set; }

    public bool Connect(string address, string mode = "local")
    {
        if (mode == null) throw new ArgumentNullException(nameof(mode));
        if (mode.ToLower(System.Globalization.CultureInfo.CurrentCulture) == "local")
        {
            string rootPath = Path.GetFullPath(address);
            CurrentDirectory = rootPath;
            Console.WriteLine($"Connected to local file system. Current directory: {CurrentDirectory}");
        }
        else
        {
            Console.WriteLine("Invalid mode for connection. Only local mode is supported.");
        }

        return true;
    }

    public void Disconnect()
    {
        CurrentDirectory = string.Empty;
        Console.WriteLine("Disconnected from the file system.");
    }

    public bool FileExists(string path)
    {
        string fullPath = Path.Combine(CurrentDirectory, path);
        return File.Exists(fullPath);
    }

    public bool IsDirectory(string path)
    {
        string fullPath = Path.Combine(CurrentDirectory, path);
        return Directory.Exists(fullPath);
    }

    public Collection<string> GetDirectoryContent(string path)
    {
        string fullPath = Path.Combine(CurrentDirectory, path);

        if (Directory.Exists(fullPath))
        {
            return new Collection<string>(Directory.GetFileSystemEntries(fullPath));
        }
        else
        {
            Console.WriteLine($"Directory '{fullPath}' does not exist.");
            return new Collection<string>();
        }
    }

    public string ReadFileContent(string path)
    {
        string fullPath = Path.Combine(CurrentDirectory, path);

        if (File.Exists(fullPath))
        {
            return File.ReadAllText(fullPath);
        }
        else
        {
            Console.WriteLine($"File '{fullPath}' does not exist.");
            return string.Empty;
        }
    }

    public bool MoveFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = Path.Combine(CurrentDirectory, sourcePath);
        string destinationFullPath = Path.Combine(CurrentDirectory, destinationPath);

        if (File.Exists(sourceFullPath))
        {
            File.Move(sourceFullPath, destinationFullPath);
            return true;
        }
        else
        {
            Console.WriteLine($"File '{sourceFullPath}' does not exist.");
            return false;
        }
    }

    public bool CopyFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = Path.Combine(CurrentDirectory, sourcePath);
        string destinationFullPath = Path.Combine(CurrentDirectory, destinationPath);

        if (File.Exists(sourceFullPath))
        {
            File.Copy(sourceFullPath, destinationFullPath);
            return true;
        }
        else
        {
            Console.WriteLine($"File '{sourceFullPath}' does not exist.");
            return false;
        }
    }

    public bool DeleteFile(string path)
    {
        string fullPath = Path.Combine(CurrentDirectory, path);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            return true;
        }
        else
        {
            Console.WriteLine($"File '{fullPath}' does not exist.");
            return false;
        }
    }

    public bool RenameFile(string path, string newName)
    {
        if (path == null) throw new ArgumentNullException(nameof(path));
        string fullPath = Path.Combine(CurrentDirectory, path);
        string? directoryPath = Path.GetDirectoryName(fullPath);
        if (directoryPath != null)
        {
            string newFullPath = Path.Combine(directoryPath, newName);

            if (File.Exists(fullPath))
            {
                File.Move(fullPath, newFullPath);
                return true;
            }
            else
            {
                Console.WriteLine($"File '{fullPath}' does not exist.");
                return false;
            }
        }

        return false;
    }
}