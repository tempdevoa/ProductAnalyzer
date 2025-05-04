namespace ProductAnalyzer.Domain.ProductAggregate
{
    public static class ProductFilterFactory
    {
        public static IProductFilter NonFiltering => new NonFilteringProductFilter();

        public static IProductFilter MatchingPrice(decimal priceToMatch) => new MatchingPriceProductFilter(priceToMatch);

        public static IProductFilter MostExpensiveAndCheapest => new MostExpensiveAndCheapestProductFilter();

        public static IProductFilter MostBottles => new MostNumberOfPackagingUnitsProductFilter();
    }
}
