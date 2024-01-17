using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface IFileSystem
{
    public string CurrentDirectory { get; }
    bool Connect(string address, string mode);
    void Disconnect();
    Collection<string> GetDirectoryContent(string path);
    string ReadFileContent(string path);
    bool MoveFile(string sourcePath, string destinationPath);
    bool CopyFile(string sourcePath, string destinationPath);
    bool DeleteFile(string path);
    bool RenameFile(string path, string newName);
    bool FileExists(string path);
    bool IsDirectory(string path);
}