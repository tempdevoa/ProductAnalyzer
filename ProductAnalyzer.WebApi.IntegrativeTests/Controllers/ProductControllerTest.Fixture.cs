using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.Domain.Testing;
using ProductAnalyzer.WebApi.Contracts;
using ProductAnalyzer.WebApi.Controllers;

namespace ProductAnalyzer.WebApi.UnitTests.Controllers
{
    public sealed partial class ProductControllerTest 
    {
		private sealed class Fixture
		{
            private readonly Product cheapestBottleByLitre = ProductBuilder.New().WithName("Min").WithNewArticleWithPrice(1).Build();
			private readonly Product mostExpensiveBottleByLitre = ProductBuilder.New().WithName("Max").WithNewArticleWithPrice(2).Build();
            private readonly Mock<IProductQuery> bottleQueryMock = new();

			public ProductController CreateTestObject()
			{
				return new ProductController(bottleQueryMock.Object);
			}

			internal void SetupForMostExpensiveAndCheapest()
			{
				bottleQueryMock.Setup(m => m.QueryWithAsync(It.IsAny<IProductFilter>())).ReturnsAsync([cheapestBottleByLitre, mostExpensiveBottleByLitre]);
			}

			internal void AssertResultForMostExpensiveAndCheapest(IActionResult result)
			{
				var okResult = result as OkObjectResult;
				var productContracts = okResult?.Value as IEnumerable<ProductContract>;

				Assert.That(productContracts, Is.Not.Null, "Expected a non-null result from the controller.");
                Assert.Multiple(() =>
                {
                    Assert.That(productContracts.Count(), Is.EqualTo(2), "Expected exactly 2 bottles in the result.");
                    Assert.That(productContracts.First().Name, Is.EqualTo(cheapestBottleByLitre.Name), "Expected the brand of the cheapest.");
					Assert.That(productContracts.First().Articles, Is.Not.Null.Or.Empty, "The should be articles in the product");
					Assert.That(productContracts.First().Articles[0].PricePerUnit, Is.EqualTo(cheapestBottleByLitre.Articles.First().PricePerUnit), "Expected the price of the cheapest.");
                    Assert.That(productContracts.Last().Name, Is.EqualTo(mostExpensiveBottleByLitre.Name), "Expected the brand of the most expensive.");
                    Assert.That(productContracts.Last().Articles, Is.Not.Null.Or.Empty, "The should be articles in the product");
                    Assert.That(productContracts.Last().Articles[0].PricePerUnit, Is.EqualTo(mostExpensiveBottleByLitre.Articles.First().PricePerUnit), "Expected the price of the most expensive.");
                });
            }
		}
	}
}
