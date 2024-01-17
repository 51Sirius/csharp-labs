using Contracts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.ChangePassword;

public class ChangePasswordScenario : IScenario
{
    private readonly IUserService _service;

    public ChangePasswordScenario(IUserService billService)
    {
        _service = billService;
    }

    public string Name => "Сменить пароль администратора";

    public void Run()
    {
        long billId = AnsiConsole.Ask<long>("Введите номер карты");
        string pinCode = AnsiConsole.Ask<string>("Введите пин код");

        _service.CreateNewBill(billId, pinCode);

        string message = "Пароль изменен";
        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}