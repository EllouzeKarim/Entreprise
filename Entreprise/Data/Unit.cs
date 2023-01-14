using Entreprise.Data.RCategory;
using Entreprise.Data.RDepartment;
using Entreprise.Data.RHOD;
using Entreprise.Data.RProduct;
using Entreprise.Data.RStock;
using Entreprise.Data.RTasks;
using Entreprise.Data.RUser;
using Entreprise.Data.RVendor;
using Entreprise.Models;

namespace Entreprise.Data
{
    public class Unit : IUnit
    {
        private readonly ProjectContext _Context;
        public ICategoryRepository Category { get; private set; } 

        public IDepartmentRepository Department { get; private set; }
        public IHODRepository HOD { get; private set; }
        public IProductRepository Product { get; private set; }
        public IStockRepository Stock { get; private set; }
        public  ITasksRepository Tasks { get; private set; }
        public IUserRepository User { get; private set; }
        public IVendorRepository Vendor { get; private set; }

        public Unit()
        {
            this._Context = ProjectContext.Instance(); 
            Category = new CategoryRepository();
            Department = new DepartmentRepository();
            Product = new ProductRepository();
            Stock = new StockRepository();
            Tasks = new TasksRepository();
            User = new UserRepository();
            Vendor = new VendorRepository();
             

        }
    public bool complete()
    {

        try
        {
            int result = _Context.SaveChanges();
            if (result > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void Dispose()
    {
        _Context.Dispose();
    }
}
} 