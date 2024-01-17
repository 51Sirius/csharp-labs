using Contracts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.ShowsBalance;

public class ShowBalanceScenario : IScenario
{
    private readonly IUserService _billService;

    public ShowBalanceScenario(IUserService billService)
    {
        _billService = billService;
    }

    public string Name => "Показать баланс";

    public void Run()
    {
        float balance = _billService.ShowBalance();
        string message = $"Ваш баланс: {balance}";

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}