﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TasksTrackingApp.Infrastructure.Persistence;

namespace TasksTrackingApp.Infrastructure.Repository.UnitOfWork
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TasksDbContext _tasksDbContext;

        public BaseRepository(TasksDbContext tasksDbContext)
        {
            _tasksDbContext = tasksDbContext;
        }

        public async Task<T> CreateAsync(T commandCreate)
        {
            await _tasksDbContext.Set<T>().AddAsync(commandCreate);
            return commandCreate;
        }

        public Task Delete(Guid Id)
        {
            _tasksDbContext.Remove(Id);
            return Task.CompletedTask;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _tasksDbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _tasksDbContext.Set<T>().ToListAsync();
        }

        public T Update(T commandUpdate)
        {
            _tasksDbContext.Set<T>().Update(commandUpdate);
            return commandUpdate;
        }
    }
}
