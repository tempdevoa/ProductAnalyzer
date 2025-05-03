using ProductAnalyzer.Domain.ProductAggregate;
using System.Text.RegularExpressions;

namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public static class ProductAssembler
    {
        private static readonly Regex pricePerLitreRegex = new Regex(@"\((\d+,\d+)\s?€");

        public static Product ToProduct(ProductContract contract)
        {
            return new Product(contract.Name, ToPricePerLitre(contract.PricePerUnit));
        }

        private static decimal ToPricePerLitre(string pricePerLitre)
        {
            var match = pricePerLitreRegex.Match(pricePerLitre);
            if (!match.Success)
            {
                return 0m;
            }
            return decimal.Parse(match.Groups[1].Value);
        }
    }
}
