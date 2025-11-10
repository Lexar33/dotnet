using System;
using ECommerceWeb.WebApi.DataAccess;
using ECommerceWeb.WebApi.Entities;
using ECommerceWeb.WebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.WebApi.Repositories.Services;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
where TEntity : EntityBase
{
    private readonly ECommerceDbContext _context;

    public RepositoryBase(ECommerceDbContext context)
    {
        this._context = context;
    }


    public async Task<int> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return await _context.SaveChangesAsync(); // Confirma los datos en la db
    }

    public async Task<ICollection<TEntity>> ListAsync()
    {
       return await _context.Set<TEntity>().ToListAsync();
    }
}
