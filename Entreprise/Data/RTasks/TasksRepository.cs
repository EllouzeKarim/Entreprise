

using Entreprise.Models;

namespace Entreprise.Data.RTasks
{
    public class TasksRepository : Repository<Tasks>, ITasksRepository
    {
        private readonly ProjectContext context;
        public TasksRepository()
        {
            this.context = ProjectContext.Instance(); ;
        }
    }
}
