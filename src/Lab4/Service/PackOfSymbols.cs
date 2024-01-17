namespace Itmo.ObjectOrientedProgramming.Lab4.Service;

public class PackOfSymbols : IPackOfSymbols
{
    public string FileSymbol { get; private set; } = "[]";
    public string FolderSymbol { get; private set; } = "|";
    public string Indentation { get; private set; } = "    ";
}