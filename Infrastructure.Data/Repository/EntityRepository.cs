using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        private DbSet<T> _dbSet => _context.Set<T>();

        public EntityRepository(AppDbContext appDbContext)
        {
            _context = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext), "DbContext is null.");
        }

        public async Task AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            IQueryable<T> query = ApplyIncludes(_dbSet);

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        private IQueryable<T> ApplyIncludes(DbSet<T> dbSet)
        {
            IEntityType entityType = _context.Model.FindEntityType(typeof(T));

            IQueryable<T> query = dbSet.AsQueryable();

            foreach(var navigation in entityType.GetNavigations())
            {
                query = query.Include(navigation.Name);
            }

            return query;
        }
    }
}
