namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class File
{
    public File(string name, string path, long size)
    {
        Name = name;
        Path = path;
        Size = size;
    }

    public string Name { get; }
    public string Path { get; }
    public long Size { get; }

    public override string ToString()
    {
        return $"File: {Name}, Path: {Path}, Size: {Size} bytes";
    }
}