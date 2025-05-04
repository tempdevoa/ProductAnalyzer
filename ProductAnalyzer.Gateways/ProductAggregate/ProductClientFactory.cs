namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public class ProductClientFactory(IHttpClientFactory httpClientFactory) : IProductClientFactory
    {
        private static string baseUrl = "https://flapotest.blob.core.windows.net/test/";

        public static void SetBaseUrl(string baseUrlParam)
        {
            baseUrl = baseUrlParam;
        }

        public IProductClient Create()
        {
            var httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            return new ProductClient(httpClient);
        }
    }
}
