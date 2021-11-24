using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
    //private string dbName = "URI=file:my-mate.db";
    //string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";
    public InputField userNameInput;
    public InputField passwordInput;
    public string userNameDB;
    public string passwordDB;

    IDbConnection dbcon;
    IDbCommand dbcmd;

    public void GoToRegister()
    {
        SceneManager.LoadScene("Register");
    }

    public void GoToMain()
    {
        /*
        using (var connection = new SqliteConnection(dbName)) 
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM players WHERE userName='" + userNameInput.text + "' AND password='" + passwordInput.text + "';";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        userNameDB = reader["userName"].ToString();
                        passwordDB = reader["password"].ToString();

                        if(userNameInput.text == userNameDB)
                        {
                            Debug.Log("Login succesfull");
                            SceneManager.LoadScene("main");
                        } else 
                            {
                                Debug.Log("UserName Or Password incorrect, try again.");
                            }
                        reader.Close();
                }
            }
            connection.Close();
        }
        */

        string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";

        // Open connection
        //IDbConnection dbcon = new SqliteConnection(connection);
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();
        using (var command = dbcon.CreateCommand())
        {
            command.CommandText = "SELECT * FROM players WHERE userName='" + userNameInput.text + "' AND password='" + passwordInput.text + "';";

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    userNameDB = reader["userName"].ToString();
                passwordDB = reader["password"].ToString();

                if (userNameInput.text == userNameDB)
                {
                    Debug.Log("Login succesfull");
                    SceneManager.LoadScene("main");
                }
                else
                {
                    Debug.Log("UserName Or Password incorrect, try again.");
                }
                reader.Close();
            }
        }
        dbcon.Close();
    }
}
