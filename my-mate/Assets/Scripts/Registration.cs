using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField emailField;
    public InputField userNameField;
    public InputField passwordField;
    public InputField ageField;

    public Button completeButton;

    public void CallRegister() {
        Debug.Log("Entro a la funcion callRegister");
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        Debug.Log("Entro al IEnumerable callRegister");
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("email", emailField.text);
        form.AddField("userName", userNameField.text);
        form.AddField("password", passwordField.text);
        form.AddField("age", ageField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localHost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError) 
        {
            Debug.Log("User creation failed. Error #" + www.error);
        }
        else
        {
            Debug.Log("User created successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    public void VerifyInput()
    {
        completeButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
