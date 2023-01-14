

using Entreprise.Models;

namespace Entreprise.Data.RHOD
{
    public class HODRepository : Repository<Hod>, IHODRepository
    {
        private readonly ProjectContext context;
        public HODRepository()
        {
            this.context = ProjectContext.Instance(); ;
        }
    }
}
