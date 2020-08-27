using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VeryDeli.Data.Domains;

namespace VeryDeli.Data
{
    public class VeryDeliDataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public VeryDeliDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken");

            modelBuilder.Entity<User>()
                .HasDiscriminator<Enums.UserType>(nameof(User.UserTypeId))
                .HasValue<User>(Enums.UserType.User)
                .HasValue<Customer>(Enums.UserType.Customer)
                .HasValue<Restaurant>(Enums.UserType.Restaurant)
                .HasValue<Courier>(Enums.UserType.Courier)
                .HasValue<Admin>(Enums.UserType.Admin);


            modelBuilder.Entity<Order>().HasOne(x => x.Courier).WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasOne(x => x.Receiver).WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>().HasOne(x => x.Restaurant).WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>().HasOne(x => x.Delivery).WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Delivery>().HasOne(x => x.Order).WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
