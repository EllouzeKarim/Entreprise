using Entreprise.Models;

namespace Entreprise.Data.RDepartment
{
    public interface IDepartmentRepository : IRepository<Department>
    {
       public IEnumerable<Department> GetLIST();
        public Department getByID(int id);


    }
}
