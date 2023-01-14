using System.ComponentModel.DataAnnotations;

namespace Entreprise.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
