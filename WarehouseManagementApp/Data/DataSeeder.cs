using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var statusNew = new OrderStatus { Id = 1, Name = "New" };
            var statusProcessing = new OrderStatus { Id = 2, Name = "Processing" };
            var statusApproved = new OrderStatus { Id = 3, Name = "Approved" };
            var statusRejected = new OrderStatus { Id = 4, Name = "Rejected" };
            var statusCompleted = new OrderStatus { Id = 5, Name = "Completed" };

            modelBuilder.Entity<OrderStatus>().HasData(statusNew, statusProcessing, statusApproved, statusRejected, statusCompleted);

            var taskTodo = new WarehouseManagementApp.Models.TaskStatus { Id = 1, Name = "To do" };
            var taskInProg = new WarehouseManagementApp.Models.TaskStatus { Id = 2, Name = "In progress" };
            var taskDone = new WarehouseManagementApp.Models.TaskStatus { Id = 3, Name = "Finished" };

            modelBuilder.Entity<WarehouseManagementApp.Models.TaskStatus>().HasData(taskTodo, taskInProg, taskDone);

            var moduleProducts = new Module { Id = 1, Name = "Products" };
            var moduleProductCategories = new Module { Id = 2, Name = "Product categories" };
            var moduleOrders = new Module { Id = 3, Name = "Orders" };
            var moduleRoles = new Module { Id = 4, Name = "Roles" };
            var moduleUsers = new Module { Id = 5, Name = "Users" };

            modelBuilder.Entity<Module>().HasData(moduleProducts, moduleProductCategories, moduleOrders, moduleRoles, moduleUsers);

            var catElectronics = new ProductCategory { Id = 1, Name = "Electronics" };
            var catTools = new ProductCategory { Id = 2, Name = "Tools" };
            var catChemicals = new ProductCategory { Id = 3, Name = "AGD" };

            modelBuilder.Entity<ProductCategory>().HasData(catElectronics, catTools, catChemicals);

            var brands = new List<Brand>()
            {
                new Brand { Id = 1, Name = "Lenovo" },
                new Brand { Id = 2, Name = "Samsung" },
                new Brand { Id = 3, Name = "Apple" },
                new Brand { Id = 4, Name = "Dell" },
                new Brand { Id = 5, Name = "HP" },
                new Brand { Id = 6, Name = "Sony" },
                new Brand { Id = 7, Name = "Xiaomi" },
                new Brand { Id = 8, Name = "Logitech" },
                new Brand { Id = 9, Name = "Asus" },
                new Brand { Id = 10, Name = "Microsoft" }
            };

            modelBuilder.Entity<Brand>().HasData(brands);

            // 2. SEED: Role i Uprawnienia
            var permAccessAll = new Permission { Id = 1, Name = "Access:All", Description = "Access to all application functionalities and data" };
            var permProductsRead = new Permission { Id = 2, Name = "Products:Read", Description = "Access to view all products" };
            var permProductsManage = new Permission { Id = 3, Name = "Products:Manage", Description = "Access to add, update and delete products" };
            var permProductCategoriesRead = new Permission { Id = 4, Name = "ProductCategories:Read", Description = "Access to view all product categories" };
            var permProductCategoriesManage = new Permission { Id = 5, Name = "ProductCategories:Manage", Description = "Access to add, update and delete product categories" };
            var permOrdersRead = new Permission { Id = 6, Name = "Orders:Read", Description = "Access to view all orders" };
            var permOrdersCreate = new Permission { Id = 7, Name = "Orders:Create", Description = "Access to add new order requests" };
            var permOrdersProcess = new Permission { Id = 8, Name = "Orders:Process", Description = "Access to process orders" };
            var permUsersRead = new Permission { Id = 9, Name = "Users:Read", Description = "Access to view all users" };
            var permUsersManage = new Permission { Id = 10, Name = "Users:Manage", Description = "Access to add, update and delete users" };
            var permRolesRead = new Permission { Id = 11, Name = "Roles:Read", Description = "Access to view all roles" };
            var permRolesManage = new Permission { Id = 12, Name = "Roles:Manage", Description = "Access to add, update and delete Roles" };
            modelBuilder.Entity<Permission>().HasData(
                permAccessAll, permProductsRead, permProductsManage, permProductCategoriesRead,
                permProductCategoriesManage, permOrdersRead, permOrdersCreate, permOrdersProcess,
                permUsersRead, permUsersManage, permRolesRead, permRolesManage
                );

            var roleAdmin = new Role { Id = 1, Name = "Administrator" };
            var roleManager = new Role { Id = 2, Name = "Manager" };
            var roleWorker = new Role { Id = 3, Name = "Worker" };

            modelBuilder.Entity<Role>().HasData(roleAdmin, roleManager, roleWorker);

            // 3. SEED: Użytkownicy i ich role
            var userAdmin = new User
            {
                Id = 1,
                Email = "admin@wms.pl",
                FirstName = "Jan",
                Surname = "Kowalski",
                PasswordHash = "AQAAAAEAACcQAAAAEFA..."
            };
            var userWorker = new User
            {
                Id = 2,
                Email = "pracownik@wms.pl",
                FirstName = "Adam",
                Surname = "Nowak",
                PasswordHash = "AQAAAAEAACcQAAAAEFA..."
            };

            modelBuilder.Entity<User>().HasData(userAdmin, userWorker);

            // 4. SEED: Powiadomienia dla użytkowników
            var notifWelcome = new Notification { Id = 1, Content = "Welcome in the WMS system!" };
            var notifInventory = new Notification { Id = 2, Content = "Test notification" };

            modelBuilder.Entity<Notification>().HasData(notifWelcome, notifInventory);

            modelBuilder.Entity<UserNotification>().HasData(
                new UserNotification { UserId = 1, NotificationId = 1 },
                new UserNotification { UserId = 2, NotificationId = 1 },
                new UserNotification { UserId = 2, NotificationId = 2 }
            );

            // 5. SEED: Produkty (🔥 TUTAJ PRZYPISUJEMY BRAND_ID!)
            var prodLaptop = new Product { Id = 1, CategoryId = 1, BrandId = 4, Name = "Laptop Dell Vostro", QrCode = "QR-LAP-001", Quantity = 15, CostAmt = 3500.00m }; // BrandId = 4 (Dell)
            var prodScrewdriver = new Product { Id = 2, CategoryId = 2, BrandId = 2, Name = "Wkrętarka Makita 18V", QrCode = "QR-TOO-052", Quantity = 40, CostAmt = 450.50m }; // BrandId = 2 (Tymczasowo Samsung lub dodaj Makitę)

            modelBuilder.Entity<Product>().HasData(prodLaptop, prodScrewdriver);

            modelBuilder.Entity<ProductChange>().HasData(
                new ProductChange { Id = 1, ProductId = 1, Reason = "Dostawa zewnętrzna", QuantityChanged = 15, CreatedById = 1 },
                new ProductChange { Id = 2, ProductId = 2, Reason = "Dostawa zewnętrzna", QuantityChanged = 40, CreatedById = 1 }
            );

            // 6. SEED: Zadania (WorkTasks) i komentarze do nich
            var task1 = new WorkTask { Id = 1, Description = "Rozładunek dostawy elektroniki z palety P-10", StatusId = 1, RoleId = 3 };
            var task2 = new WorkTask { Id = 2, Description = "Weryfikacja stanów chemii w sektorze C", StatusId = 2, RoleId = 2 };

            modelBuilder.Entity<WorkTask>().HasData(task1, task2);

            modelBuilder.Entity<TaskComment>().HasData(
                new TaskComment { Id = 1, TaskId = 1, Content = "Kurier się spóźnia, rozładunek przesunięty na 14:00", CreatedById = 2 }
            );

            // 8. SEED: Logi aktywności (ActivityLog)
            modelBuilder.Entity<ActivityLog>().HasData(
                new ActivityLog { Id = 1, ModuleId = 1, ComponentId = 101, Action = "create", UserId = 1, NewData = "{'Name': 'Laptop Dell Vostro', 'Qty': 15}" }
            );
        }
    }
}