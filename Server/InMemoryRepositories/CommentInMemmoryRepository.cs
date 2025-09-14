using Models;
using RepositoryContracts;


namespace InMemoryRepositories;

public class CommentInMemoryRepository : ICommentRepository
{
    private List<Comment> Comments;
    public CommentInMemoryRepository()
    {
        Comment comment = new(001, "I want...", 001);

        AddAsync(comment);
    }
    public Task<Comment> AddAsync(Comment Comment)
    {
        Comment.Id = Comments.Any()
        ? Comments.Max(p => p.Id) + 1
        : 1;
        Comments.Add(Comment);
        return Task.FromResult(Comment);
    }

    public Task<Post> AddAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        Comment? CommentToRemove = Comments.SingleOrDefault(p => p.Id == id);
        if (CommentToRemove is null)
        {
            throw new InvalidOperationException(
                            $"Comment with ID '{id}' not found");
        }

        Comments.Remove(CommentToRemove);
        return Task.CompletedTask;
    }


    public IQueryable<Comment> GetManyAsync()
    {
        return Comments.AsQueryable();
    }


    public Task<Comment> GetSingleAsync(int id)
    {
        Comment? Comment = Comments.SingleOrDefault(p => p.Id == id);
        if (Comment is null)
        {
            throw new InvalidOperationException(
                            $"Comment with ID '{id}' not found");
        }
        return Task.FromResult(Comment);
    }


    public Task UpdateAsync(Comment Comment)
    {
        Comment? existingComment = Comments.SingleOrDefault(p => p.Id == Comment.Id);
        if (existingComment is null)
        {
            throw new InvalidOperationException(
                    $"Comment with ID '{Comment.Id}' not found");
        }

        Comments.Remove(existingComment);
        Comments.Add(Comment);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }

    IQueryable<Post> ICommentsRepository.GetManyAsync()
    {
        throw new NotImplementedException();
    }

    Task<Post> ICommentsRepository.GetSingleAsync(int id)
    {
        throw new NotImplementedException();
    }
}