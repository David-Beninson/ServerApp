ServerApp

This is a C# .NET server application for managing users with CRUD operations and batch processing.

Overview
	•	Implements a REST API to manage users (Create, Read, Update, Delete) stored in an MsSQL database.
	•	Includes a batch service that processes all users (e.g., sending simulated weekly emails).
	•	Uses System.Data.SqlClient for database connectivity.
	•	Designed as part of a fullstack assignment.

Setup
	1.	Ensure you have MsSQL Server installed and running.
	2.	Create a database named MyDatabase and a table Users with columns:
ID (int, PK, auto-increment), Name (varchar), Email (varchar), Password (varchar).
	3.	Update your connection string in the appsettings.json or in the Config class.
	4.	Build and run the project using Visual Studio or dotnet run.

Features
	•	UserController: Handles CRUD operations on the Users table.
	•	UserBatchService: Retrieves all users and performs batch operations like sending emails.
	•	Config: Loads connection strings from configuration file.

Notes
	•	Batch service can be scheduled externally to run at specific intervals.

Usage
	•	Start the server: dotnet run
	•	Use the API endpoints or a console client to add, update, delete, and retrieve users.
	•	Manually invoke batch service via ProcessUsers method to simulate batch processing.
