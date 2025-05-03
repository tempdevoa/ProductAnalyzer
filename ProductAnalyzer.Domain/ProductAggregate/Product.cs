namespace ProductAnalyzer.Domain.ProductAggregate
{
    public class Product
    {
        public Product(string name, decimal pricePerLitre)
        {
            Name = name;
            PricePerLitre = pricePerLitre;
        }
        public string Name { get; set; }
        
        public decimal PricePerLitre { get; set; }
    }
}
