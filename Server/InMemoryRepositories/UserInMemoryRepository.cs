using Models;
using RepositoryContracts;


namespace InMemoryRepositories;

public class UserInMemoryRepository : IUserRepository
{
    private List<User> Users;
    public UserInMemoryRepository()
    {
        User user = new(001,"mateus","123");
    
        
        AddAsync(user);
    }
    public Task<User> AddAsync(User User)
    {
        User.Id = Users.Any()
        ? Users.Max(p => p.Id) + 1
        : 1;
        Users.Add(User);
        return Task.FromResult(User);
    }

    public Task<Post> AddAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        User? UserToRemove = Users.SingleOrDefault(p => p.Id == id);
        if (UserToRemove is null)
        {
            throw new InvalidOperationException(
                            $"User with ID '{id}' not found");
        }

        Users.Remove(UserToRemove);
        return Task.CompletedTask;
    }


    public IQueryable<User> GetManyAsync()
    {
        return Users.AsQueryable();
    }


    public Task<User> GetSingleAsync(int id)
    {
        User? User = Users.SingleOrDefault(p => p.Id == id);
        if (User is null)
        {
            throw new InvalidOperationException(
                            $"User with ID '{id}' not found");
        }
        return Task.FromResult(User);
    }


    public Task UpdateAsync(User User)
    {
        User? existingUser = Users.SingleOrDefault(p => p.Id == User.Id);
        if (existingUser is null)
        {
            throw new InvalidOperationException(
                    $"User with ID '{User.Id}' not found");
        }

        Users.Remove(existingUser);
        Users.Add(User);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }

    IQueryable<Post> IUserRepository.GetManyAsync()
    {
        throw new NotImplementedException();
    }

    Task<Post> IUserRepository.GetSingleAsync(int id)
    {
        throw new NotImplementedException();
    }
}