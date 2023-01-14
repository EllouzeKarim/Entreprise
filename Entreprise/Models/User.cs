using System.ComponentModel.DataAnnotations;

namespace Entreprise.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public  string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }

        public int Phone_Number { get; set; }
        public string? Function { get; set; }
        public string? ROLE { get; set; }
        
        public virtual ICollection<Tasks>? Tasks { get; set; }
        public virtual Department? Department { get; set; }
         

    }
}
