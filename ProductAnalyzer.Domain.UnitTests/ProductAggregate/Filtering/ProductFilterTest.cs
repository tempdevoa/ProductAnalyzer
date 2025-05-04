using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.Domain.ProductAggregate.Filtering;
using ProductAnalyzer.Domain.Testing.ProductAggregate;

namespace ProductAnalyzer.Domain.UnitTests.ProductAggregate.Filtering
{
    public sealed class ProductFilterTest
    {
        [Test]
        public void MostExpensiveAndCheapest_ShouldFilterCorrectly()
        {
            var multipleWithCheapest = ProductBuilder.New().WithName("Multiple with cheapest").WithNewArticleWithPricePerUnit(9).WithNewArticleWithPricePerUnit(14).Build();
            var singleCheapest = ProductBuilder.New().WithName("Single cheapest").WithNewArticleWithPricePerUnit(9).Build();
            var singleMostExpensive = ProductBuilder.New().WithName("Single most expensive").WithNewArticleWithPricePerUnit(15).Build();
            var cheapestAndMostExpensive = ProductBuilder.New().WithName("cheapest and most expensive").WithNewArticleWithPricePerUnit(15).WithNewArticleWithPricePerUnit(9).Build();

            var products = new List<Product>
            {
                multipleWithCheapest,
                singleCheapest,
                ProductBuilder.New().WithNewArticleWithPricePerUnit(10).Build(),
                ProductBuilder.New().WithNewArticleWithPricePerUnit(11).Build(),
                ProductBuilder.New().WithNewArticleWithPricePerUnit(12).Build(),
                ProductBuilder.New().WithNewArticleWithPricePerUnit(13).Build(),
                cheapestAndMostExpensive,
                ProductBuilder.New().WithNewArticleWithPricePerUnit(11).WithNewArticleWithPricePerUnit(14).Build(),
                singleMostExpensive
            };

            var testObject = ProductFilterFactory.MostExpensiveAndCheapest;
            List<Product>? result = testObject.Filter(products).ToList();

            Assert.That(result, Is.Not.Null.Or.Empty);
            Assert.That(result.Count, Is.EqualTo(4));

            var resultMultipleWithCheapest = result.SingleOrDefault(x => x.Name.Equals(multipleWithCheapest.Name));
            var resultSingleCheapest = result.SingleOrDefault(x => x.Name.Equals(singleCheapest.Name));
            var resultSingleMostExpensive = result.SingleOrDefault(x => x.Name.Equals(singleMostExpensive.Name));
            var resultCheapestAndMostExpensive = result.SingleOrDefault(x => x.Name.Equals(cheapestAndMostExpensive.Name));

            Assert.That(resultMultipleWithCheapest, Is.Not.Null);
            Assert.That(resultMultipleWithCheapest.Articles.Count, Is.EqualTo(1));
            Assert.That(resultMultipleWithCheapest.Articles.First().PricePerUnit, Is.EqualTo(9));

            Assert.That(resultSingleCheapest, Is.Not.Null);
            Assert.That(resultSingleCheapest.Articles.Count, Is.EqualTo(1));
            Assert.That(resultSingleCheapest.Articles.First().PricePerUnit, Is.EqualTo(9));

            Assert.That(resultSingleMostExpensive, Is.Not.Null);
            Assert.That(resultSingleMostExpensive.Articles.Count, Is.EqualTo(1));
            Assert.That(resultSingleMostExpensive.Articles.First().PricePerUnit, Is.EqualTo(15));

            Assert.That(resultCheapestAndMostExpensive, Is.Not.Null);
            Assert.That(resultCheapestAndMostExpensive.Articles.Count, Is.EqualTo(2));
            Assert.That(resultCheapestAndMostExpensive.Articles.First().PricePerUnit, Is.EqualTo(15));
            Assert.That(resultCheapestAndMostExpensive.Articles.Last().PricePerUnit, Is.EqualTo(9));
        }

