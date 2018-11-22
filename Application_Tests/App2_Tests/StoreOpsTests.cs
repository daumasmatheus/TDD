using Application.App2;
using NUnit.Framework;

namespace Application_Tests.App2_Tests
{
    [TestFixture]
    class StoreOpsTests
    {
        private Product prod;
        private StoreOperations _storeOps;        

        [SetUp]
        public void SetUp()
        {
            _storeOps = new StoreOperations();
        }

        [TearDown]
        public void TearDown()
        {
            prod = null;
        }


        [Test]
        public void Sell_ProductInStock_ShouldAllowTheSale()
        {
            prod = new Product("Tshirt", 120, 20, true);

            var sellProductResult = _storeOps.Sell(prod, 1);
            var expectedSaleMessage = "Product sold successfully";

            Assert.That(sellProductResult, Is.EqualTo(expectedSaleMessage));
        }

        [Test]
        public void Sell_ProductInStock_ShouldDecreaseTheItemInStock()
        {
            prod = new Product("Tshirt", 120, 20, true);
            _storeOps.Sell(prod, 1);

            var expectedNewStockQuantity = 19;

            Assert.That(prod.StockQuantity, Is.EqualTo(expectedNewStockQuantity));
        }

        [Test]
        public void Sell_ProductNotAvaliableToSell_ShouldNotBeAllowedToSell()
        {
            prod = new Product("Tshirt", 120, 20, false);


            var sellProductResult = _storeOps.Sell(prod, 1);
            var expectedSaleMessage = "This Product is not avaliable to sale";

            Assert.That(sellProductResult, Is.EqualTo(expectedSaleMessage));
        }

        [Test]
        public void Sell_ProductNotAvaliableInStock_ShouldNotBeAllowedToSell()
        {
            prod = new Product("Tshirt", 120, 0, true);

            var sellProductResult = _storeOps.Sell(prod, 1);
            var expectedSaleMessage = "This product is not avaliable in stock anymore";

            Assert.That(sellProductResult, Is.EqualTo(expectedSaleMessage));
        }

        [Test]
        public void Store_ProductCorrectlyInformed_ShouldStoreNewProduct()
        {
            prod = new Product("Tshirt", 120, 20, true);

            var storeProductResult = _storeOps.Stock(prod);
            var expectedStockMessage = "Product stocked successfully";

            Assert.That(storeProductResult, Is.EqualTo(expectedStockMessage));
        }

        [Test]
        public void Store_ProductInformedWithoutName_ShouldNotBeAllowedToStock()
        {
            prod = new Product(null, 120, 20, true);

            var storeProductMessage = _storeOps.Stock(prod);
            var expectedStockMessage = "The name of the product should be informed.";

            Assert.That(storeProductMessage, Is.EqualTo(expectedStockMessage));
        }

        [Test]
        public void Store_ProductInformedWithoutPrice_ShouldNotBeAllowedToStock()
        {
            prod = new Product("Tshirt", 0, 20, true);

            var storeProductMessage = _storeOps.Stock(prod);
            var expectedStockMessage = "The price of the product should be informed";

            Assert.That(storeProductMessage, Is.EqualTo(expectedStockMessage));
        }        
    }
}
