using System;
using System.Data.SqlClient;

namespace dbconnection
{
    public class Repository
    {
        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertData(string data)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO DataTable(Data) VALUES(@data)", connection);
                command.Parameters.AddWithValue("@data", data);

                command.ExecuteNonQuery();
            }
        }
    }
}