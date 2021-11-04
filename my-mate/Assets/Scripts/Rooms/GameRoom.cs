using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRoom : MonoBehaviour
{

    public void GoToMain()
    {
        SceneManager.LoadScene("main");
    }

    public void GoToHockey()
    {
        SceneManager.LoadScene("Hockey");
    }
}
