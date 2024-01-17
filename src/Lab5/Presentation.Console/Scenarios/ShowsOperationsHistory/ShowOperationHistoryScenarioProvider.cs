using System.Diagnostics.CodeAnalysis;
using Contracts;

namespace Presentation.Console.Scenarios.ShowsOperationsHistory;

public class ShowOperationHistoryScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public ShowOperationHistoryScenarioProvider(
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

        scenario = new ShowOperationHistoryScenario(_service);
        return true;
    }
}