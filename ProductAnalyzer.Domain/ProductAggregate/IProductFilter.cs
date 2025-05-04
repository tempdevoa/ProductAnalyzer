namespace ProductAnalyzer.Domain.ProductAggregate
{
    public interface IProductFilter
    {
        IEnumerable<Product> Filter(IEnumerable<Product> products);
    }
}
