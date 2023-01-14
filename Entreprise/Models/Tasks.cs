using System.ComponentModel.DataAnnotations;

namespace Entreprise.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        public string? Object { get; set; }
        public string? Content { get; set; }
        public string? Status { get; set; }
        public virtual User? User { get; set; }
        public virtual Hod? HOD { get; set; }

    }
}
