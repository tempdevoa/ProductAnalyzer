namespace ProductAnalyzer.Domain.ProductAggregate
{
    public class NonFilteringProductFilter : IProductFilter
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products)
        {
            return products ?? new List<Product>();
        }
    }
}
