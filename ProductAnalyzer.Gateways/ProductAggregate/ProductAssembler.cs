using ProductAnalyzer.Domain.ProductAggregate;
using System.Text.RegularExpressions;

namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public static class ProductAssembler
    {
        private static readonly Regex pricePerLitreRegex = new Regex(@"\((\d+,\d+)\s?€");

        public static Product ToProduct(ProductContract contract)
        {
            return new Product(contract.Name ?? string.Empty, ToArticles(contract.Articles));
        }

        private static IReadOnlyCollection<Article> ToArticles(IEnumerable<ArticleContract>? articleContracts)
        {
            if(articleContracts == null || !articleContracts.Any())
            {
                return Array.Empty<Article>();
            }

            return articleContracts.Select(ToArticle).ToList();
        }

        private static Article ToArticle(ArticleContract contract)
        {
            return new Article(contract.Price, ToPricePerLitre(contract.PricePerUnit));
        }

        private static decimal ToPrice(string? price)
        {
            if(price == null)
            {
                return 0m;
            }

            var culture = System.Globalization.CultureInfo.InvariantCulture;
            return decimal.Parse(price, System.Globalization.NumberStyles.AllowDecimalPoint, culture);
        }

        private static decimal ToPricePerLitre(string? pricePerLitre)
        {
            var match = pricePerLitreRegex.Match(pricePerLitre ?? string.Empty);
            if (!match.Success)
            {
                return 0m;
            }
            
            var culture = System.Globalization.CultureInfo.GetCultureInfo("de-DE");
            return decimal.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.AllowDecimalPoint, culture);
        }
    }
}
