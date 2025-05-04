namespace ProductAnalyzer.Domain.ProductAggregate.Filtering
{
    public static class ProductFilterFactory
    {
        public static IProductFilter MatchingPrice(decimal priceToMatch) => new MatchingPriceProductFilter(priceToMatch);

        public static IProductFilter MostExpensiveAndCheapest => new MostExpensiveAndCheapestProductFilter();

        public static IProductFilter MostBottles => new MostNumberOfPackagingUnitsProductFilter();
    }
}
