using ProductAnalyzer.Gateways.ProductAggregate;

namespace ProductAnalyzer.Domain.ProductAggregate
{
    public class ProductQuery(IProductGateway productGateway) : IProductQuery
    {
        public async Task<IEnumerable<Product>> QueryWithAsync(ProductFilter productFilter)
        {
            var allProducts = await productGateway.GetAllAsync();
            return productFilter(allProducts);
        }
    }
}
