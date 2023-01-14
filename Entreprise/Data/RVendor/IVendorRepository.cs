using Entreprise.Models;

namespace Entreprise.Data.RVendor
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        public  void UpdateVendor(Vendor vendor);
    }
}
