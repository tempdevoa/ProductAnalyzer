using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.Domain.ProductAggregate.Filtering;

namespace ProductAnalyzer.Domain.Testing.ProductAggregate.Filtering
{
    public class OnlyFirstProductFilter : IProductFilter
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products)
        {
            return products.Take(1);
        }
    }
}
