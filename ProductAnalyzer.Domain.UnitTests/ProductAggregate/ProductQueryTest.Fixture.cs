using Moq;
using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.Gateways.ProductAggregate;

namespace ProductAnalyzer.Domain.UnitTests.ProductAggregate
{
    public sealed partial class ProductQueryTest
    {
        private class Fixture
        {
            private readonly Mock<IProductGateway> productGatewayMock = new (MockBehavior.Loose);
            private readonly Product cheapestPerLitre = new ("Cheap", new List<Article>());
            private readonly Product mostExpensivePerLitre = new ("Expensive", new List<Article>());

            public Fixture()
            {
                productGatewayMock.Setup(m => m.GetAllAsync()).ReturnsAsync([mostExpensivePerLitre, cheapestPerLitre]);
            }

            public ProductQuery CreateTestObject()
            {
                return new ProductQuery(productGatewayMock.Object);
            }

            internal void AssertMocksInvokedCorrectly()
            {
                productGatewayMock.Verify(m => m.GetAllAsync(), Times.Once, "GetAllAsync was not called exactly once.");
            }
        }
    }
}