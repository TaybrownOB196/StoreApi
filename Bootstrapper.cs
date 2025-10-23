using Microsoft.Extensions.DependencyInjection;

namespace StoreApi;

using StoreApi.Infra;
using StoreApi.Models;

public static class Bootstrapper
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IShoppingCartModelOperator, ShoppingCartModelOperator>();
        services.AddScoped<IReadObjects<ShoppingCart>, ShoppingCartModelReader>();
        services.AddScoped<IWriteObjects<ShoppingCart>, ShoppingCartModelWriter>();
    }
}