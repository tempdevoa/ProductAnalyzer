using Microsoft.AspNetCore.Mvc;
using ProductAnalyzer.Domain.ProductAggregate;

namespace ProductAnalyzer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BottleController(IProductQuery bottleQuery) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var bottles = await bottleQuery.QueryWithAsync(ProductFilterFactory.NonFiltering);
            return Ok(ToContract(bottles));
        }

        private static IEnumerable<BottleContract> ToContract(IEnumerable<Product> products)
        {
            // This method could be split into its own assembler class if wanted.
            return products.Select(product => new BottleContract { Brand = product.Name, Price = product.Articles.FirstOrDefault()?.PricePerLitre ?? 0});
        }
    }
}
