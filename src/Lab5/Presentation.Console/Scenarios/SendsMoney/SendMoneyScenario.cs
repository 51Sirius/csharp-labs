using Contracts;
using Contracts.Bills;
using Spectre.Console;

namespace Presentation.Console.Scenarios.SendsMoney;

public class SendMoneyScenario : IScenario
{
    private readonly IUserService _billService;

    public SendMoneyScenario(IUserService billService)
    {
        _billService = billService;
    }

    public string Name => "Залить денег";

    public void Run()
    {
        float money = AnsiConsole.Ask<float>("Enter your pinCode");

        MoneyOperationResult result = _billService.SendMoney(money);

        string message = result switch
        {
            MoneyOperationResult.Success => "Successful login",
            MoneyOperationResult.InsufficientFunds => "Insufficient Funds on bill",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}