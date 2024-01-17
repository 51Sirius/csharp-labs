using Contracts;
using Contracts.Bills;
using Spectre.Console;

namespace Presentation.Console.Scenarios.LoginBill;

public class LoginBillScenario : IScenario
{
    private readonly IUserService _billService;

    public LoginBillScenario(IUserService billService)
    {
        _billService = billService;
    }

    public string Name => "Войти в счет";

    public void Run()
    {
        long billId = AnsiConsole.Ask<long>("Введите номер карты");
        string pinCode = AnsiConsole.Ask<string>("Введите пин код");

        BillLoginResult result = _billService.LoginBill(billId, pinCode);

        string message = result switch
        {
            BillLoginResult.Success => "Успешная авторизация",
            BillLoginResult.Wrong => "Что то пошло не так",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}