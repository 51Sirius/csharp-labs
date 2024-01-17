using Itmo.ObjectOrientedProgramming.Lab4.Consoles;
using Itmo.ObjectOrientedProgramming.Lab4.Service;
using Itmo.ObjectOrientedProgramming.Lab4.Service.FileViewers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Test
{
    [Fact]
    public void Test1()
    {
        IFileSystem fileSystem = new LocalFileSystem("K:\\");
        IFileViewer fileViewer = new ConsoleFileViewer();
        var consoleManager = new ProgrammManager(
            new CommandManager(fileSystem, fileViewer),
            new TestConsoleManager(new string[] { "exit" })); // "connect K:\\ -m local\n", "file show 1.txt -m console\n",

        Assert.True(consoleManager.Run());
    }
}