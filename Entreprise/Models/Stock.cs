namespace Entreprise.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Product>? Products { get; set; }

    }
}
