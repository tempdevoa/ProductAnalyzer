using Moq;
using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.Domain.Testing;
using ProductAnalyzer.Gateways.ProductAggregate;

namespace ProductAnalyzer.Domain.UnitTests.ProductAggregate
{
    public sealed partial class ProductQueryTest
    {
        private class Fixture
        {
            private readonly Mock<IProductGateway> productGatewayMock = new (MockBehavior.Loose);
            private readonly Product cheapestPerLitre = ProductBuilder.New().WithName("Cheap").Build();
            private readonly Product mostExpensivePerLitre = ProductBuilder.New().WithName("Expensive").Build();

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

            public class OnlyFirstProductFilter : IProductFilter
            {
                public IEnumerable<Product> Filter(IEnumerable<Product> products)
                {
                    return products.Take(1);
                }
            }
        }
    }
}