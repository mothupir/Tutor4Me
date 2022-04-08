using Microsoft.EntityFrameworkCore;
using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TutoredModule>().HasKey(t => new {t.TutorId, t.ModuleId});
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<TutoredModule> TutoredModule { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
    }
}
