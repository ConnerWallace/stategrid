
using Microsoft.Data.Sqlite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlazorApp1.Components.DB
{
    public class TestDbContext
    {
        SqliteConnection connection;
        public TestDbContext() {
            connection = new SqliteConnection("Data Source=stateinfo.db");
        }
        
        public List<string> query(string whereClause)
        {
            var returnObject = new List<string>();

            var command = connection.CreateCommand();
            command.CommandText = whereClause;
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                returnObject.Add(reader.GetString(0));
            }


            return returnObject;
        }
    }
}
