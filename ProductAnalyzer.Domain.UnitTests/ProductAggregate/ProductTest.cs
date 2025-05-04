using ProductAnalyzer.Domain.Testing.ProductAggregate;

namespace ProductAnalyzer.Domain.UnitTests.ProductAggregate
{
    public sealed class ProductTest
    {
        [Test]
        public void ReduceToArticlesWithMatchingPrice_WithMatchingArticle_ShouldReturnProductWithArticle()
        {
            var price = 1.0m;

            var testObject = ProductBuilder.New().WithNewArticleWithPrice(price).Build();

            Assert.That(testObject.ReduceToArticlesWithMatchingPrice(price).HasArticles, Is.True);
        }

        [Test]
        public void ReduceToArticlesWithMatchingPrice_WithoutMatchingArticle_ShouldReturnProductWithoutArticles()
        {
            var testObject = ProductBuilder.New().WithNewArticleWithPrice(10).Build();

            Assert.That(testObject.ReduceToArticlesWithMatchingPrice(100).HasArticles, Is.False);
        }

        [Test]
        public void HasArticles_WithoutArticles_ShouldReturnFalse()
        {
            var testObject = ProductBuilder.New().Build();

            Assert.That(testObject.HasArticles, Is.False);
        }

        [Test]
        public void HasArticles_WithArticles_ShouldReturnTrue()
        {
            var testObject = ProductBuilder.New().WithNewArticleWithPrice(10).Build();

            Assert.That(testObject.HasArticles, Is.True);
        }

        [Test]
        public void NumberOfMostPackagingUnits_WithArticles_ShouldReturnCorrectValue()
        {
            var testObject = ProductBuilder.New()
                .WithNewArticleWith(ArticleBuilder.New().WithNumberOfPackagingUnits(10))
                .WithNewArticleWith(ArticleBuilder.New().WithNumberOfPackagingUnits(20))
                .Build();

            Assert.That(testObject.NumberOfMostPackagingUnits, Is.EqualTo(20));
        }

        [Test]
        public void ReduceToArticlesWithMatchingNumberOfPackagingUnits_WithMatchingArticle_ShouldReturnProductWithArticle()
        {
            var numberOfPackagingUnits = 22;

            var testObject = ProductBuilder.New().WithNewArticleWith(ArticleBuilder.New().WithNumberOfPackagingUnits(numberOfPackagingUnits)).Build();

            Assert.That(testObject.ReduceToArticlesWithMatchingNumberOfPackagingUnits(numberOfPackagingUnits).HasArticles, Is.True);
        }

        [Test]
        public void ReduceToArticlesWithMatchingNumberOfPackagingUnits_WithoutMatchingArticle_ShouldReturnProductWithoutArticles()
        {
            var testObject = ProductBuilder.New().WithNewArticleWith(ArticleBuilder.New().WithNumberOfPackagingUnits(10)).Build();

            Assert.That(testObject.ReduceToArticlesWithMatchingNumberOfPackagingUnits(100).HasArticles, Is.False);
        }

        [Test]
        public void CheapestPricePerUnit_WithArticles_ShouldReturnCorrectPrice()
        {
            var testObject = ProductBuilder.New()
                .WithNewArticleWithPricePerUnit(2)
                .WithNewArticleWithPricePerUnit(1)
                .Build();

            Assert.That(testObject.CheapestPricePerUnit, Is.EqualTo(1));
        }

        [Test]
        public void HighestPricePerUnit_WithArticles_ShouldReturnCorrectPrice()
        {
            var testObject = ProductBuilder.New()
                .WithNewArticleWithPricePerUnit(1)
                .WithNewArticleWithPricePerUnit(2)
                .Build();

            Assert.That(testObject.HighestPricePerUnit, Is.EqualTo(2));
        }

        [Test]
        public void ReduceToArticlesWithMatchingPricePerUnit_WithHighestPricePerUnitMatchingArticle_ShouldReturnProductWithArticle()
        {
            var pricePerUnitMin = 22m;
            var pricePerUnitMax = 23m;

            var testObject = ProductBuilder.New()
                .WithNewArticleWith(ArticleBuilder.New().WithPricePerUnit(pricePerUnitMin))
                .WithNewArticleWith(ArticleBuilder.New().WithPricePerUnit(pricePerUnitMax))
                .Build();

            Assert.That(testObject.ReduceToArticlesWithMatchingPricePerUnit(0, pricePerUnitMax).Articles.Count, Is.EqualTo(1));
        }

        [Test]
        public void ReduceToArticlesWithMatchingPricePerUnit_WithCheapestPricePerUnitMatchingArticle_ShouldReturnProductWithArticle()
        {
            var pricePerUnitMin = 22m;
            var pricePerUnitMax = 23m;

            var testObject = ProductBuilder.New()
                .WithNewArticleWith(ArticleBuilder.New().WithPricePerUnit(pricePerUnitMin))
                .WithNewArticleWith(ArticleBuilder.New().WithPricePerUnit(99))
                .Build();

            Assert.That(testObject.ReduceToArticlesWithMatchingPricePerUnit(pricePerUnitMin, pricePerUnitMax).Articles.Count, Is.EqualTo(1));
        }

        [Test]
        public void ReduceToArticlesWithMatchingPricePerUnit_WithCheapestAndHighestPricePerUnitMatchingArticle_ShouldReturnProductWithArticle()
        {
            var pricePerUnitMin = 22m;
            var pricePerUnitMax = 23m;

            var testObject = ProductBuilder.New()
                .WithNewArticleWith(ArticleBuilder.New().WithPricePerUnit(pricePerUnitMin))
                .WithNewArticleWith(ArticleBuilder.New().WithPricePerUnit(pricePerUnitMax))
                .Build();

            Assert.That(testObject.ReduceToArticlesWithMatchingPricePerUnit(pricePerUnitMin, pricePerUnitMax).Articles.Count, Is.EqualTo(2));
        }

        [Test]
        public void ReduceToArticlesWithMatchingPricePerUnit_WithPricePerUnitNotMatchingArticle_ShouldReturnProductWithoutArticle()
        {
            var pricePerUnitMin = 22m;
            var pricePerUnitMax = 23m;

            var testObject = ProductBuilder.New()
                .WithNewArticleWith(ArticleBuilder.New().WithPricePerUnit(pricePerUnitMin))
                .WithNewArticleWith(ArticleBuilder.New().WithPricePerUnit(pricePerUnitMax))
                .Build();

            Assert.That(testObject.ReduceToArticlesWithMatchingPricePerUnit(0, 1).HasArticles, Is.False);
        }
    }
}
