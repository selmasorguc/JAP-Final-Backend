namespace MovieApp.Database
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Entities.StoredProceduresEntities;

    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
       IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
       IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Stored procedures models
            modelBuilder.Entity<Top10Item>().HasNoKey();
            modelBuilder.Entity<TopScreened>().HasNoKey();
            modelBuilder.Entity<TopSold>().HasNoKey();


            modelBuilder.Entity<AppUser>()
               .HasMany(ur => ur.UserRoles)
               .WithOne(u => u.User)
               .HasForeignKey(ur => ur.UserId)
               .IsRequired();

            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

        }
        public DbSet<Media> Media { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Screening> Screenings { get; set; }

        public DbSet<Top10Item> TopRatedMovies { get; set; }

        public DbSet<TopScreened> TopScreenedMovies { get; set; }

        public DbSet<TopSold> TopSoldMovies { get; set; }
    }
}
