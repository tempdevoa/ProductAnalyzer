using ProductAnalyzer.Gateways.ProductAggregate;

namespace ProductAnalyzer.Gateways.UnitTests.ProductAggregate
{
    public sealed class ProductAssemblerTest
    {
        [TestCase("(1,80 €/Liter)", 1.8, 1.0)]
        [TestCase("(0,0 €/Liter)", 0.0, 1.1)]
        [TestCase("(0,1 €/Liter)", 0.1, 0.0)]
        [TestCase("(999,999 €/Liter)", 999.999, 88.88)]
        public void ToProduct_ValidContract_ReturnsProduct(string pricePerUnitAsText, decimal pricePerUnit, decimal price)
        {
            var contract = new ProductContract { Name = "Test Product", Articles = [new ArticleContract { Price = price, PricePerUnit = pricePerUnitAsText }] };
            
            var result = ProductAssembler.ToProduct(contract);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Test Product"));
            Assert.That(result.Articles, Is.Not.Null);
            Assert.That(result.Articles.Count, Is.EqualTo(1));
            Assert.That(result.Articles.First().PricePerLitre, Is.EqualTo(pricePerUnit));
            Assert.That(result.Articles.First().Price, Is.EqualTo(price));
        }
    }
}
