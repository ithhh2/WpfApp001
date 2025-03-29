using Microsoft.EntityFrameworkCore;

namespace WpfApp001
{
    public class EFDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=root;password=123456;database=stu;sslmode=none;";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        public DbSet<Student> Students { get; set; }

    }
}
