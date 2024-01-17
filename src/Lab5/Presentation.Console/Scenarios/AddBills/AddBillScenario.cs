using Contracts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.AddBill;

public class AddBillScenario : IScenario
{
    private readonly IUserService _service;

    public AddBillScenario(IUserService billService)
    {
        _service = billService;
    }

    public string Name => "Сделать счет";

    public void Run()
    {
        long billId = AnsiConsole.Ask<long>("Введите номер карты");
        string pinCode = AnsiConsole.Ask<string>("Введите пин код");

        _service.CreateNewBill(billId, pinCode);

        string message = "Новый счет открыт";
        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}