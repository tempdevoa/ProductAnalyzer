using Microsoft.AspNetCore.Mvc;
using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.Domain.ProductAggregate.Filtering;
using ProductAnalyzer.Gateways.ProductAggregate;

namespace ProductAnalyzer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductQuery productQuery) : ControllerBase
    {
        [HttpGet]
        [Route("Combined")]
        public async Task<IActionResult> GetAsync(string url, decimal price)
        {
            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return BadRequest("Invalid URL");
            }

            ProductClientFactory.SetBaseUrl(url);

            var matchedPrice = await productQuery.QueryWithAsync(ProductFilterFactory.MatchingPrice(price));
            var mostExpensiveAndCheapest = await productQuery.QueryWithAsync(ProductFilterFactory.MostExpensiveAndCheapest);
            var mostNumberOfPackagingUnits = await productQuery.QueryWithAsync(ProductFilterFactory.MostBottles);

            var combinedResponse = new
            {
                MatchedPrice = ToContract(matchedPrice),
                MostExpensiveAndCheapest = ToContract(mostExpensiveAndCheapest),
                MostNumberOfPackagingUnits = ToContract(mostNumberOfPackagingUnits)
            };

            return Ok(combinedResponse);
        }

        [HttpGet]
        [Route("MostExpensiveAndCheapest")]
        public async Task<IActionResult> GetMostExpensiveAndCheapestAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return BadRequest("Invalid URL");
            }

            ProductClientFactory.SetBaseUrl(url);

            var bottles = await productQuery.QueryWithAsync(ProductFilterFactory.MostExpensiveAndCheapest);
            return Ok(ToContract(bottles));
        }

        [HttpGet]
        [Route("MatchingPrice")]
        public async Task<IActionResult> MatchingPriceAsync(string url, decimal price)
        {
            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return BadRequest("Invalid URL");
            }

            ProductClientFactory.SetBaseUrl(url);

            var bottles = await productQuery.QueryWithAsync(ProductFilterFactory.MatchingPrice(price));
            return Ok(ToContract(bottles));
        }

        [HttpGet]
        [Route("MostNumberOfPackagingUnits")]
        public async Task<IActionResult> MostNumberOfPackagingUnitsAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return BadRequest("Invalid URL");
            }

            ProductClientFactory.SetBaseUrl(url);

            var bottles = await productQuery.QueryWithAsync(ProductFilterFactory.MostBottles);
            return Ok(ToContract(bottles));
        }

        private static IEnumerable<Contracts.ProductContract> ToContract(IEnumerable<Product> products)
        {
            // This methods could be split into its own assembler class if wanted.
            return products.Select(product => new Contracts.ProductContract { Name = product.Name, Articles = ToContract(product.Articles) });
        }

        private static Contracts.ArticleContract[] ToContract(IEnumerable<Article> articles)
        {
            return articles.Select(article => new Contracts.ArticleContract
            { 
                Price = article.Price, 
                PricePerUnit = article.PricePerUnit, 
                NumberOfPackagingUnits = article.NumberOfPackagingUnits 
            }).ToArray();
        }
    }
}
