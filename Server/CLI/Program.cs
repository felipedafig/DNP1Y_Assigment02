
using CLI.UI;
using InMemoryRepositories;
using RepositoryContracts;

Console.WriteLine("Loading CLI...");

IUserRepository userRepository = new UserInMemoryRepository();
ICommentRepository commentRepository = new CommentInMemoryRepository();
IPostRepository postRepository = new PostInMemoryRepository();

CLIApp cliApp = new CLIApp(userRepository, commentRepository, postRepository);
await cliApp.StartAsync();


