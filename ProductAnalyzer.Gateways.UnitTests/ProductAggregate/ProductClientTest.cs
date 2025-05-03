namespace ProductAnalyzer.Gateways.UnitTests.ProductAggregate
{
    public sealed partial class ProductClientTest
    {

        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllCorrectlyDeserialized()
        {
            var testObject = fixture.CreateTestObject();

            var result = await testObject.GetAllAsync();
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(28));

            var matchedProduct = result.FirstOrDefault(p => p.Name!.Equals("Hofbräuhaus Hell"));
            Assert.That(matchedProduct, Is.Not.Null, "No product with name 'Hofbräuhaus Hell' found.");
            Assert.That(matchedProduct.Articles, Is.Not.Null, "No article assembled.");
            Assert.That(matchedProduct.Articles, Is.Not.Empty, "No article assembled.");
            Assert.That(matchedProduct.Articles[0].PricePerUnit, Is.EqualTo("(1,70 €/Liter)"), "The price per unit should be correctly assembled.");
            Assert.That(matchedProduct.Articles[0].Price, Is.EqualTo(16.99), "The price should be correctly assembled.");
        }
    }
}
