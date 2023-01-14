using Entreprise.Data.RCategory;
using Entreprise.Data.RDepartment;
using Entreprise.Data.RHOD;
using Entreprise.Data.RProduct;
using Entreprise.Data.RStock;
using Entreprise.Data.RTasks;
using Entreprise.Data.RUser;
using Entreprise.Data.RVendor;

namespace Entreprise.Data
{
    public interface IUnit : IDisposable
    {
        public ICategoryRepository Category { get;  } 

        public IDepartmentRepository Department { get; }
        public IHODRepository HOD { get; }
        public IProductRepository Product { get; }
        public IStockRepository Stock { get; }
        public ITasksRepository Tasks { get; }
        public IUserRepository User { get; }
        public IVendorRepository Vendor { get; }
        bool complete();
    }
}
