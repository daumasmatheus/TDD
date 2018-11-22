using System;

namespace Application.App2
{
    public class StoreOperations
    {
        public string Sell(Product product, int quantity)
        {
            if (product.StockQuantity <= 0)
                return "This product is not avaliable in stock anymore";

            if (!product.IsAvaliableToSell)
                return "This Product is not avaliable to sale";

            product.StockQuantity -= quantity;

            return "Product sold successfully";
        }

        public string Stock(Product product)
        {
            if (String.IsNullOrEmpty(product.ProductName))
                return "The name of the product should be informed.";

            if (product.Price <= 0)
                return "The price of the product should be informed";

            return "Product stocked successfully";
        }
    }
}
