using ProductAnalyzer.Domain.ProductAggregate;

namespace ProductAnalyzer.Domain.Testing
{
    public sealed class ProductBuilder
    {
        public static ProductBuilder New()
        {
            return new ProductBuilder();
        }

        private string name = "Standardprodukt";
        private List<Article> articles = new List<Article>();

        public Product Build()
        {
            return new Product(name, articles);
        }

        public ProductBuilder WithNewArticleWithPricePerUnit(decimal pricePerUnit)
        {
            articles.Add(ArticleBuilder.New().WithPricePerUnit(pricePerUnit).Build());
            return this;
        }

        public ProductBuilder WithNewArticleWith(ArticleBuilder articleBuilder)
        {
            articles.Add(articleBuilder.Build());
            return this;
        }

        public ProductBuilder WithName(string nameParam)
        {
            name = nameParam;
            return this;
        }

        public ProductBuilder WithNewArticleWithPrice(decimal priceParam)
        {
            articles.Add(ArticleBuilder.New().WithPrice(priceParam).Build());
            return this;
        }
    }
}
