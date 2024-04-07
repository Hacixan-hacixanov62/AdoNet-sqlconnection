
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetExample.Data
{
    internal class AppDbContext
    {
    
     public SqlConnection connection = new SqlConnection("Server=DESKTOP-LQO56E8\\SQLEXPRESS;Database=AdoNetDb;Trusted_Connection=true;TrustServerCertificate=True");

        public void CheckConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            } 
        }
    }
}




