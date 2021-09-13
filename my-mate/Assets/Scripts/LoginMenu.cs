using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginMenu : MonoBehaviour
{
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMain()
    {
        SceneManager.LoadScene(2);
    }
}
