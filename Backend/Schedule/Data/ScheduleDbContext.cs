using Microsoft.EntityFrameworkCore;
using Schedule.Data.Models;

namespace Schedule.Data
{
    public class ScheduleDbContext : DbContext
    {   
        private readonly IConfiguration _configuration;
        
        public ScheduleDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Group> Groups{ get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<Audience> Audiences { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasKey(x => x.Id);
            modelBuilder.Entity<Subject>().HasKey(x => x.Id);
            modelBuilder.Entity<Teacher>().HasKey(x => x.Id);
            modelBuilder.Entity<Audience>().HasKey(x => x.Id);
            modelBuilder.Entity<Lesson>().HasKey(x => x.Id);
            modelBuilder.Entity<Group>().HasIndex(u => u.Number).IsUnique();
            modelBuilder.Entity<Subject>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<Teacher>().HasIndex(u => u.FullName).IsUnique();
            modelBuilder.Entity<Audience>().HasIndex(u => u.Number).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 31)));
        }
    }
}
