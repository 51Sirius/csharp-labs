using Contracts;
using Contracts.Bills;
using Spectre.Console;

namespace Presentation.Console.Scenarios.GetMoneys;

public class GetMoneyScenario : IScenario
{
    private readonly IUserService _billService;

    public GetMoneyScenario(IUserService billService)
    {
        _billService = billService;
    }

    public string Name => "Снять денег";

    public void Run()
    {
        float money = AnsiConsole.Ask<float>("Введите количество денег которые вы хотите снять");

        MoneyOperationResult result = _billService.GetMoney(money);

        string message = result switch
        {
            MoneyOperationResult.Success => "Деньги переведены",
            MoneyOperationResult.InsufficientFunds => "Недостаточно средств на счёте",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}