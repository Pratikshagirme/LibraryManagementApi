using Microsoft.Data.SqlClient;

namespace LibraryManagementAPI.Helpers
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;
        public DatabaseConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public SqlConnection GetConnectionString()
        {
            return new SqlConnection ( _connectionString);
        }
    }
}
