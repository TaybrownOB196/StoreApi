namespace StoreApi.Models
{
    public class Item 
    {
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        protected void SetPrice(decimal price) 
        {
            Price = price;
        }

        public long Id { get; set; }
        public long SerialNumber { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }
    }
}