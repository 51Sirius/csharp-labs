using Contracts;
using Spectre.Console;

namespace Presentation.Console.Scenarios.Login;

public class LoginAdminScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginAdminScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Войти в админку";

    public void Run()
    {
        _ = AnsiConsole.Ask<string>("Введите пароль от админки");

        LoginResult result = _userService.LoginAdmin();

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