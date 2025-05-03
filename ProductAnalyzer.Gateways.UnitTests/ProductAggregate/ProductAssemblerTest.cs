using ProductAnalyzer.Gateways.ProductAggregate;

namespace ProductAnalyzer.Gateways.UnitTests.ProductAggregate
{
    public sealed class ProductAssemblerTest
    {
        [TestCase("(1,80 €/Liter)", 1.8)]
        [TestCase("(0,0 €/Liter)", 0.0)]
        [TestCase("(0,1 €/Liter)", 0.1)]
        [TestCase("(999,999 €/Liter)", 999.999)]
        public void ToProduct_ValidContract_ReturnsProduct(string pricePerUnitAsText, decimal pricePerUnit)
        {
            var contract = new ProductContract
            {
                Name = "Test Product",
                PricePerUnit = pricePerUnitAsText
            };
            
            var result = ProductAssembler.ToProduct(contract);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Test Product"));
            Assert.That(result.PricePerLitre, Is.EqualTo(pricePerUnit));
        }
    }
}
