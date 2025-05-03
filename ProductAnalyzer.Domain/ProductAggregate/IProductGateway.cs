using ProductAnalyzer.Domain.ProductAggregate;

namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public interface IProductGateway
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
