namespace Itmo.ObjectOrientedProgramming.Lab4.Consoles;

public interface IConsoleManager
{
    public void Write(string text);
    public string? Read();
    public void WriteLine();
}