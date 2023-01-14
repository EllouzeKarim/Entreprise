using System.ComponentModel.DataAnnotations;

namespace Entreprise.Models
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Phone_Number { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
