using System.Diagnostics.CodeAnalysis;
using Contracts;

namespace Presentation.Console.Scenarios.AddBill;

public class AddBillScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;

    public AddBillScenarioProvider(
        IUserService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new AddBillScenario(_service);
        return true;
    }
}