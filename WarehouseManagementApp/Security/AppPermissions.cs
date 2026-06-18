namespace WarehouseManagementApp.Security
{
    public static class AppPermissions
    {
        //Product access
        public const string ProductsRead = "Products:Read";
        public const string ProductsManage = "Products:Manage";

        //Product category access
        public const string ProductCategoriesRead = "ProductCategories:Read";
        public const string ProductCategoriesManage = "ProductCategories:Manage";

        //Orders access
        public const string OrdersRead = "Orders:Read";
        public const string OrdersCreate = "Orders:Create";
        public const string OrdersProcess = "Orders:Process";

        //Users access
        public const string UsersRead = "Users:Read";
        public const string UsersManage = "Users:Manage";

        //Roles access
        public const string RolesRead = "Roles:Read";
        public const string RolesManage = "Roles:Manage";
        

        public static readonly string[] All = [
            ProductsRead,ProductsManage,ProductCategoriesManage,
            OrdersRead, OrdersCreate, OrdersProcess, UsersRead,
            UsersManage, RolesRead, RolesManage
            ];
    }
}
