using System.Diagnostics.CodeAnalysis;
using Contracts;
using Presentation.Console.Scenarios.GetMoneys;

namespace Presentation.Console.Scenarios.GetMoney;

public class GetMoneyScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public GetMoneyScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new GetMoneyScenario(_service);
        return true;
    }
}