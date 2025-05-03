namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public class ProductClientFactory(IHttpClientFactory httpClientFactory) : IProductClientFactory
    {
        public IProductClient Create()
        {
            var httpClient = httpClientFactory.CreateClient("ProductClient");
            return new ProductClient(httpClient);
        }
    }
}