        [Test]
        public void MatchesPrice_ShouldFilterCorrectly()
        {
            var matchingPrice = ProductBuilder.New().WithName("matchingPrice").WithNewArticleWithPrice(9).Build();
            var notMatchingPrice = ProductBuilder.New().WithName("notMatchingPrice").WithNewArticleWithPrice(15).Build();
            var multipleMatchingPrice = ProductBuilder.New().WithName("multipleMatchingPrice")
                .WithNewArticleWith(ArticleBuilder.New().WithPrice(9).WithPricePerUnit(1))
                .WithNewArticleWith(ArticleBuilder.New().WithPrice(9).WithPricePerUnit(2)).Build();

            var products = new List<Product>
            {
                matchingPrice,
                multipleMatchingPrice,
                notMatchingPrice
            };

            var testObject = ProductFilterFactory.MatchingPrice(9);
            List<Product>? result = testObject.Filter(products)?.ToList();

            Assert.That(result, Is.Not.Null.Or.Empty);
            Assert.That(result.Count, Is.EqualTo(2));

            var resultMultipleMatchingPrice = result.SingleOrDefault(x => x.Name.Equals(multipleMatchingPrice.Name));
            var resultMatchingPrice = result.SingleOrDefault(x => x.Name.Equals(matchingPrice.Name));
                                 
            Assert.That(resultMatchingPrice, Is.Not.Null);
            Assert.That(resultMatchingPrice.Articles.Count, Is.EqualTo(1));
            Assert.That(resultMatchingPrice.Articles.First().Price, Is.EqualTo(9));
                        
            Assert.That(resultMultipleMatchingPrice, Is.Not.Null);
            Assert.That(resultMultipleMatchingPrice.Articles.Count, Is.EqualTo(2));
            Assert.That(resultMultipleMatchingPrice.Articles.First().Price, Is.EqualTo(9));
            Assert.That(resultMultipleMatchingPrice.Articles.First().PricePerUnit, Is.EqualTo(1));
            Assert.That(resultMultipleMatchingPrice.Articles.Last().Price, Is.EqualTo(9));
            Assert.That(resultMultipleMatchingPrice.Articles.Last().PricePerUnit, Is.EqualTo(2));
        }

        [Test]
        public void MostBottles_ShouldFilterCorrectly()
        {
            var multipleWithMostBottles = ProductBuilder.New().WithName("multipleWithMostBottles")
                .WithNewArticleWith(ArticleBuilder.New().WithNumberOfPackagingUnits(9))
                .WithNewArticleWith(ArticleBuilder.New().WithNumberOfPackagingUnits(9))
                .WithNewArticleWith(ArticleBuilder.New().WithNumberOfPackagingUnits(8))
                .Build();

            var singleWithMostBottles = ProductBuilder.New().WithName("singleWithMostBottles")
                .WithNewArticleWith(ArticleBuilder.New().WithNumberOfPackagingUnits(9))
                .Build();

            var products = new List<Product>
            {
                multipleWithMostBottles,
                singleWithMostBottles,
                ProductBuilder.New().WithNewArticleWithPricePerUnit(10).Build(),
                ProductBuilder.New().WithNewArticleWithPricePerUnit(11).Build()
            };

            var testObject = ProductFilterFactory.MostBottles;
            List<Product> result = testObject.Filter(products).ToList();

            Assert.That(result, Is.Not.Null.Or.Empty);
            Assert.That(result.Count, Is.EqualTo(2));

            var resultSingleWithMostBottles = result.SingleOrDefault(x => x.Name.Equals(singleWithMostBottles.Name));
            var resultMultipleWithMostBottles = result.SingleOrDefault(x => x.Name.Equals(multipleWithMostBottles.Name));
                        
            Assert.That(resultSingleWithMostBottles, Is.Not.Null);
            Assert.That(resultSingleWithMostBottles.Articles.Count, Is.EqualTo(1));
            Assert.That(resultSingleWithMostBottles.Articles.First().NumberOfPackagingUnits, Is.EqualTo(9));          

            Assert.That(resultMultipleWithMostBottles, Is.Not.Null);
            Assert.That(resultMultipleWithMostBottles.Articles.Count, Is.EqualTo(2));
            Assert.That(resultMultipleWithMostBottles.Articles.First().NumberOfPackagingUnits, Is.EqualTo(9));
            Assert.That(resultMultipleWithMostBottles.Articles.Last().NumberOfPackagingUnits, Is.EqualTo(9));
        }
    }
}
