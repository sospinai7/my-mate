using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenRoom : MonoBehaviour
{
    public void GoToMain()
    {
        SceneManager.LoadScene(2);
    }
}
