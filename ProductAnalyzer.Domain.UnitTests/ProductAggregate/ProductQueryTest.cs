using ProductAnalyzer.Domain.Testing.ProductAggregate.Filtering;

namespace ProductAnalyzer.Domain.UnitTests.ProductAggregate
{
    public sealed partial class ProductQueryTest
    {

        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
        }

        [Test]
        public async Task QueryWith_AnyFilter_ShouldInvokeMocksCorrectly()
        {
            var testObject = fixture.CreateTestObject();

            await testObject.QueryWithAsync(new OnlyFirstProductFilter());

            fixture.AssertMocksInvokedCorrectly();
        }

        [Test]
        public async Task QueryWith_WithFilter_ShouldReturnAccordingly()
        {
            var testObject = fixture.CreateTestObject();

            var result = await testObject.QueryWithAsync(new OnlyFirstProductFilter());

            Assert.That(result.Count(), Is.EqualTo(1), "Expected exactly one product in the result.");
        }
    }
}