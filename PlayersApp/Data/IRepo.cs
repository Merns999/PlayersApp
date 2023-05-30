using Microsoft.AspNetCore.Mvc.Infrastructure;
using PlayersApp.Models.Domain;

namespace PlayersApp.Data
{
    public interface IRepo<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);

    }
}
