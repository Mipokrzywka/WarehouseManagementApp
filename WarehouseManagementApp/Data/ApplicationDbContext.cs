using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductChange> ProductChanges { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
        public DbSet<WarehouseManagementApp.Models.TaskStatus> TaskStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }        
        public DbSet<WorkTask> WorkTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite keys for many-to-many relationships
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId, });

            modelBuilder.Entity<UserNotification>()
                .HasKey(un => new { un.UserId, un.NotificationId });


            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId});

            // Configure unique indexes and relationships
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.QrCode)
                .IsUnique()
                .HasFilter("[DeletedAt] IS NULL");
            modelBuilder.Entity<OrderProduct>()
                .HasIndex(op => new { op.OrderId, op.ProductId })
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasIndex(p => new { p.Name, p.CategoryId })
                .IsUnique()
                .HasFilter("[DeletedAt] IS NULL");

            modelBuilder.Entity<ProductCategory>()
                .HasIndex(pc => pc.Name)
                .IsUnique()
                .HasFilter("[DeletedAt] IS NULL");

            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique()
                .HasFilter("[DeletedAt] IS NULL");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique()
                .HasFilter("[DeletedAt] IS NULL");

            modelBuilder.Entity<Module>()
                .HasIndex(m => m.Name)
                .IsUnique();

            modelBuilder.Entity<Brand>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<OrderStatus>()
                .HasIndex(os => os.Name)
                .IsUnique();

            modelBuilder.Entity<Permission>()
                .HasIndex(p => p.Name)
                .IsUnique();

            // Configure decimal precision for cost amounts
            modelBuilder.Entity<Product>()
                .Property(p => p.CostAmt)
                .HasPrecision(10, 2);

            modelBuilder.Entity<OrderProduct>()
                .Property(op => op.CostAmt)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.CostAmt)
                .HasPrecision(10, 2);

            // Configure relationships for Order entity
            modelBuilder.Entity<Order>()
                 .HasMany(o => o.OrderProducts)
                  .WithOne(op => op.Order)
                 .HasForeignKey(op => op.OrderId)
                 .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.CreatedBy)
                .WithMany()
                .HasForeignKey(o => o.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Reviewer)
                .WithMany()
                .HasForeignKey(o => o.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure global query filters for soft deletion
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => p.DeletedAt == null);
            modelBuilder.Entity<Order>()
                .HasQueryFilter(o => o.DeletedAt == null);          
            modelBuilder.Entity<ProductCategory>()
                .HasQueryFilter(pc => pc.DeletedAt == null);
            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => r.DeletedAt == null);
            modelBuilder.Entity<User>()
                .HasQueryFilter(u => u.DeletedAt == null);


            DataSeeder.Seed(modelBuilder);
        }



    }
}
