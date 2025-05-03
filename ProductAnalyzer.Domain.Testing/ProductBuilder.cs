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

        public ProductBuilder WithArticleWithPricePerUnit(decimal pricePerUnit)
        {
            articles.Add(new Article(pricePerUnit, pricePerUnit));
            return this;
        }

        public ProductBuilder WithName(string nameParam)
        {
            name = nameParam;
            return this;
        }

        public ProductBuilder WithArticleWithPrice(decimal priceParam)
        {
            articles.Add(new Article(priceParam, priceParam));
            return this;
        }
    }
}
