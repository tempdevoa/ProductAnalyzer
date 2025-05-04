namespace ProductAnalyzer.WebApi.UnitTests.Controllers
{
    public sealed partial class ProductControllerTest
    {               
        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
        }

        [Test]
        public async Task GetMostExpensiveAndCheapestByLitre_ShouldAssembleCorrectly()
        {
            var testObject = fixture.CreateTestObject();
            
            var result = await testObject.GetMostExpensiveAndCheapestAsync();

            fixture.AssertResult(result);
        }

        [Test]
        public async Task GetMostExpensiveAndCheapestByLitre_ShouldInvokeCorrectProductFilter()
        {
            var testObject = fixture.CreateTestObject();

            var result = await testObject.GetMostExpensiveAndCheapestAsync();

            fixture.AssertMostExpensiveAndCheapestFilterInvoked();
        }

        [Test]
        public async Task MatchingPriceAsync_ShouldAssembleCorrectly()
        {
            var testObject = fixture.CreateTestObject();
            
            var result = await testObject.MatchingPriceAsync(fixture.MatchingPrice);

            fixture.AssertResult(result);
        }

        [Test]
        public async Task MatchingPriceAsync_ShouldInvokeCorrectProductFilter()
        {
            var testObject = fixture.CreateTestObject();

            var result = await testObject.MatchingPriceAsync(fixture.MatchingPrice);

            fixture.AssertMatchingPriceProductFilterInvoked();
        }

        [Test]
        public async Task MostNumberOfPackagingUnitsAsync_ShouldAssembleCorrectly()
        {
            var testObject = fixture.CreateTestObject();

            var result = await testObject.MostNumberOfPackagingUnitsAsync();

            fixture.AssertResult(result);
        }

        [Test]
        public async Task MostNumberOfPackagingUnitsAsync_ShouldInvokeCorrectProductFilter()
        {
            var testObject = fixture.CreateTestObject();

            var result = await testObject.MostNumberOfPackagingUnitsAsync();

            fixture.AssertMostBottlesProductFilterInvoked();
        }
    }
}