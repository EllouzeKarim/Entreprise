using Entreprise.Models;

namespace Entreprise.Data.RProduct
{
    public interface IProductRepository : IRepository<Product>
    {
        public IEnumerable<Product> GetbyStock(Stock s);
        public IEnumerable<Product> GetbyVendor(Vendor v);
        public IEnumerable<Product> GetbyCategory(Category c);

        public Product getByID(int id);
        public void UpdateProduct(Product p);
    }
}
