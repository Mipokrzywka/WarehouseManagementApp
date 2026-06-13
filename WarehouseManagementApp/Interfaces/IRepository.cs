namespace WarehouseManagementApp.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T? GetById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Save();
        bool Exists(int id);
    }
}
