using ProductAnalyzer.Domain.ProductAggregate;

namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public class ProductGateway(IProductClientFactory productClientFactory) : IProductGateway
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            IProductClient client = productClientFactory.Create();
            IEnumerable<ProductContract> contracts = await client.GetAllAsync();

            return contracts.Select(ProductAssembler.ToProduct);
        }
    }
}
