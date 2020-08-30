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
        public DbSet<OrderedFood> OrderedFoods { get; set; }

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

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Delivery)
                .WithOne(d => d.Order)
                .HasForeignKey<Delivery>(d => d.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.ReceiverUser)
                .WithMany(u => u.Orders)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.CourierUser)
                .WithMany(u => u.Orders)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.RestaurantUser)
                .WithMany(u => u.Orders)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderedFood>()
                .HasOne(m => m.Order)
                .WithMany(o => o.OrderedFood)
                .HasForeignKey(of => of.OrderId);

            modelBuilder.Entity<OrderedFood>().HasOne(m => m.Food)
                .WithMany(f => f.OrderedFood)
                .HasForeignKey(of => of.FoodId);
        }
    }
}
