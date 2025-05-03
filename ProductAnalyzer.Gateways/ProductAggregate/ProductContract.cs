namespace ProductAnalyzer.Gateways.ProductAggregate
{
    public class ProductContract
    {
        public ProductContract()
        {
            Name = string.Empty;
            PricePerUnit = "(1,80 €/Liter)";
        }

        public string Name { get; set; }
        
        public string PricePerUnit { get; set; }
    }
}
