using System.Diagnostics.CodeAnalysis;
using Contracts;

namespace Presentation.Console.Scenarios.Login;

public class LoginAdminScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public LoginAdminScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new LoginAdminScenario(_service);
        return true;
    }
}