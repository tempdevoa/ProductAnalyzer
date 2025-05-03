namespace ProductAnalyzer.Domain.ProductAggregate
{
    public interface IBottleQuery
    {
        Task<IEnumerable<Bottle>> QueryWithAsync(ProductFilter productFilter);
    }
}
