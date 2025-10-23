namespace StoreApi.Data;

using Models;

public class ShoppingCartFileModelReader : DataFileModelReader<ShoppingCart>
{
    public ShoppingCartFileModelReader()
        : base("data.json") { }
}