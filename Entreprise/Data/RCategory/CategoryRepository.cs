using Entreprise.Models;

namespace Entreprise.Data.RCategory
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ProjectContext context;
        public CategoryRepository() {
            this.context = ProjectContext.Instance(); ;
        }
        public void UpdateCategory(Category category)
        {
            this.context.Category.Find(category.Id).Name=category.Name;
            this.context.SaveChanges();

        }
    }
}
