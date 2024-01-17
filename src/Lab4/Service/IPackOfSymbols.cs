namespace Itmo.ObjectOrientedProgramming.Lab4.Service;

public interface IPackOfSymbols
{
    public string? FileSymbol { get; }
    public string? FolderSymbol { get; }
    public string? Indentation { get; }
}