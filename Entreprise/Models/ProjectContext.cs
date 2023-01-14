using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

namespace Entreprise.Models
{
    public class ProjectContext : DbContext

    {
        public DbSet<User> User { get; set; }
        public DbSet<Hod> Hod { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Tasks> Task { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\khaled\\Desktop\\GL3\\Framework\\Project\\Project.db");
            }*/
        private ProjectContext(DbContextOptions o) : base(o)
        {
        }

        private static ProjectContext? Context;
        public static ProjectContext Instance()
        {

            if (Context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ProjectContext>();
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\ad\\Desktop\\Nouveau dossier\\Project\\Project.db");
                Debug.WriteLine("Une nouvelle instance créee!");
                Context = new ProjectContext(optionsBuilder.Options);
            }

            return Context;

        }


    }
}