using Contracts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.ShowsOperationsHistory;

public class ShowOperationHistoryScenario : IScenario
{
    private readonly IUserService _billService;

    public ShowOperationHistoryScenario(IUserService billService)
    {
        _billService = billService;
    }

    public string Name => "Показать хистори";

    public void Run()
    {
        string message = _billService.ShowOperationHistory();

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}