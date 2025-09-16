using Models;

namespace RepositoryContracts;

public interface IUserRepository
{
    Task<User> AddAsync(User post);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task<User> GetSingleAsync(int id);
    IQueryable<User> GetMany();
}