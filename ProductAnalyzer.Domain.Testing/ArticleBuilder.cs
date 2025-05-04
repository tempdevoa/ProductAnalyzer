using ProductAnalyzer.Domain.ProductAggregate;

namespace ProductAnalyzer.Domain.Testing
{
    public sealed class ArticleBuilder
    {
        public static ArticleBuilder New()
        {
            return new ArticleBuilder();
        }

        private decimal pricePerUnit = 1;
        private decimal price = 2;
        
        public Article Build()
        {
            return new Article(price, pricePerUnit);
        }

        public ArticleBuilder WithPricePerUnit(decimal pricePerUnitParam)
        {
            pricePerUnit = pricePerUnitParam;
            return this;
        }
                
        public ArticleBuilder WithPrice(decimal priceParam)
        {
            price = priceParam;
            return this;
        }
    }
}
