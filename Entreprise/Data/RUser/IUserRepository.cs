
using Entreprise.Models;

namespace Entreprise.Data.RUser
{
    public interface IUserRepository : IRepository<User>
    {
        public IEnumerable<User> getList();
        public User  getByID(int id);    
        public User  getByEmail(string email);

        public void updateUser(int id, User u);
    }
}
