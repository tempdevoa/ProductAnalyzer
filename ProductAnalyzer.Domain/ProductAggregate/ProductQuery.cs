using ProductAnalyzer.Gateways.ProductAggregate;

namespace ProductAnalyzer.Domain.ProductAggregate
{
    public class ProductQuery(IProductGateway productGateway) : IProductQuery
    {
        public async Task<IEnumerable<Product>> QueryWithAsync(IProductFilter productFilter)
        {
            var allProducts = await productGateway.GetAllAsync();
            return productFilter.Filter(allProducts);
        }
    }
}
