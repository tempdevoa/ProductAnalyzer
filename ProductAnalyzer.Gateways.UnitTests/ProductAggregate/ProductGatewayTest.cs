namespace ProductAnalyzer.Gateways.UnitTests.ProductAggregate
{
    public sealed partial class ProductGatewayTest
    {

        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
        }

        [Test]
        public async Task GetAllAsync_ShouldInvokeMocksCorrectly ()
        {
            var testObject = fixture.CreateTestObject();

            await testObject.GetAllAsync();

            fixture.AssertMockInvokedCorrectly();
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllFromClient()
        {
            var testObject = fixture.CreateTestObject();

            var result = await testObject.GetAllAsync();

            fixture.AssertResult(result);
        }
    }
}