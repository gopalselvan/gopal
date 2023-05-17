using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TestApp.DataModels;
namespace TestAppContext
{
    public class Context : DbContext
    {
        public IConfiguration Configuration { get; }
        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DbSet<StudentModel> students { get; set; }
        public DbSet<EmployeeModel> employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Sqlconfiguration get
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<StudentModel>().ToTable("student");
             modelBuilder.Entity<EmployeeModel>().ToTable("employee");
        }
    }
}
