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
    }
}
