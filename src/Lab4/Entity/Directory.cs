using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class Directory
{
    public Directory(string name, string path)
    {
        Name = name;
        Path = path;
        Files = new Collection<File>();
        Directories = new Collection<Directory>();
    }

    public string Name { get; private set; }
    public string Path { get; }
    public Collection<File> Files { get; private set; }
    public Collection<Directory> Directories { get; private set; }

    public override string ToString()
    {
        return $"Directory: {Name}, Path: {Path}, Files: {Files.Count}, Directories: {Directories.Count}";
    }
}