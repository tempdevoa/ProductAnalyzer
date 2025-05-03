using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.Domain.Testing;

namespace ProductAnalyzer.Domain.UnitTests.ProductAggregate
{
    public sealed class ProductFilterTest
    {
        [Test]
        public void MostExpensiveAndCheapest_ShouldFilterCorrectly()
        {
            var multipleWithCheapest = ProductBuilder.New().WithName("Multiple with cheapest").WithArticleWithPricePerUnit(9).WithArticleWithPricePerUnit(14).Build();
            var singleCheapest = ProductBuilder.New().WithName("Single cheapest").WithArticleWithPricePerUnit(9).Build();
            var singleMostExpensive = ProductBuilder.New().WithName("Single most expensive").WithArticleWithPricePerUnit(15).Build();
            var cheapestAndMostExpensive = ProductBuilder.New().WithName("cheapest and most expensive").WithArticleWithPricePerUnit(15).WithArticleWithPricePerUnit(9).Build();

            var products = new List<Product>
            {
                multipleWithCheapest,
                singleCheapest,
                ProductBuilder.New().WithArticleWithPricePerUnit(10).Build(),
                ProductBuilder.New().WithArticleWithPricePerUnit(11).Build(),
                ProductBuilder.New().WithArticleWithPricePerUnit(12).Build(),
                ProductBuilder.New().WithArticleWithPricePerUnit(13).Build(),
                cheapestAndMostExpensive,
                ProductBuilder.New().WithArticleWithPricePerUnit(11).WithArticleWithPricePerUnit(14).Build(),
                singleMostExpensive
            };

            var testObject = ProductFilterFactory.MostExpensiveAndCheapest;
            List<Product>? result = testObject(products)?.ToList();

            Assert.That(result, Is.Not.Null.Or.Empty);
            Assert.That(result.Count, Is.EqualTo(4));

            var resultMultipleWithCheapest = result.SingleOrDefault(x => x.Name.Equals(multipleWithCheapest.Name));
            var resultSingleCheapest = result.SingleOrDefault(x => x.Name.Equals(singleCheapest.Name));
            var resultSingleMostExpensive = result.SingleOrDefault(x => x.Name.Equals(singleMostExpensive.Name));
            var resultCheapestAndMostExpensive = result.SingleOrDefault(x => x.Name.Equals(cheapestAndMostExpensive.Name));

            Assert.That(resultMultipleWithCheapest, Is.Not.Null);
            Assert.That(resultMultipleWithCheapest.Articles.Count, Is.EqualTo(1));
            Assert.That(resultMultipleWithCheapest.Articles.First().PricePerLitre, Is.EqualTo(9));

            Assert.That(resultSingleCheapest, Is.Not.Null);
            Assert.That(resultSingleCheapest.Articles.Count, Is.EqualTo(1));
            Assert.That(resultSingleCheapest.Articles.First().PricePerLitre, Is.EqualTo(9));

            Assert.That(resultSingleMostExpensive, Is.Not.Null);
            Assert.That(resultSingleMostExpensive.Articles.Count, Is.EqualTo(1));
            Assert.That(resultSingleMostExpensive.Articles.First().PricePerLitre, Is.EqualTo(15));

            Assert.That(resultCheapestAndMostExpensive, Is.Not.Null);
            Assert.That(resultCheapestAndMostExpensive.Articles.Count, Is.EqualTo(2));
            Assert.That(resultCheapestAndMostExpensive.Articles.First().PricePerLitre, Is.EqualTo(15));
            Assert.That(resultCheapestAndMostExpensive.Articles.Last().PricePerLitre, Is.EqualTo(9));
        }

        [Test]
        public void MatchesPrice_ShouldFilterCorrectly()
        {
            var multipleWithCheapest = ProductBuilder.New().WithName("Multiple with cheapest").WithArticleWithPrice(9).Build();
            var singleCheapest = ProductBuilder.New().WithName("Single cheapest").WithArticleWithPricePerUnit(9).Build();
            var singleMostExpensive = ProductBuilder.New().WithName("Single most expensive").WithArticleWithPricePerUnit(15).Build();
            var cheapestAndMostExpensive = ProductBuilder.New().WithName("cheapest and most expensive").WithArticleWithPricePerUnit(15).WithArticleWithPricePerUnit(9).Build();

            var products = new List<Product>
            {
                multipleWithCheapest,
                singleCheapest,
                ProductBuilder.New().WithArticleWithPricePerUnit(10).Build(),
                ProductBuilder.New().WithArticleWithPricePerUnit(11).Build(),
                ProductBuilder.New().WithArticleWithPricePerUnit(12).Build(),
                ProductBuilder.New().WithArticleWithPricePerUnit(13).Build(),
                cheapestAndMostExpensive,
                ProductBuilder.New().WithArticleWithPricePerUnit(11).WithArticleWithPricePerUnit(14).Build(),
                singleMostExpensive
            };

            var testObject = ProductFilterFactory.MostExpensiveAndCheapest;
            List<Product>? result = testObject(products)?.ToList();

            Assert.That(result, Is.Not.Null.Or.Empty);
            Assert.That(result.Count, Is.EqualTo(4));

            var resultMultipleWithCheapest = result.SingleOrDefault(x => x.Name.Equals(multipleWithCheapest.Name));
            var resultSingleCheapest = result.SingleOrDefault(x => x.Name.Equals(singleCheapest.Name));
            var resultSingleMostExpensive = result.SingleOrDefault(x => x.Name.Equals(singleMostExpensive.Name));
            var resultCheapestAndMostExpensive = result.SingleOrDefault(x => x.Name.Equals(cheapestAndMostExpensive.Name));

            Assert.That(resultMultipleWithCheapest, Is.Not.Null);
            Assert.That(resultMultipleWithCheapest.Articles.Count, Is.EqualTo(1));
            Assert.That(resultMultipleWithCheapest.Articles.First().PricePerLitre, Is.EqualTo(9));

            Assert.That(resultSingleCheapest, Is.Not.Null);
            Assert.That(resultSingleCheapest.Articles.Count, Is.EqualTo(1));
            Assert.That(resultSingleCheapest.Articles.First().PricePerLitre, Is.EqualTo(9));

            Assert.That(resultSingleMostExpensive, Is.Not.Null);
            Assert.That(resultSingleMostExpensive.Articles.Count, Is.EqualTo(1));
            Assert.That(resultSingleMostExpensive.Articles.First().PricePerLitre, Is.EqualTo(15));

            Assert.That(resultCheapestAndMostExpensive, Is.Not.Null);
            Assert.That(resultCheapestAndMostExpensive.Articles.Count, Is.EqualTo(2));
            Assert.That(resultCheapestAndMostExpensive.Articles.First().PricePerLitre, Is.EqualTo(15));
            Assert.That(resultCheapestAndMostExpensive.Articles.Last().PricePerLitre, Is.EqualTo(9));
        }
    }
}
