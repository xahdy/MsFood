﻿using System.Linq.Expressions;

namespace Cadastro.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Remove(T entity);
        Task SaveChangesAsync();
    }
}
