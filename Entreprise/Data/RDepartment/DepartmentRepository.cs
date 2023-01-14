using Entreprise.Models;
using Microsoft.EntityFrameworkCore;

namespace Entreprise.Data.RDepartment
{
    public class DepartmentRepository : Repository<Department> , IDepartmentRepository
    {
        private readonly ProjectContext context;
        public DepartmentRepository() {
            this.context = ProjectContext.Instance();

        }
        public IEnumerable<Department> GetLIST()
        {
            return this.context.Department.Include(e=>e.HOD).ToList();
        }
        public Department getByID(int id)
        {
            return this.context.Department.Find(id);
        }
    }
}
