using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DataBase : MonoBehaviour
{

    private string dbName = "URI=file:my-mate.db";
    // Start is called before the first frame update
    void Start()
    {
        CreateDB();

        AddPlayer("Jose Miguel", "jgalindo", "890", 1, "jgalindo@gmail.com");

        DisplayPlayers();
    }

    public void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName)) 
        {
            connection.Open();

            using (var command = connection.CreateCommand()) 
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS players (name VARCHAR(50), userName VARCHAR(50), password VARCHAR(50), level INT, email VARCHAR(50))";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }           
    }

    public void AddPlayer(string playerName, string playerUserName, string playerPassword, int playerLevel, string playerEmail)
    {
        using (var connection = new SqliteConnection(dbName)) 
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                 command.CommandText = "INSERT INTO players (name, userName, password, level, email) VALUES ('" + playerName + "', '" + playerUserName + "', '" + playerPassword + "', '" + playerLevel + "', '" + playerEmail + "');";
                 command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void DisplayPlayers() 
    {
        using (var connection = new SqliteConnection(dbName)) 
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM players;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())

                        Debug.Log("Name: " + reader["name"] + "\tUser name:" + reader["userName"] + "\tPassword:" + reader["password"] + "\tLevel:" + reader["level"] + "\tEmail:" + reader["email"]);

                        reader.Close();
                }
            }

            connection.Close();
        }
    }
}
