using Microsoft.AspNetCore.Mvc;
using ProductAnalyzer.Domain.ProductAggregate;

namespace ProductAnalyzer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BottleController(IBottleQuery bottleQuery) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var bottles = await bottleQuery.QueryWithAsync(ProductFilterFactory.NonFiltering);
            return Ok(ToContract(bottles));
        }

        private static IEnumerable<BottleContract> ToContract(IEnumerable<Bottle> bottles)
        {
            // This method could be split into its own assembler class if wanted.
            return bottles.Select(b => new BottleContract { Brand = b.Name, Price = b.PricePerLitre });
        }
    }
}
