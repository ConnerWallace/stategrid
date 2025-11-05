
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
            command.CommandText = "SELECT name from states where " + whereClause;
            //command.Parameters.AddWithValue("$text1", startingChars);
            //TODO use parameters maybe
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                returnObject.Add(reader.GetString(0).ToLowerInvariant());
            }


            return returnObject;
        }

        public List<string> nameStartsWith(string startingChars)
        {
            var returnObject = new List<string>();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT name from states where name LIKE '"+startingChars+"%'";
            //command.Parameters.AddWithValue("$text1", startingChars);
            //TODO use parameters maybe
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                returnObject.Add(reader.GetString(0).ToLowerInvariant());
            }


            return returnObject;
        }

        public List<string> areaSmallerThan(int size)
        {
            var returnObject = new List<string>();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT name from states where area <" + size;
            //command.Parameters.AddWithValue("$text1", startingChars);
            //TODO use parameters maybe
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                returnObject.Add(reader.GetString(0).ToLowerInvariant());
            }


            return returnObject;
        }
    }
}
