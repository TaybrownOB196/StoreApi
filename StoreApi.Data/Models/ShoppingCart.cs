using System.Collections.Generic;

namespace StoreApi.Data.Models 
{
    public class ShoppingCart 
    {
        public ShoppingCart() 
        {
            Items = new List<Item>();
        }

        public long Id { get; set; }
        public User User { get; set; }
        public List<Item> Items { get; set; }
    }
}