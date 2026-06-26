using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public bool Create(T entity)
        {
            _dbSet.Add(entity);
            return Save();
        }

        
        public bool Exists(int id)
        {
            var entity = GetById(id);
            return entity != null;
        }

        public virtual ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateException ex)
            {
                System.Diagnostics.Debug.WriteLine($"Data save failure: {ex.InnerException?.Message}");
                return false;
            }
        }

        public bool Update(T entity)
        {
            _dbSet.Update(entity);
            return Save();
        }
    }
}
