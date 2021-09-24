using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
    private string dbName = "URI=file:my-mate.db";

    public InputField nameInput;
    public InputField emailInput;
    public InputField userNameInput;
    public InputField passwordInput;

    void Start()
    {
        CreateDB();
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

    public void AddPlayer()
    {
        using (var connection = new SqliteConnection(dbName)) 
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                 command.CommandText = "INSERT INTO players (name, userName, password, level, email) VALUES ('" + nameInput.text + "', '" + userNameInput.text + "', '" + passwordInput.text + "', '" + 1 + "', '" + emailInput.text + "');";
                 command.ExecuteNonQuery();
            }
            SceneManager.LoadScene("Login");
            connection.Close();
        }
    }
}
