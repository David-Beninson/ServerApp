using ServerApp.Controllers;
using ServerApp.Services;
using ServerApp.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ServerApp started.");

        // Create controller and service instances
        var controller = new UserController();
        var batchService = new UserBatchService();

        // 1. Add a mock new user
        var newUser = new User
        {
            Name = "David",
            Email = "david@example.com",
            Password = "123456"
        };

        controller.AddUser(newUser);
        Console.WriteLine("User added.");

        // 2. Get user by ID (example: ID 1)
        var user = controller.GetUserById(5);
        if (user != null)
        {

            Console.WriteLine($"User retrieved: {user.Name}, {user.Email}");

            // ✨ UPDATE the user's Password
            user.Password = "1341431343";
            controller.UpdateUser(user);
            Console.WriteLine("User updated.");

            // 4. Delete the user by ID
            controller.DeleteUser(user.ID);
            Console.WriteLine("User deleted.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }

        // 3. Run batch service
        Console.WriteLine("Running batch process:");
        batchService.ProcessUsers();

        Console.WriteLine("Done.");
    }
}