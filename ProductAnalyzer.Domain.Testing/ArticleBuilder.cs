using ProductAnalyzer.Domain.ProductAggregate;

namespace ProductAnalyzer.Domain.Testing
{
    public sealed class ArticleBuilder
    {
        public static ArticleBuilder New()
        {
            return new ArticleBuilder();
        }

        private decimal pricePerUnit = 2;
        private decimal price = 3;
        private int numberOfPackagingUnits = 5;

        public Article Build()
        {
            return new Article(price, pricePerUnit, numberOfPackagingUnits);
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

        public ArticleBuilder WithNumberOfPackagingUnits(int numberOfPackagingUnitsParam)
        {
            numberOfPackagingUnits = numberOfPackagingUnitsParam;
            return this;
        }
    }
}
