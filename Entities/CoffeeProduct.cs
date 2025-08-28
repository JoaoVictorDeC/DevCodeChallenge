

namespace DevCodeChallenge.Entities 
{ 
    public class CoffeeProduct
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal CoffeePrice { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

        public string NasaTitle { get; set; }
        public string NasaUrl { get; set; }
        public string NasaExplanation { get; set; }
    } 
}