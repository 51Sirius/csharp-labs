using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Consoles;

public class ProgrammManager
{
    private CommandManager _commandManager;
    private IConsoleManager _consoleManager;

    public ProgrammManager(CommandManager commandManager, IConsoleManager consoleManager)
    {
        _consoleManager = consoleManager;
        _commandManager = commandManager;
    }

    public bool Run()
    {
        while (true)
        {
            _consoleManager.Write("Enter command: ");
            string? command = _consoleManager.Read();
            if (command == "exit")
            {
                break;
            }

            _commandManager.ProcessCommand(command);
            _consoleManager.WriteLine();
        }

        return true;
    }
}