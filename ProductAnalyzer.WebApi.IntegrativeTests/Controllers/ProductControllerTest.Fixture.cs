using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.Domain.ProductAggregate.Filtering;
using ProductAnalyzer.Domain.Testing.ProductAggregate;
using ProductAnalyzer.WebApi.Contracts;
using ProductAnalyzer.WebApi.Controllers;

namespace ProductAnalyzer.WebApi.UnitTests.Controllers
{
    public sealed partial class ProductControllerTest 
    {
		private sealed class Fixture
		{
            private readonly Product product = ProductBuilder.New().WithName("Min").WithNewArticleWithPricePerUnit(1).Build();
            private readonly Mock<IProductQuery> bottleQueryMock = new();

			public decimal MatchingPrice => product.Articles.First().Price;

            public Fixture()
            {
                bottleQueryMock.Setup(m => m.QueryWithAsync(It.IsAny<IProductFilter>())).ReturnsAsync([product]);
            }

            public ProductController CreateTestObject()
			{
				return new ProductController(bottleQueryMock.Object);
			}

			internal void AssertResult(IActionResult result)
			{
				var okResult = result as OkObjectResult;
				var productContracts = okResult?.Value as IEnumerable<ProductContract>;

				Assert.That(productContracts, Is.Not.Null, "Expected a non-null result from the controller.");
                Assert.Multiple(() =>
                {
                    Assert.That(productContracts.Count(), Is.EqualTo(1), "Expected exactly 1 products in the result.");
                    Assert.That(productContracts.First().Name, Is.EqualTo(product.Name), "Expected the name.");
					Assert.That(productContracts.First().Articles, Is.Not.Null.Or.Empty, "There should be articles in the product");
					Assert.That(productContracts.First().Articles[0].PricePerUnit, Is.EqualTo(product.Articles.First().PricePerUnit), "Expected the price per unit.");
                    Assert.That(productContracts.First().Articles[0].Price, Is.EqualTo(product.Articles.First().Price), "Expected the price.");
                    Assert.That(productContracts.First().Articles[0].NumberOfPackagingUnits, Is.EqualTo(product.Articles.First().NumberOfPackagingUnits), "Expected the number of packaging units.");
                });
            }

            internal void AssertMostExpensiveAndCheapestFilterInvoked()
            {
                bottleQueryMock.Verify(m => m.QueryWithAsync(It.Is<IProductFilter>(f => f is MostExpensiveAndCheapestProductFilter)), Times.Once, "Expected the most expensive and cheapest filter to be invoked.");
            }

            internal void AssertMostBottlesProductFilterInvoked()
            {
                bottleQueryMock.Verify(m => m.QueryWithAsync(It.Is<IProductFilter>(f => f is MostNumberOfPackagingUnitsProductFilter)), Times.Once, "Expected the most expensive and cheapest filter to be invoked.");
            }

            internal void AssertMatchingPriceProductFilterInvoked()
            {
                bottleQueryMock.Verify(m => m.QueryWithAsync(It.Is<IProductFilter>(f => f is MatchingPriceProductFilter)), Times.Once, "Expected the most expensive and cheapest filter to be invoked.");
            }
        }
	}
}
