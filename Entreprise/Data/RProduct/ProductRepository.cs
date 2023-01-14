
using Entreprise.Models;
using System.Collections.Generic;

namespace Entreprise.Data.RProduct
{
    public class ProductRepository :  Repository<Product>, IProductRepository
    {
        private readonly ProjectContext context;
        public ProductRepository()
        {
            this.context = ProjectContext.Instance(); ;
        }
        public IEnumerable<Product> GetbyStock(Stock s)
        {
           
            IEnumerable<Product> l = this.context.Product.Where(x => x.Stock == s).ToList();
            return l;
        }
        public IEnumerable<Product> GetbyVendor(Vendor v)
        {

            IEnumerable<Product> l = this.context.Product.Where(x => x.Vendor == v).ToList();
            return l;
        }
        public IEnumerable<Product> GetbyCategory(Category c)
        {

            IEnumerable<Product> l = this.context.Product.Where(x => x.Category == c).ToList();
            return l;
        }

        public Product getByID(int id)
        {
            return this.context.Product.Find(id);
        }
        public void UpdateProduct(Product product)
        {
        // this.context.Product.Entry(product).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
        this.context.Product.Find(product.Id).Name=product.Name;
        this.context.SaveChanges();
        }
    }
}
