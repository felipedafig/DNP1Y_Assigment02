
using RepositoryContracts;
using InMemoryRepositories;

namespace CLI.UI;


public class CliApp(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository)
{
    public IUserRepository userRepository { set; get; } = userRepository; 
    public ICommentRepository commentRepository { set; get; } = commentRepository; 
    public IPostRepository postRepository { set; get; } = postRepository; 

}