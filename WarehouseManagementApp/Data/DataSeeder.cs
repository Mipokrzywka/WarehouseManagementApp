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

            var taskTodo = new WarehouseManagementApp.Models.TaskStatus { Id = 1, Name = "Do zrobienia" };
            var taskInProg = new WarehouseManagementApp.Models.TaskStatus { Id = 2, Name = "W toku" };
            var taskDone = new WarehouseManagementApp.Models.TaskStatus { Id = 3, Name = "Zakończone" };

            modelBuilder.Entity<WarehouseManagementApp.Models.TaskStatus>().HasData(taskTodo, taskInProg, taskDone);

            var moduleProducts= new Module { Id = 1, Name = "Products" };
            var moduleProductCategories = new Module { Id = 2, Name = "Product categories" };
            var moduleOrders = new Module { Id = 3, Name = "Orders" };
            var moduleRoles = new Module { Id = 4, Name = "Roles" };

            modelBuilder.Entity<Module>().HasData(moduleProducts, moduleProductCategories, moduleOrders, moduleRoles);

            var catElectronics = new ProductCategory { Id = 1, Name = "Elektronika" };
            var catTools = new ProductCategory { Id = 2, Name = "Narzędzia" };
            var catChemicals = new ProductCategory { Id = 3, Name = "Chemia magazynowa" };

            modelBuilder.Entity<ProductCategory>().HasData(catElectronics, catTools, catChemicals);

            // 2. SEED: Role i Uprawnienia
            var permRead = new Permission { Id = 1, Name = "Read_All", Description = "Odczyt wszystkich danych" };
            var permWrite = new Permission { Id = 2, Name = "Write_All", Description = "Zapis i edycja danych" };
            var permDelete = new Permission { Id = 3, Name = "Delete_Records", Description = "Usuwanie rekordów z systemu" };

            modelBuilder.Entity<Permission>().HasData(permRead, permWrite, permDelete);

            var roleAdmin = new Role { Id = 1, Name = "Administrator" };
            var roleManager = new Role { Id = 2, Name = "Manager" };
            var roleWorker = new Role { Id = 3, Name = "Pracownik" };

            modelBuilder.Entity<Role>().HasData(roleAdmin, roleManager, roleWorker);

            // Tabela łącznikowa: Role <-> Uprawnienia (Wiele-do-Wielu)
            //modelBuilder.Entity<RolePermission>().HasData(
            //    new RolePermission { RoleId = 1, PermissionId = 1 },
            //    new RolePermission { RoleId = 1, PermissionId = 2 },
            //    new RolePermission { RoleId = 1, PermissionId = 3 },
            //    new RolePermission { RoleId = 2, PermissionId = 1 },
            //    new RolePermission { RoleId = 2, PermissionId = 2 },
            //    new RolePermission { RoleId = 3, PermissionId = 1 }
            //);

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

            // Tabela łącznikowa: Użytkownicy <-> Role
            //modelBuilder.Entity<UserRole>().HasData(
            //    new UserRole { UserId = 1, RoleId = 1 },
            //    new UserRole { UserId = 2, RoleId = 3 }
            //);

            // 4. SEED: Powiadomienia dla użytkowników
            var notifWelcome = new Notification { Id = 1, Content = "Witaj w systemie WMS! Zmień swoje hasło po pierwszym zalogowaniu." };
            var notifInventory = new Notification { Id = 2, Content = "Przypomnienie: W piątek odbędzie się inwentaryzacja sektora A." };

            modelBuilder.Entity<Notification>().HasData(notifWelcome, notifInventory);

            modelBuilder.Entity<UserNotification>().HasData(
                new UserNotification { UserId = 1, NotificationId = 1 },
                new UserNotification { UserId = 2, NotificationId = 1 },
                new UserNotification { UserId = 2, NotificationId = 2 }
            );

            // 5. SEED: Produkty i historia zmian stanów (ProductChanges)
            var prodLaptop = new Product { Id = 1, CategoryId = 1, Name = "Laptop Dell Vostro", QrCode = "QR-LAP-001", Quantity = 15, CostAmt = 3500.00m };
            var prodScrewdriver = new Product { Id = 2, CategoryId = 2, Name = "Wkrętarka Makita 18V", QrCode = "QR-TOO-052", Quantity = 40, CostAmt = 450.50m };

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

            // 7. SEED: Zamówienia (Orders) i produkty w zamówieniach
            //var order1 = new Order { Id = 1, StatusId = 1, CreatorId = 2, CostAmt = 3950.50m };

            //modelBuilder.Entity<Order>().HasData(order1);

            //modelBuilder.Entity<OrderProduct>().HasData(
            //    new OrderProduct {OrderId = 1, ProductId = 1, Quantity = 1, CostAmt = 3500.00m },
            //    new OrderProduct {OrderId = 1, ProductId = 2, Quantity = 1, CostAmt = 450.50m }
            //);

            // 8. SEED: Logi aktywności (ActivityLog)
            modelBuilder.Entity<ActivityLog>().HasData(
                new ActivityLog { Id = 1, ModuleId = 1, ComponentId = 101, Action = "CREATE_PRODUCT", UserId = 1, NewData = "{'Name': 'Laptop Dell Vostro', 'Qty': 15}" }
            );
        }
    }
}