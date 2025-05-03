using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.WebApi.Controllers;

namespace ProductAnalyzer.WebApi.UnitTests.Controllers
{
    public sealed partial class BottleControllerTest 
    {
		private sealed class Fixture
		{
            private readonly Bottle cheapestBottleByLitre = new("Min", 1);
            private readonly Bottle mostExpensiveBottleByLitre = new("Min", 2);
            private readonly Mock<IBottleQuery> bottleQueryMock = new Mock<IBottleQuery>();

			public BottleController CreateTestObject()
			{
				return new BottleController(bottleQueryMock.Object);
			}

			internal void SetupForMostExpensiveAndCheapest()
			{
				bottleQueryMock.Setup(m => m.QueryWithAsync(It.IsAny<ProductFilter>())).ReturnsAsync([cheapestBottleByLitre, mostExpensiveBottleByLitre]);
			}

			internal void AssertResultForMostExpensiveAndCheapest(IActionResult result)
			{
				var okResult = result as OkObjectResult;
				var bottleResult = okResult?.Value as IEnumerable<BottleContract>;

				Assert.That(bottleResult, Is.Not.Null, "Expected a non-null result from the controller.");
				Assert.That(bottleResult.Count(), Is.EqualTo(2), "Expected exactly 2 bottles in the result.");

				Assert.That(bottleResult.First().Brand, Is.EqualTo(cheapestBottleByLitre.Name), "Expected the brand of the cheapest.");
                Assert.That(bottleResult.First().Price, Is.EqualTo(cheapestBottleByLitre.PricePerLitre), "Expected the price of the cheapest.");
                Assert.That(bottleResult.Last().Brand, Is.EqualTo(mostExpensiveBottleByLitre.Name), "Expected the brand of the most expensive.");
                Assert.That(bottleResult.Last().Price, Is.EqualTo(mostExpensiveBottleByLitre.PricePerLitre), "Expected the price of the most expensive.");
            }
		}
	}
}
