

using Entreprise.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Entreprise.Data.RUser
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ProjectContext context;
        public UserRepository()
        {
            this.context = ProjectContext.Instance(); ;
        }
        public IEnumerable<User> getList()
        {
            return this.context.User.Include(x=>x.Department).Include(x => x.Tasks).ToList();
        }
        public User getByID(int id)
        {
            return this.context.User.Find(id);
        }
        public User getByEmail(string email)
        {
            List<User> l =  this.context.User.Where(x => x.Email == email).ToList();
           
              if (l.Count() != 0) { 
            return getByID(l[0].Id);
            } 
            return null;
        }

        public void updateUser(int id,User u)
        {

            this.context.User.Find(id).Firstname=u.Firstname;
            this.context.User.Find(id).Lastname = u.Lastname;
            this.context.User.Find(id).Email = u.Email;
            this.context.User.Find(id).Phone_Number = u.Phone_Number;
            this.context.User.Find(id).Password = u.Password;
            this.context.User.Find(id).ROLE = u.ROLE;
            this.context.User.Find(id).Function = u.Function;
            this.context.User.Find(id).Department = u.Department;
            this.context.SaveChanges();

        }
    }
}
