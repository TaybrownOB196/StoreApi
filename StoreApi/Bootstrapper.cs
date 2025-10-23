using Microsoft.Extensions.DependencyInjection;

namespace StoreApi;

using StoreApi.Infra;
using StoreApi.Data;
using StoreApi.Data.Models;

public static class Bootstrapper
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IShoppingCartModelOperator, ShoppingCartModelOperator>();
    }

    public static void RegisterDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IReadObjects<ShoppingCart>, ShoppingCartFileModelReader>();
        services.AddScoped<IWriteObjects<ShoppingCart>, ShoppingCartFileModelWriter>();
    }
}