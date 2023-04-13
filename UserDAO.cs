using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace bth6
{
    public class UserDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public bool checkUser (string userName)
        {
            string sql = @"SELECT COUNT(*) FROM UserInfo WHERE UserName = @usn";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@usn", userName);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }
        public int count()
        {
            string sql = @"SELECT COUNT(*) FROM UserInfo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count;
            }
        }
        public bool Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO  UserInfo(Id,UserName,Password,FirstName,LastName,Email,Gender,Address) 
                                            VALUES (@id,@username,@password,@firstname,@lastname,@email,@gender,@address)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", count() + 1);
                cmd.Parameters.AddWithValue("@username", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                cmd.Parameters.AddWithValue("@lastname", user.LastName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@gender", user.Gender);
                cmd.Parameters.AddWithValue("@address", user.Address);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public bool Remove(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"DELETE FROM [dbo].[UserInfo] WHERE UserName = @username";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@username", user.UserName);
                connection.Open();
                int result = (int)cmd.ExecuteNonQuery();
                connection.Close();
                return (result >= 1);
            }
        }
        public DataTable GetAllUsers()
        {
            string queryString = @"SELECT * FROM [dbo].[UserInfo]";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionString);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}