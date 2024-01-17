using System.Diagnostics.CodeAnalysis;
using Contracts;

namespace Presentation.Console.Scenarios.ChangePassword;

public class ChangePasswordScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public ChangePasswordScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (!_currentUser.IsAdmin)
        {
            scenario = null;
            return false;
        }

        scenario = new ChangePasswordScenario(_service);
        return true;
    }
}