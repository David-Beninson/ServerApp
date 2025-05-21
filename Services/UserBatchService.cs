using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ServerApp.Models;

namespace ServerApp.Services
{
    public class UserBatchService
    {
        // Get connection string from config file
        private string connectionString = Config.GetConnectionString();

        // This method retrieves all users from the database
        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Users";

            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User
                {
                    ID = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"]
                });
            }

            return users;
        }

        // This method processes each user
        public void ProcessUsers()
        {
            List<User> users = GetAllUsers();

            foreach (var user in users)
            {
                // Simulate sending an email to the user
                Console.WriteLine($"Sending weekly email to {user.Name} <{user.Email}>");
            }
        }
    }
}