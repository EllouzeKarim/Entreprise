

using Entreprise.Models;

namespace Entreprise.Data.RVendor
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        private readonly ProjectContext context;
        public VendorRepository()
        {
            this.context = ProjectContext.Instance(); ;
        }
        public void UpdateVendor(Vendor vendor)
        {
            this.context.Vendor.Find(vendor.Id).Id = vendor.Id;
            this.context.Vendor.Find(vendor.Id).Name = vendor.Name;
            this.context.Vendor.Find(vendor.Id).Phone_Number = vendor.Phone_Number;
            this.context.SaveChanges();
        }
    }
}
