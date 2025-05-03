using Moq;
using ProductAnalyzer.Gateways.ProductAggregate;

namespace ProductAnalyzer.Gateways.UnitTests.ProductAggregate
{
    public sealed partial class ProductGatewayTest
    {
        private class Fixture
        {
            private readonly Mock<IProductClientFactory> clientFactoryMock = new Mock<IProductClientFactory>(MockBehavior.Loose);
            private readonly Mock<IProductClient> clientMock = new Mock<IProductClient>(MockBehavior.Loose);

            public Fixture()
            {
                clientFactoryMock.Setup(m => m.Create()).Returns(clientMock.Object);
                clientMock.Setup(m => m.GetAllAsync()).ReturnsAsync([new()]);
            }

            public ProductGateway CreateTestObject()
            {
                return new ProductGateway(clientFactoryMock.Object);
            }

            internal void AssertResult(IEnumerable<Domain.ProductAggregate.Product> result)
            {
                Assert.That(result, Is.Not.Null, "Result should not be null");
                Assert.That(result.Count(), Is.EqualTo(1), "Result should contain exactly one element");
            }

            internal void AssertMockInvokedCorrectly()
            {
                clientFactoryMock.Verify(m => m.Create(), Times.Once, "ClientFactory should have been invoked exactly once");
                clientMock.Verify(m => m.GetAllAsync(), Times.Once, "Client should have been invoked exactly once");
            }
        }
    }
}