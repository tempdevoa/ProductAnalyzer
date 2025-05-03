namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public interface IProductClientFactory
    {
        IProductClient Create();
    }
}
