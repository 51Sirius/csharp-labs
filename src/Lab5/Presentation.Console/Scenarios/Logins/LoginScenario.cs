using Contracts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Войти";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Введите ваше имя");

        LoginResult result = _userService.Login(username);

        string message = result switch
        {
            LoginResult.Success => "Успешная авторизация",
            LoginResult.NotFound => "Пользователь не найден",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}