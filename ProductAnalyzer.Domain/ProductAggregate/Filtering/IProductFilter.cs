namespace ProductAnalyzer.Domain.ProductAggregate.Filtering
{
    public interface IProductFilter
    {
        IEnumerable<Product> Filter(IEnumerable<Product> products);
    }
}
