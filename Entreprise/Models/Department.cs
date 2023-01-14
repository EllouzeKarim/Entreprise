using System.ComponentModel.DataAnnotations;

namespace Entreprise.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string? Name {  get; set; }
        public virtual ICollection<User>? Users { get; set; }

        public virtual Hod? HOD { get; set; }
    }
}
