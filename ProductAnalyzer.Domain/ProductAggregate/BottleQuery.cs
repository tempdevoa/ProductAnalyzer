using ProductAnalyzer.Gateways.ProductAggregate;

namespace ProductAnalyzer.Domain.ProductAggregate
{
    public class BottleQuery(IProductGateway productGateway) : IBottleQuery
    {
        public async Task<IEnumerable<Bottle>> QueryWithAsync(ProductFilter productFilter)
        {
            var allProducts = await productGateway.GetAllAsync();
            var filteredProducts = productFilter(allProducts);

            return filteredProducts.Select(ToBottle);
        }

        private Bottle ToBottle(Product product)
        {
            return new Bottle(product.Name, 0);
        }
    }
}
