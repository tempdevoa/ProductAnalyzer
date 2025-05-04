using Microsoft.AspNetCore.Mvc;
using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.WebApi.Contracts;

namespace ProductAnalyzer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductQuery productQuery) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var bottles = await productQuery.QueryWithAsync(ProductFilterFactory.NonFiltering);
            return Ok(ToContract(bottles));
        }

        [HttpGet]
        [Route("MostExpensiveAndCheapest")]
        public async Task<IActionResult> GetMostExpensiveAndCheapestAsync()
        {
            var bottles = await productQuery.QueryWithAsync(ProductFilterFactory.MostExpensiveAndCheapest);
            return Ok(ToContract(bottles));
        }

        [HttpGet]
        [Route("MatchingPrice")]
        public async Task<IActionResult> MatchingPriceAsync(decimal price)
        {
            var bottles = await productQuery.QueryWithAsync(ProductFilterFactory.MatchingPrice(price));
            return Ok(ToContract(bottles));
        }

        private static IEnumerable<ProductContract> ToContract(IEnumerable<Product> products)
        {
            // This methods could be split into its own assembler class if wanted.
            return products.Select(product => new ProductContract { Name = product.Name, Articles = ToContract(product.Articles) });
        }

        private static ArticleContract[] ToContract(IEnumerable<Article> articles)
        {
            return articles.Select(article => new ArticleContract { Price = article.Price, PricePerUnit = article.PricePerLitre }).ToArray();
        }
    }
}
