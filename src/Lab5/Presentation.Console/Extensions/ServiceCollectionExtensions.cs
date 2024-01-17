using Microsoft.Extensions.DependencyInjection;
using Presentation.Console.Scenarios.AddBill;
using Presentation.Console.Scenarios.Login;

namespace Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();
        collection.AddScoped<IScenarioProvider, LoginAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddBillScenarioProvider>();
        return collection;
    }
}