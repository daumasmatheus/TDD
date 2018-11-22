namespace Application.App2
{
    public class Product
    {
        public Product(string productName, decimal price, int stockQuantity, bool isAvaliableToSell)
        {
            ProductName = productName;
            Price = price;
            StockQuantity = stockQuantity;
            IsAvaliableToSell = isAvaliableToSell;
        }

        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAvaliableToSell { get; set; }
    }
}
