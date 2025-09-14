
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Models;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class CreateUsersView
{

    private readonly IUserRepository userRepository;
    private int IdCount;

    public CreateUsersView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task DisplayUserCreation()
    {
        Console.WriteLine("Register new user");
        Console.WriteLine("Username:");
        string? username = Console.ReadLine();
        Console.WriteLine("Password:");
        string? password = Console.ReadLine();

        User user = new User(001, username, password);

        User added = await userRepository.AddAsync(user);
        
    }


}