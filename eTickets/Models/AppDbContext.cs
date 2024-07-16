using eTickets.Data;
using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace eTickets.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext() : base()
        {
        
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-E2BL44H\\SQLEXPRESS; Initial Catalog = eTickets; Integrated Security=True;Trust Server Certificate=True;");
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.MovieId,
                am.ActorId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);

        }
        public DbSet<Actor>? Actors { get; set; }
        public DbSet<Cinema>? Cinemas { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Producer>? Producers { get; set; }
        public DbSet<Actor_Movie>? Actor_Movies { get; set; }
    }
}





/*
 
using Microsoft.EntityFrameworkCore;

namespace EFAssignment.Models
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-E2BL44H\\SQLEXPRESS; Initial Catalog = BeforeMid; Integrated Security=True;Trust Server Certificate=True;");
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Results_CourseTrainee> Results_CourseTrainees { get; set; }
    }
}


*/