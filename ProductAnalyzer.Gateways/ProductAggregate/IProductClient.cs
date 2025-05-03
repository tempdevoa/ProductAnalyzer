namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public interface IProductClient
    {
        Task<IEnumerable<ProductContract>> GetAllAsync();
    }
}
