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
        public async Task GetMostExpensiveAndCheapestByLitre_ShouldReturnMostExpensiveAndCheapest()
        {
            fixture.SetupForMostExpensiveAndCheapest();

            var testObject = fixture.CreateTestObject();
            var result = await testObject.GetAsync();

            fixture.AssertResultForMostExpensiveAndCheapest(result);
        }
    }
}