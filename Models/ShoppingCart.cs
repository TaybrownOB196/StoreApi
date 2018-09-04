using System.Collections.Generic;

namespace StoreApi.Models 
{
    public class ShoppingCart 
    {
        public ShoppingCart() 
        {
            _user = new User();
            _items = new List<Item>();
        }

        public long Id { get; set; }
        private User _user;
        public User User 
        { 
            get
            {
                return _user;
            }
        }
        private List<Item> _items { get; set; }
        public List<Item> Items 
        {
            get 
            { 
                return _items;
            }
        }
        public int ItemCount 
        { 
            get 
            {
                return _items.Count;
            } 
        }
    }
}