using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void GoToKitcenRoom()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToCleaningRoom()
    {
        SceneManager.LoadScene(4);
    }

    public void GoToGameRoom()
    {
        SceneManager.LoadScene(5);
    }
}
