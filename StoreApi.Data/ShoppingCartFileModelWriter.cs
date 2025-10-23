namespace StoreApi.Data;

using Models;

public class ShoppingCartFileModelWriter : DataFileModelWriter<ShoppingCart>
{
    public ShoppingCartFileModelWriter()
        : base("data.json") { }
}  