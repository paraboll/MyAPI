using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.DataBase
{
    public class UserRepository
    {
        private string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
 
        public IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(User user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO users (\"Name\", \"Age\")"
                                + " VALUES(@Name, @Age)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users").ToList();
            }
        }

        public User GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM users"
                               + " WHERE \"Id\" = @Id";
                dbConnection.Open();
                return dbConnection.Query<User>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM users"
                             + " WHERE \"Id\" = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(User prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE users SET \"Name\" = @Name,"
                               + " \"Age\" = @Age"
                               + " WHERE \"Id\" = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }
        }

        public void AddDataFrame()
        {
            using(IDbConnection dbConnection = Connection)
            {
                List<User> users = TestDataFrame.GetDataFrame();

                string sQuery = "Insert INTO users(\"Name\",\"Age\") VALUES (@Name,@Age)";

                dbConnection.Open();
                dbConnection.Execute(sQuery, users.ToArray());
            }
        }
    }
}
