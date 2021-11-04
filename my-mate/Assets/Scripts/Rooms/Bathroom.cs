using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.SceneManagement;

public class Bathroom : MonoBehaviour
{
    public void GoToMain()
    {
        SceneManager.LoadScene("main");
    }
}
