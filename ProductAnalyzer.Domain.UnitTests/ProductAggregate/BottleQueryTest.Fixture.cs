using Moq;
using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.Gateways.ProductAggregate;

namespace ProductAnalyzer.Domain.UnitTests.ProductAggregate
{
    public sealed partial class BottleQueryTest
    {
        private class Fixture
        {
            private readonly Mock<IProductGateway> productGatewayMock = new (MockBehavior.Loose);
            private readonly Product cheapestPerLitre = new ("Cheap", 1.0m);
            private readonly Product mostExpensivePerLitre = new ("Expensive", 99.0m);

            public Fixture()
            {
                productGatewayMock.Setup(m => m.GetAllAsync()).ReturnsAsync([mostExpensivePerLitre, cheapestPerLitre]);
            }

            public BottleQuery CreateTestObject()
            {
                return new BottleQuery(productGatewayMock.Object);
            }

            internal void AssertMocksInvokedCorrectly()
            {
                productGatewayMock.Verify(m => m.GetAllAsync(), Times.Once, "GetAllAsync was not called exactly once.");
            }
        }
    }
}