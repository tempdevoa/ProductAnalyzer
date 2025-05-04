namespace ProductAnalyzer.Domain.ProductAggregate
{
    public class Product
    {
        public Product(string name, IEnumerable<Article> articles)
        {
            Name = name;
            Articles = articles?.ToList() ?? new List<Article>();
        }

        public string Name { get; }
        
        public IReadOnlyCollection<Article> Articles { get; }
        
        public bool HasArticles => Articles.Any();

        public int NumberOfMostPackagingUnits => Articles.Max(a => a.NumberOfPackagingUnits);

        public decimal HighestPricePerUnit => Articles.Max(a => a.PricePerUnit);

        public decimal CheapestPricePerUnit => Articles.Min(a => a.PricePerUnit);

        public Product ReduceToArticlesWithMatchingNumberOfPackagingUnits(int numberOfPackagingUnits)
        {
            var filteredArticles = Articles.Where(a => a.NumberOfPackagingUnits.Equals(numberOfPackagingUnits)).ToList();
            return new Product(Name, filteredArticles);
        }

        public Product ReduceToArticlesWithMatchingPrice(decimal price)
        {
            var filteredArticles = Articles.Where(a => a.Price.Equals(price)).ToList();
            return new Product(Name, filteredArticles);
        }

        public Product ReduceToArticlesWithMatchingPricePerUnit(decimal cheapest, decimal highest)
        {
            var filteredArticles = Articles.Where(a => a.PricePerUnit.Equals(cheapest) || a.PricePerUnit.Equals(highest)).ToList();
            return new Product(Name, filteredArticles);
        }
    }
}
