using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YMB.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int simpleUserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Boolean hasPaid { get; set; }
        public Boolean isPlayingFootballPool { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("simpleUserId", this.simpleUserId.ToString()));
            userIdentity.AddClaim(new Claim("isPlayingFootballPool", this.isPlayingFootballPool.ToString()));
            userIdentity.AddClaim(new Claim("firstName", this.firstName.ToString()));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<AccountTransactions> AccountTransactions { get; set; }

        public DbSet<Beers> Beers { get; set; }

        public DbSet<BeerImages> BeerImages { get; set; }

        public DbSet<Paycheck> Paycheck { get; set; }

        public DbSet<Requests> Requests { get; set; }

        public DbSet<FootballGame> FootballGame { get; set; }

        public DbSet<FootballTeam> FootballTeam { get; set; }

        public DbSet<FootballPoolUsers> FootballPoolUser { get; set; }

        public DbSet<FootballPoolUserPicks> FootballPoolUserPicks { get; set; }

        public DbSet<FootballGameResults> FootballGameResults { get; set; }

    }
}