using ServerApp;
using System;
using System.Data.SqlClient;
using ServerApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace ServerApp.Controllers
{
    public class UserController
    {
        // Connection string for connecting to the MsSQL database
        private string connectionString = Config.GetConnectionString();

        // Util: Hash the password using SHA256 
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        // Create (Add a new user to the database)
        public void AddUser(User user)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Users (Name, Email, Password) VALUES (@Name, @Email, @Password)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", HashPassword(user.Password)); // Store hashed password
            command.ExecuteNonQuery();
        }

        // Read (Retrieve a user by ID)
        public User GetUserById(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Users WHERE ID = @ID";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    ID = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"] 
                };
            }
            return null;
        }

        // Update (Modify user information)
        public void UpdateUser(User user)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "UPDATE Users SET Name = @Name, Email = @Email, Password = @Password WHERE ID = @ID";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", user.ID);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", HashPassword(user.Password)); 
            command.ExecuteNonQuery();
        }

        // Delete (Remove a user from the database)
        public void DeleteUser(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "DELETE FROM Users WHERE ID = @ID";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();
        }
    }
}