using System.ComponentModel.DataAnnotations;

namespace Entreprise.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Reference { get; set; }
        public float Bought_Price { get; set; }
        public float Sold_Price { get; set; }
        public int Sold { get; set; }
        public int Left { get; set; }

 
        public virtual Vendor? Vendor { get; set; }
        public virtual Stock? Stock { get; set; }
        public virtual Category? Category { get; set; }
    }
}
