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

        private static IEnumerable<ProductContract> ToContract(IEnumerable<Product> products)
        {
            // This methods could be split into its own assembler class if wanted.
            return products.Select(product => new ProductContract { Name = product.Name, Articles = ToContract(product.Articles) });
        }

        private static ArticleContract[] ToContract(IEnumerable<Article> articles)
        {
            return articles.Select(article => new ArticleContract { PricePerUnit = article.PricePerLitre }).ToArray();
        }
    }
}
