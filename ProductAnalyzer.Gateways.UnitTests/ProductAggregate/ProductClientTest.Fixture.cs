using ProductAnalyzer.Gateways.ProductAggregate;
using System.Net;
using System.Reflection;

namespace ProductAnalyzer.Gateways.UnitTests.ProductAggregate
{
    public sealed partial class ProductClientTest
    {
        private class Fixture
        {
            private HttpClient httpClient;

            public Fixture()
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "ProductAnalyzer.Gateways.UnitTests.ProductAggregate.Products.json";

                string jsonResponse;
                using (Stream stream = assembly.GetManifestResourceStream(resourceName)!)
                using (StreamReader reader = new StreamReader(stream))
                {
                    jsonResponse = reader.ReadToEnd();
                }
                
                var mockHttpMessageHandler = new MockHttpMessageHandler(jsonResponse, HttpStatusCode.OK);
                httpClient = new HttpClient(mockHttpMessageHandler)
                {
                    BaseAddress = new Uri("https://example.com/")
                };
            }

            public ProductClient CreateTestObject()
            {

                return new ProductClient(httpClient);
            }
        }
    }
}
