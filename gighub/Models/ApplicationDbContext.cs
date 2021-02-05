using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using gighub.Models;

namespace gighub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>().
                HasRequired(a => a.Gig)
                .WithMany()
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Following>().
               HasRequired(a => a.Followers)
               .WithMany(a => a.Followee)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Following>().
               HasRequired(a => a.Followee)
               .WithMany(a => a.Followers)
               .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }


    }
}