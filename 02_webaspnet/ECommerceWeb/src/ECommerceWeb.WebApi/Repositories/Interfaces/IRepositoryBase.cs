using ECommerceWeb.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.WebApi.Repositories.Interfaces;

public interface IRepositoryBase<TEntity>
where TEntity:EntityBase
{
    Task<ICollection<TEntity>> ListAsync();
    Task<int> AddAsync(TEntity entity);

    Task<TEntity?> GetByIdAsync(int id);

    Task UpdateAsync();

    Task DeleteAsync(int id);

}
