

using Entreprise.Models;

namespace Entreprise.Data.RCategory
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public void UpdateCategory(Category category);
    }
}
